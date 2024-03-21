using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyBusinessLogic.OfficePackage.HelperEnums;

namespace TravelCompanyBusinessLogic.OfficePackage.HelperModels
{
    public class WordTextProperties
    {
        public string Size { get; set; } = string.Empty;
        public bool Bold { get; set; }
        public WordJustificationType JustificationType { get; set; }
    }
}
