using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cannabis_entities.Models
{
    public class CategoryData
    {
        private bool _notApplicable = false;
        public bool NotApplicable
        {
            get { return _notApplicable; }
            set { _notApplicable = value; }
        }
        public int Arrests { get; set; }
        public int Citations { get; set; }
        public int PenaltyAssessments { get; set; }
        public GenderData Gender { get; set; }
        public AgeData Age { get; set; }
        public RaceData Race { get; set; }
        public EthnicityData Ethnicity { get; set; }
        public PenaltyData PenaltyLevel { get; set; }
    }
}
