using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFirst
{
    public class Utilities
    {

        static List<TableDatacollection> _tableDatacollection = new List<TableDatacollection>();

        public static void ReadTable(IWebElement table)
        {
            // Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            // get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colData = row.FindElements(By.TagName("td"));

                foreach (var colValue in colData)
                {
                    _tableDatacollection.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                                   columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnSpecialValues = colValue.Text != "" ? null :
                                            colValue.FindElements(By.TagName("input"))
                    }
                        );
                    //move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName,
            string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollection
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                // Need to operate on those controls
                if (controlToOperate != null && cell != null)
                {
                    var returnedControl = (from c in cell
                                           where c.GetAttribute("value") == controlToOperate
                                           select c).SingleOrDefault();
                    // Todo: currently only click is supported future is not taken care of here.
                    returnedControl?.Click();
                }
                else
                {
                    // if (cell != null) cell.First().Click();
                    cell?.First().Click();
                }
            }

        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            // dynamic row
            foreach (var table in _tableDatacollection)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }
        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDatacollection
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public IEnumerable<IWebElement> ColumnSpecialValues { get; set; }

    }
}
