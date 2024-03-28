using System;
using cannabis_entities.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cannabis_services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly string _connectionString;

        public ReportService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> SaveReport(Report report)
        {
            string jsonData = System.Text.Json.JsonSerializer.Serialize(report);
            // Convert JSON string to JObject for manipulation
            JObject jsonObject = JObject.Parse(jsonData);

            // Remove the specified section
            jsonObject.Remove("CR_ID");
            jsonObject.Remove("CRI_ID");
            jsonObject.Remove("Completed");
            jsonObject.Remove("AgencyId");

            // Convert JObject back to JSON string
            string modifiedJsonData = jsonObject.ToString();

            string errorMessage = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("NEW_POST_JSON", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@CR_ID", report.CR_ID);
                    command.Parameters.AddWithValue("@CRI_ID", report.CRI_ID);
                    command.Parameters.AddWithValue("@AGENCY_ID", report.AgencyId);
                    command.Parameters.AddWithValue("@JS_FILE", modifiedJsonData);
                    command.Parameters.AddWithValue("@REPORT_COMPLETE", report.Completed ? "Y" : "N");
                    command.Parameters.AddWithValue("@TIMESTAMP", DateTime.Now);
                    command.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    await command.ExecuteNonQueryAsync();

                    // Retrieve output parameter
                    errorMessage = command.Parameters["@ErrorMessage"].Value.ToString();
                }
            }

            if (errorMessage != "Success")
            {
                throw new Exception(errorMessage);
            }

            return "Data stored successfully."; // Or any success message you prefer
        }
        public async Task<string> GetJsonDataByAgencyId(string agencyId)
        {
            string jsonData = null;
            string errorMessage = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GET_JSON", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AgencyID", agencyId);
                    command.Parameters.Add("@JSONData", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                    await command.ExecuteNonQueryAsync();

                    // Retrieve output parameters
                    jsonData = command.Parameters["@JSONData"].Value.ToString();
                    errorMessage = command.Parameters["@ErrorMessage"].Value.ToString();
                }
            }

            if (errorMessage != "Success")
            {
                throw new Exception(errorMessage);
            }

            return jsonData;
        }
    }
}

