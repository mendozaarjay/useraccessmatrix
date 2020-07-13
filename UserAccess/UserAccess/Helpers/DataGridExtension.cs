using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccess.Helpers
{
    public static class DataGridExtension
    {
        public static bool IsExist(this DataGridView dataGrid, string Value)
        {
            var isExist = false;
            for(int col = 0; col <= dataGrid.Columns.Count - 1; col++)
            {
                for(int row = 0; row <= dataGrid.Rows.Count - 1;row++)
                {
                    var currentValue = dataGrid[col, row].Value.ToString().ToLower();
                    if (currentValue.Equals(Value.ToLower()))
                    {
                        isExist = true;
                        break;
                    }
                }
            }
            return isExist;
        }
        public static bool IsExist(this DataGridView dataGrid,int FocusColumn ,string Value)
        {
            var isExist = false;
            for (int row = 0; row <= dataGrid.Rows.Count - 1; row++)
            {
                var currentValue = dataGrid[FocusColumn, row].Value.ToString().ToLower();
                if (currentValue.Equals(Value.ToLower()))
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }
    }
}
