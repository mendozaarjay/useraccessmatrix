using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAccess.Helpers;
using UserAccess.Models;
using UserAccess.Services;

namespace UserAccess
{
    public partial class UserAccessMatrix : Form
    {
        private UserAccessMatrixServices services = new UserAccessMatrixServices();
        public UserAccessMatrix()
        {
            InitializeComponent();
            cboUsers.SelectedValueChanged += UserSelectionChanged;
            btnAddRow.Click += AddRow;
            btnRemoveRow.Click += RemoveRow;
            btnCopyFrom.Click += CopyFrom;
            btnSave.Click += SaveRecord;
        }

        private bool isLoading = false;

        protected async override void OnLoad(EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            await LoadAllUsers();
            isLoading = true;
           
            base.OnLoad(e);
        }
        protected override void OnShown(EventArgs e)
        {
            isLoading = false;
            UserSelectionChanged(null, null);
            base.OnShown(e);
        }
        private async Task LoadAllUsers()
        {
            var dt = await services.GetAllUsers();
            if(dt != null)
            {
                cboUsers.DataSource = dt;
                cboUsers.ValueMember = "UserId";
                cboUsers.DisplayMember = "Username";
            }
        }
        private  void UserSelectionChanged(object sender, EventArgs e)
        {
            dgItems.Rows.Clear();
            if(cboUsers.SelectedValue != null)
            {
                if (IsNumeric(cboUsers.SelectedValue.ToString()))
                {
                    var id = int.Parse(cboUsers.SelectedValue.ToString());
                    LoadUserRoles(id);
                }
            }
        }

        private async void CopyFrom(object sender, EventArgs e)
        {
            if (cboUsers.SelectedValue == null)
                return;
            if (!IsNumeric(cboUsers.SelectedValue.ToString()))
                return;

            var dt = await services.GetCopyFrom(int.Parse(cboUsers.SelectedValue.ToString()));
            if (dt == null)
                return;
            var items = new List<ReferenceItem>();
            foreach (DataRow dr in dt.Rows)
            {
                var item = new ReferenceItem
                {
                    Id = dr["UserId"].ToString(),
                    Code = dr["Code"].ToString(),
                    Description = dr["Description"].ToString(),
                };
                items.Add(item);
            }
            var result = Finder.SearchSingle(items);
            if (result != null)
            {
                if (IsNumeric(result))
                {
                    var roles = services.GetUserRoles(int.Parse(result));

                    foreach (DataRow dr in roles.Rows)
                    {
                        if (!dgItems.IsExist(dtlRoleId.Index, dr["RoleId"].ToString()))
                        {
                            dgItems.Rows.Add(1);
                            var row = dgItems.Rows.Count - 1;
                            dgItems[dtlId.Index, row].Value = "0";
                            dgItems[dtlRoleId.Index, row].Value = dr["RoleId"].ToString();
                            dgItems[dtlRoleCode.Index, row].Value = dr["Code"].ToString();
                            dgItems[dtlRoleDescription.Index, row].Value = dr["Description"].ToString();
                        }
                    } 
                }
            }
        }

        private async void RemoveRow(object sender, EventArgs e)
        {
            if (dgItems.CurrentRow.Index < 0)
                return;
            var row = dgItems.CurrentRow.Index;
            var id = dgItems[dtlId.Index, row].Value.ToString();
            if (IsNumeric(id))
            {
                if (Prompt.Question("Are you sure you want to delete this record?", this.Text) == DialogResult.Yes)
                {
                    if (id.Equals("0"))
                    {
                        dgItems.Rows.RemoveAt(row);
                    }
                    else
                    {
                        var result = await services.DeleteData(int.Parse(id));
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
        }

        private void AddRow(object sender, EventArgs e)
        {
            var dt = ReferenceData.Roles();
            var items = new List<ReferenceItem>();
            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    var item = new ReferenceItem
                    {
                        Id = dr["RoleId"].ToString(),
                        Code = dr["Code"].ToString(),
                        Description = dr["Description"].ToString(),
                    };
                    items.Add(item);
                }
            }
            var result = Finder.SearchMultiple(items);
            if(result != null)
            {
                foreach(var item in result)
                {
                    if (!dgItems.IsExist(dtlRoleId.Index, item.Id))
                    {
                        dgItems.Rows.Add(1);
                        var row = dgItems.Rows.Count - 1;
                        dgItems[dtlId.Index, row].Value = "0";
                        dgItems[dtlRoleId.Index, row].Value = item.Id;
                        dgItems[dtlRoleCode.Index, row].Value = item.Code;
                        dgItems[dtlRoleDescription.Index, row].Value = item.Description;
                    }
                }
            }
        }

        private void LoadUserRoles(int id)
        {
            if (isLoading)
                return;

            dgItems.Rows.Clear();
            var items = services.GetUserRoles(id);
            if (items != null)
            {
                if (items.Rows.Count > 0)
                {
                    dgItems.Rows.Add(items.Rows.Count);
                    var row = 0;
                    foreach (DataRow dr in items.Rows)
                    { 
                        dgItems[dtlId.Index, row].Value = dr["Id"].ToString();
                        dgItems[dtlRoleId.Index, row].Value = dr["RoleId"].ToString();
                        dgItems[dtlRoleCode.Index, row].Value = dr["Code"].ToString();
                        dgItems[dtlRoleDescription.Index, row].Value = dr["Description"].ToString();
                        row++;
                    }
                }
            }
        }

        private bool IsNumeric(string item)
        {
            try
            {
                var i = int.Parse(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async void SaveRecord(object sender, EventArgs e)
        {
            if(Prompt.Question("Are you sure you want to save the current record?",this.Text) == DialogResult.Yes)
            {
                if(AreValidEntries())
                {
                    var items = new List<UserAccessMatrixModel>();
                    for(int row = 0; row < dgItems.Rows.Count;row++)
                    {
                        var item = new UserAccessMatrixModel
                        {
                            Id = int.Parse(dgItems[dtlId.Index, row].Value.ToString()),
                            UserId = int.Parse(cboUsers.SelectedValue.ToString()),
                            RoleId = int.Parse(dgItems[dtlRoleId.Index, row].Value.ToString()),
                        };
                        items.Add(item);
                    }
                    var result = await services.Save(items);
                    if (result.Contains("successfully"))
                    {
                        Prompt.Information(result, this.Text);
                        dgItems.Rows.Clear();
                        LoadUserRoles(int.Parse(cboUsers.SelectedValue.ToString()));
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
            if (cboUsers.SelectedIndex < 0)
                result += "Cannot Continue. User is required.\n";
            if (dgItems.Rows.Count <= 0)
                result += "Cannot Continue. User assigned role/s is required.\n";
            if(result.Length > 0)
            {
                Prompt.Error(result, this.Text);
                return false;
            }
            else { return true; }
        }
    }
}
