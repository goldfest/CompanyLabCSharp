using TravelCompanyBusinessLogic.OfficePackage.HelperEnums;
using TravelCompanyBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateTravelDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new
WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var component in info.Travels)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
(component.TravelName, new WordTextProperties { Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }

        public void CreateShopsDoc(WordShopInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            CreateTable(new List<string> { "3000", "3000", "3000" });
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "Название", "Адрес", "Дата открытия" },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    Bold = true,
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var shop in info.Shops)
            {
                CreateRow(new WordRowParameters
                {
                    Texts = new List<string> { shop.ShopName, shop.Adress, shop.OpeningDate.ToString() },
                    TextProperties = new WordTextProperties
                    {
                        Size = "22",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }
        protected abstract void CreateWord(IDocument info);
        protected abstract void CreateParagraph(WordParagraph paragraph);
        protected abstract void SaveWord(IDocument info);
        protected abstract void CreateTable(List<string> colums);
        protected abstract void CreateRow(WordRowParameters rowParameters);
    }

}
