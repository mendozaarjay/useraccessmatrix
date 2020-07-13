using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAccess.Helpers;
using UserAccess.Models;
using UserAccess.Services;

namespace UserAccess
{
    public partial class RoleModulesAssignment : Form
    {
        private RoleModuleAssignmentServices services = new RoleModuleAssignmentServices();
        public RoleModulesAssignment()
        {
            InitializeComponent();
            dgItems.DataError += dgOnDataError;
        }
        protected override void OnLoad(EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnNew.Visible = btnDelete.Visible = btnEdit.Visible = btnCancel.Visible = btnFind.Visible = false;
            LoadAllRoles();
            cboRoles.SelectedValue = string.Empty;
            this.PerformLayout();
        
            base.OnLoad(e);
        }
        private async void LoadAllRoles()
        {
            var dt = await services.GetAllRolesAsync();
            cboRoles.DataSource = dt;
            cboRoles.DisplayMember = "Description";
            cboRoles.ValueMember = "RoleId";
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if(cboRoles.SelectedIndex < 0)
            {
                Prompt.Information("Please select role to continue.", this.Text);
                return;
            }    

            List<ReferenceItem> items = new List<ReferenceItem>();
            var dt = ReferenceData.Modules();
            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        var item = new ReferenceItem
                        {
                            Id = dr["ModuleId"].ToString(),
                            Code = dr["Code"].ToString(),
                            Description = dr["Description"].ToString(),
                        };
                        items.Add(item);
                    }

