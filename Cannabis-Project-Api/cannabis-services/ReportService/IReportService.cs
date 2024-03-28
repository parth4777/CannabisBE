using System;
using cannabis_entities.Models;

namespace cannabis_services.ReportService
{
	public interface IReportService
	{
        Task<string> SaveReport(Report report);
        Task<string> GetJsonDataByAgencyId(string agencyId);

    }
}

