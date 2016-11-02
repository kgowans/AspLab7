using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for TableHelper
/// </summary>
//public class TableHelper
//{
//    public TableHelper(){}

//    public static void AddRow(GridView table, params string[] cells)
//    {
//        TableRow row = new TableRow();
//        foreach (string text in cells)
//        {
//            TableCell cell = new TableCell();
//            cell.Text = text;
//            row.Cells.Add(cell);
//        }
//        table.Rows.Add(row);
//    }

//    public static void AddErrorRow(GridView table, int columnSpan, string message)
//    {
//        TableRow lastRow = new TableRow();
//        TableCell lastRowCell = new TableCell();
//        lastRowCell.Text = message;
//        lastRowCell.ForeColor = System.Drawing.Color.Red;
//        lastRowCell.ColumnSpan = columnSpan;
//        lastRowCell.HorizontalAlign = HorizontalAlign.Center;
//        lastRow.Cells.Add(lastRowCell);
//        table.Rows.Add(lastRow);
//    }
//}