                    var result = Finder.SearchMultiple(items);
                    AddModules(result);
                }
            }
        }

        private void AddModules(List<ReferenceItem> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (!dgItems.IsExist(dtlModuleId.Index, item.Id))
                    {
                        dgItems.Rows.Add(1);
                        var row = dgItems.Rows.Count - 1;
                        dgItems[dtlId.Index, row].Value = "0";
                        dgItems[dtlModuleId.Index, row].Value = item.Id;
                        dgItems[dtlModule.Index, row].Value = item.Description;
                        dgItems[dtlCanAccess.Index, row].Value = "0";
                        dgItems[dtlCanAdd.Index, row].Value = "0";
                        dgItems[dtlCanEdit.Index, row].Value = "0";
                        dgItems[dtlCanExport.Index, row].Value = "0";
                        dgItems[dtlCanPrint.Index, row].Value = "0";
                        dgItems[dtlCanSave.Index, row].Value = "0";
                        dgItems[dtlCanSearch.Index, row].Value = "0";
                        dgItems[dtlCanDelete.Index, row].Value = "0";
                    }
                } 
            }
        }

        private void dgOnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if(dgItems.Rows.Count > 0)
            {
                for(int col = dtlCanAdd.Index; col < dgItems.Columns.Count;col++)
                {
                    for(int row = 0; row < dgItems.Rows.Count;row++)
                    {
                        dgItems[col, row].Value = "1";
                    }
                }
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {
                for (int col = dtlCanAdd.Index; col < dgItems.Columns.Count; col++)
                {
                    for (int row = 0; row < dgItems.Rows.Count; row++)
                    {
                        dgItems[col, row].Value = "0";
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            dgItems.EndEdit();
            if(Prompt.Question("Are you sure you want to save the current record?",this.Text) == DialogResult.Yes)
            {
                if(AreValidEntries())
                {
                    var items = new List<RoleModuleAssignmentModel>();

                    for(int row = 0; row < dgItems.Rows.Count;row++)
                    {
                        var item = new RoleModuleAssignmentModel
                        {
                            Id = int.Parse(dgItems[dtlId.Index,row].Value.ToString()),
                            RoleId = int.Parse(cboRoles.SelectedValue.ToString()),
                            ModuleId = int.Parse(dgItems[dtlModuleId.Index,row].Value.ToString()),
                            CanAccess = ValueConverter.ConvertToBoolean(dgItems[dtlCanAccess.Index,row].Value.ToString()),
                            CanAdd = ValueConverter.ConvertToBoolean(dgItems[dtlCanAdd.Index,row].Value.ToString()),
                            CanEdit = ValueConverter.ConvertToBoolean(dgItems[dtlCanEdit.Index,row].Value.ToString()),
                            CanExport = ValueConverter.ConvertToBoolean(dgItems[dtlCanExport.Index,row].Value.ToString()),
                            CanPrint = ValueConverter.ConvertToBoolean(dgItems[dtlCanPrint.Index,row].Value.ToString()),
                            CanSave = ValueConverter.ConvertToBoolean(dgItems[dtlCanSave.Index, row].Value.ToString()),
                            CanSearch = ValueConverter.ConvertToBoolean(dgItems[dtlCanSearch.Index, row].Value.ToString()),
                            CanDelete = ValueConverter.ConvertToBoolean(dgItems[dtlCanDelete.Index, row].Value.ToString()),
                        };
                        items.Add(item);
                    }
                    var result = await services.Save(items);
                    if (result.Contains("successfully"))
                    {
                        Prompt.Information(result, this.Text);
                        await LoadModulesPerRole();
                    }
                    else
                    {
                        Prompt.Error(result, this.Text);
                    }

                }
            }
        }

        private bool AreValidEntries()
        {
            var result = string.Empty;
            if (cboRoles.SelectedIndex < 0)
                result += "Cannot Continue. Role is required.\n";
            if (dgItems.Rows.Count <= 0)
                result += "Cannot Continue. Module assignment is required.\n";
            if(result.Length > 0)
            {
                Prompt.Error(result, this.Text);
                return false;
            } else { return true; }
        }
        private async void cboRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!(cboRoles.SelectedIndex < 0) )
            {
                await LoadModulesPerRole();
            }
        }
        private bool IsNumeric(string s)
        {
            try
            {
                var i = int.Parse(s);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async Task LoadModulesPerRole()
        {
            if (cboRoles.SelectedIndex < 0)
                return;

            var role = cboRoles.SelectedValue.ToString();
            if (IsNumeric(role))
            {
                var items = await services.GetAssignmentPerRole(int.Parse(role));
                dgItems.Rows.Clear();

                if(items.Rows.Count > 0)
                {
                    dgItems.Rows.Add(items.Rows.Count);
                    var row = 0;

                    foreach(DataRow dr in items.Rows)
                    {
                        dgItems[dtlId.Index, row].Value = dr["Id"].ToString();
                        dgItems[dtlModuleId.Index, row].Value = dr["ModuleId"].ToString();
                        dgItems[dtlModule.Index, row].Value = dr["ModuleDescription"].ToString();
                        dgItems[dtlCanAccess.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanAccess"].ToString());
                        dgItems[dtlCanAdd.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanAdd"].ToString());
                        dgItems[dtlCanEdit.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanEdit"].ToString());
                        dgItems[dtlCanExport.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanExport"].ToString());
                        dgItems[dtlCanPrint.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanPrint"].ToString());
                        dgItems[dtlCanSave.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanSave"].ToString());
                        dgItems[dtlCanSearch.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanSearch"].ToString());
                        dgItems[dtlCanDelete.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanDelete"].ToString());
                        row++;
                    }
                }
            }
        }

        private async void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgItems.CurrentRow.Index < 0)
                return;
            var row = dgItems.CurrentRow.Index;
            var id = dgItems[dtlId.Index, row].Value.ToString();
            if(Prompt.Question("Are you sure you want to delete this record?",this.Text) == DialogResult.Yes)
            {
                if (id.Equals("0"))
                {
                    dgItems.Rows.RemoveAt(row);
                }
                else
                {
                    var result = await services.DeleteData(id);
                    if (result.Contains("successfully"))
                    {
                        dgItems.Rows.RemoveAt(row);
                    }
                    else
                    {
                        Prompt.Error(result, this.Text);
                    }
                }
            }
        }

        private async void btnCopyFrom_Click(object sender, EventArgs e)
        {
            var searchItems = await services.CopyFromRoles(int.Parse(cboRoles.SelectedValue.ToString()));
            var result = Finder.SearchSingle(searchItems);

            if (result == null)
                return;

            if(result.Length > 0)
            {
                var items = await services.GetAssignmentPerRole(int.Parse(result));

                if (items.Rows.Count > 0)
                {
                    foreach (DataRow dr in items.Rows)
                    {
                        if (!dgItems.IsExist(dtlModuleId.Index,dr["ModuleId"].ToString()))
                        {
                            dgItems.Rows.Add(1);
                            var row = dgItems.Rows.Count - 1;
                            dgItems[dtlId.Index, row].Value = "0";
                            dgItems[dtlModuleId.Index, row].Value = dr["ModuleId"].ToString();
                            dgItems[dtlModule.Index, row].Value = dr["ModuleDescription"].ToString();
                            dgItems[dtlCanAccess.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanAccess"].ToString());
                            dgItems[dtlCanAdd.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanAdd"].ToString());
                            dgItems[dtlCanEdit.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanEdit"].ToString());
                            dgItems[dtlCanExport.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanExport"].ToString());
                            dgItems[dtlCanPrint.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanPrint"].ToString());
                            dgItems[dtlCanSave.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanSave"].ToString());
                            dgItems[dtlCanSearch.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanSearch"].ToString());
                            dgItems[dtlCanDelete.Index, row].Value = ValueConverter.ConvertFromBoolean(dr["CanDelete"].ToString()); 
                        }
                    }
                }
            }
        }
    }
}
