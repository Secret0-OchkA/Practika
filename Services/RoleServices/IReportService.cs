using Azure.Core.Pipeline;
using Domain;
using Infrastructura;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RoleServices
{


    public class ReportService : IReportService
    {
        private readonly ApplicationContext applicationContext;

        public ReportService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public Report CreateReport(Report newReport)
        {
            Report? report = applicationContext.Reports
                .SingleOrDefault(r => r.name.Equals(newReport.name));
            if (report != null) throw new ArgumentException("not unique name");

            applicationContext.Reports.Add(newReport);
            applicationContext.SaveChanges();
            return newReport;
        }

        public Report GetReport(string name)
        {
            return applicationContext.Reports.Single(r => r.name.Equals(name));
        }

        public IEnumerable<Report> GetReports()
        {
            return applicationContext.Reports;
        }
    }

    public interface IReportService
    {
        Report CreateReport(Report newReport);

        IEnumerable<Report> GetReports();
        Report GetReport(string name);
    }
}
