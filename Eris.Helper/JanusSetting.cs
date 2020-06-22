using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Eris.Helper
{
    public class JanusSetting
    {
        #region Grid Setting
        public static void GridSetting(Janus.Windows.GridEX.GridEX jg, int headerLines)
        {
            jg.Font = new Font("IRAN-sans", 8, FontStyle.Regular);

            jg.FilterRowFormatStyle.BackColor = Color.DarkSalmon;
            jg.AlternatingRowFormatStyle.BackColor = Color.Wheat;
            jg.AlternatingColors = true;
            jg.RootTable.HeaderLines = headerLines;
            jg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            jg.HeaderFormatStyle.BackColor = Color.DarkSalmon;
            jg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            jg.RecordNavigatorText = "تعداد|از";

            int i = 0;
            for (i = 0; i <= jg.RootTable.Columns.Count - 1; i++)
            {
                if (jg.RootTable.Columns[i].DataTypeCode == TypeCode.Int32 || jg.RootTable.Columns[i].DataTypeCode == TypeCode.Int64)
                {
                    jg.RootTable.Columns[i].FormatString = "#,###";
                    jg.RootTable.Columns[i].TotalFormatString = "#,###";
                }
            }
        }

        public static void GridSetting(Janus.Windows.GridEX.GridEX jg, bool filterRow)
        {
            jg.Font = new Font("Tahoma", 8, FontStyle.Regular);
            jg.FilterRowFormatStyle.BackColor = Color.LightSkyBlue;
            jg.AlternatingRowFormatStyle.BackColor = Color.Honeydew;
            jg.AlternatingColors = true;
           // jg.RootTable.HeaderLines = 1;
            jg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            jg.HeaderFormatStyle.BackColor = Color.DarkSalmon;
            jg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            jg.RecordNavigatorText = "تعداد|از";
            jg.RowHeaderContent = RowHeaderContent.RowIndex;
            if (filterRow == true)
            {
                jg.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                jg.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges;
            }
            else
                jg.FilterMode = Janus.Windows.GridEX.FilterMode.None;
            jg.TotalRowPosition = TotalRowPosition.BottomFixed;
        }

        public static void GridSetting(Janus.Windows.GridEX.GridEX jg, bool filterRow, bool totalRow)
        {
            jg.Font = new Font("Tahoma", 8, FontStyle.Regular);
            jg.FilterRowFormatStyle.BackColor = Color.LightSkyBlue;
            jg.AlternatingRowFormatStyle.BackColor = Color.Honeydew;
            jg.AlternatingColors = true;
            //jg.RootTable.HeaderLines = 1;
            jg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            jg.HeaderFormatStyle.BackColor = Color.DarkSalmon;
            jg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            jg.RecordNavigatorText = "تعداد|از";
            jg.RowHeaderContent = RowHeaderContent.RowIndex;
            if (filterRow == true)
            {
                jg.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                jg.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges;
            }
            else
                jg.FilterMode = Janus.Windows.GridEX.FilterMode.None;

            if (totalRow == true)
                jg.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            else
                jg.TotalRow = Janus.Windows.GridEX.InheritableBoolean.False;
            jg.TotalRowPosition = TotalRowPosition.BottomFixed;
        }

        public static void GridFormatConditionSetting(GridEX jg, GridEXColumn gcName, object gcValue, ConditionOperator co)
        {

            GridEXFormatCondition fc = new GridEXFormatCondition();
            fc.Column = gcName;
            fc.ConditionOperator = co;
            fc.Value1 = gcValue;
            fc.FormatStyle.BackColor = Color.GreenYellow;
            jg.RootTable.FormatConditions.Add(fc);

        }
    
        public static void GridFormatConditionSetting(GridEX jg, GridEXColumn gcName, object gcValue, ConditionOperator co, Color color)
        {

            GridEXFormatCondition fc = new GridEXFormatCondition();
            fc.Column = gcName;
            fc.ConditionOperator = co;
            fc.Value1 = gcValue;
            fc.FormatStyle.BackColor = color;
            jg.RootTable.FormatConditions.Add(fc);

        }
        #endregion
    }
}