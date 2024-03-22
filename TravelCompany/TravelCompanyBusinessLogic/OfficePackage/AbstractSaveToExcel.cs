using TravelCompanyBusinessLogic.OfficePackage.HelperEnums;
using TravelCompanyBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });
            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });
            uint rowIndex = 2;
            foreach (var pc in info.TravelComponents)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = pc.TravelName,
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
                foreach (var Travel in pc.Components)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = Travel.Item1,
                        StyleInfo =
                    ExcelStyleInfoType.TextWithBroder
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = Travel.Item2.ToString(),
                        StyleInfo =
                    ExcelStyleInfoType.TextWithBroder
                    });
                    rowIndex++;
                }
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого",
                    StyleInfo = ExcelStyleInfoType.Text
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = pc.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }
            SaveExcel(info);
        }
        protected abstract void CreateExcel(ExcelInfo info);
        protected abstract void InsertCellInWorksheet(ExcelCellParameters
        excelParams);
        protected abstract void MergeCells(ExcelMergeParameters excelParams);
        protected abstract void SaveExcel(ExcelInfo info);
    }
}
