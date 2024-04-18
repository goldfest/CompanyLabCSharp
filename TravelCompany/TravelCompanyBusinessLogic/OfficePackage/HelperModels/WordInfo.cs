using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo : IDocument
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<TravelViewModel> Travels { get; set; } = new();
    }
}
