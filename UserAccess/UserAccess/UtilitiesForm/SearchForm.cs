using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAccess.Models;

namespace UserAccess
{
    public partial class SearchForm : Form
    {
        public bool IsMultiple { get; set; }
        public List<ReferenceItem> SearchItems { get; set; }
        public SearchForm()
        {

            InitializeComponent();
            txtFIlter.TextChanged += FilterChanged;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            var filter = txtFIlter.Text.ToLower();
            if(filter.Length > 0)
            {
                var items = SearchItems.Where(a => a.Code.ToLower().Contains(filter) || a.Description.ToLower().Contains(filter)).ToList();
                LoadSearchItems(items);
            }
            else
            {
                LoadSearchItems(SearchItems);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (IsMultiple)
            {
                pnlSelect.Visible = true;
                dgItems.Columns[dtlSelect.Index].Visible = true;
            }
            else
            {
                pnlSelect.Visible = false;
                dgItems.Columns[dtlSelect.Index].Visible = false;
            }
            LoadSearchItems(SearchItems);
            base.OnLoad(e);
        }
        private void LoadSearchItems(List<ReferenceItem> items)
        {
            dgItems.Rows.Clear();
            if(items != null)
            {
                var row = 0;
                if (items.Count() > 0)
                    dgItems.Rows.Add(items.Count());

                foreach(var item in items)
                {
                    dgItems[dtlSelect.Index, row].Value = "0";
                    dgItems[dtlId.Index, row].Value = item.Id;
                    dgItems[dtlCode.Index, row].Value = item.Code;
                    dgItems[dtlDescription.Index, row].Value = item.Description;
                    row++;
                }
            }
        }
        public List<ReferenceItem> ResultMultiple { get; set; }
        public string ResultSingle { get; set; }
        private void btnOkay_Click(object sender, EventArgs e)
        {
            dgItems.EndEdit();
            if (IsMultiple)
            {
                var items = new List<ReferenceItem>();
                for (int i = 0; i <= dgItems.Rows.Count - 1; i++)
                {
                    var isSelected = dgItems[dtlSelect.Index, i].Value.ToString();
                    if(isSelected == "1")
                    {
                        var id = dgItems[dtlId.Index, i].Value.ToString();
                        var item = SearchItems.FirstOrDefault(a => a.Id == id);
                        items.Add(item);
                    }
                }
                this.ResultMultiple = items;
                this.Close();
                this.Dispose();
            }
            else
            {
                if(dgItems.CurrentRow.Index >= 0)
                {
                    var result = dgItems[dtlId.Index, dgItems.CurrentRow.Index].Value.ToString();
                    this.ResultSingle = result;
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    Prompt.Information("Please select the desired row in the datagrid.", this.Text);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsMultiple)
            {
                var items = new List<ReferenceItem>();
                this.ResultMultiple = items;
                this.Close();
                this.Dispose();
            }
            else
            {
                this.ResultSingle = string.Empty;
                this.Close();
                this.Dispose();
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {
                for (int i = 0; i <= dgItems.Rows.Count - 1; i++)
                {
                    dgItems[dtlSelect.Index, i].Value = "1";
                }
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {
                for (int i = 0; i <= dgItems.Rows.Count - 1; i++)
                {
                    dgItems[dtlSelect.Index, i].Value = "0";
                }
            }
        }

        private void dgItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!IsMultiple)
            {
                if(e.RowIndex >= 0)
                {
                    if (dgItems.CurrentRow.Index >= 0)
                    {
                        var result = dgItems[dtlId.Index, dgItems.CurrentRow.Index].Value.ToString();
                        this.ResultSingle = result;
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        Prompt.Information("Please select the desired row in the datagrid.", this.Text);
                    }
                }
            }
        }
    }
}
