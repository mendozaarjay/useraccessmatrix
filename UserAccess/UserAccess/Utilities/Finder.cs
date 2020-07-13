using System.Collections.Generic;
using UserAccess.Models;

namespace UserAccess
{
    public static class Finder
    {
        public static string SearchSingle(List<ReferenceItem> items)
        {
            var frm = new SearchForm();
            frm.IsMultiple = false;
            frm.SearchItems = items;
            frm.ShowDialog();
            var result = frm.ResultSingle;
            return result;
        }
        public static List<ReferenceItem> SearchMultiple(List<ReferenceItem> items)
        {
            var frm = new SearchForm();
            frm.IsMultiple = true;
            frm.SearchItems = items;
            frm.ShowDialog();
            var result = frm.ResultMultiple;
            return result;
        }
    }
}
