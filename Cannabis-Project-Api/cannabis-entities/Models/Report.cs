using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cannabis_entities.Models
{
    public class Report
    {
        public int? CR_ID { get; set; }
        public int CRI_ID { get; set; }
        public bool Completed { get; set; }
        public string AgencyId { get; set; }
        public CategoryData PersonalProduction { get; set; }
        public CategoryData UnlicensedSale { get; set; }
        public CategoryData RestrictedArea { get; set; }
        public CategoryData UnlawfulPossession { get; set; }
        public CategoryData UnlicensedManufacturing { get; set; }
        public CategoryData DUI { get; set; }
        public CategoryData ADUI { get; set; }
        public CategoryData OperatingMotorboat { get; set; }
        public CategoryData AggravatedOperatingMotorboat { get; set; }
    }
}
