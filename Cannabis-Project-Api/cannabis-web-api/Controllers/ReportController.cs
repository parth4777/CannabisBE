using cannabis_entities.Models;
using cannabis_services.ReportService;
using cannabis_web_api.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;   

namespace cannabis_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> PostReport([FromBody] Report report)
        {
            try
            {
                string resultMessage = await _reportService.SaveReport(report);
                return Ok(resultMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("agency/{agencyId}")]
        public async Task<IActionResult> GetJsonData(string agencyId)
        {
            try
            {
                string jsonData = await _reportService.GetJsonDataByAgencyId(agencyId);

                

                // Return JSON response with appropriate content type
                return Content(jsonData, "application/json", System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}