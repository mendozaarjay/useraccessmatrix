using System;
using System.Data;
using System.Windows.Forms;
using UserAccess.Models;
using UserAccess.Services;

namespace UserAccess
{
    public partial class Roles : Form
    {
        private enum OperationType
        {
            Default,
            New,
            Edit,
            Save,
            Delete,
            Cancel,
            Search
        };
        private bool isLoaded = false;
        private bool isNew = false;
        private RoleServices services = new RoleServices();
        public Roles()
        {
            InitializeComponent();
            txtId.TextChanged += IdChanged;
            txtCode.TextChanged += CodeChanged;
        }

        protected override  void OnLoad(EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnFind.Visible = false;
            EnableButtons(OperationType.Default);
            ClearFields();
            EnableFields(false);
            LoadAllRecords();
            dgItems.ClearSelection();
            base.OnLoad(e);
        }
        protected override void OnShown(EventArgs e)
        {
            isLoaded = true;
            base.OnShown(e);
        }
        private void ClearFields()
        {
            txtCode.Clear();
            txtDescription.Clear();
            txtId.Clear();
        }
        private void EnableFields(bool isEnabled)
        {
            txtCode.ReadOnly = txtDescription.ReadOnly = !isEnabled;
        }
        private void LoadAllRecords()
        {
            isLoaded = false;
            dgItems.Rows.Clear();
            DataTable dt = services.GetAllRolesDataTable();
            if(dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dgItems.Rows.Add(dt.Rows.Count);
                    var row = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgItems[dtlId.Index, row].Value = dr["RoleId"].ToString();
                        dgItems[dtlCode.Index, row].Value = dr["Code"].ToString();
                        dgItems[dtlDescription.Index, row].Value = dr["Description"].ToString();
                        dgItems[dtlCreatedBy.Index, row].Value = dr["CreatedBy"].ToString();
                        dgItems[dtlCreatedDate.Index, row].Value = dr["CreatedDate"].ToString();
                        dgItems[dtlModifiedBy.Index, row].Value = dr["ModifiedBy"].ToString();
                        dgItems[dtlModifiedDate.Index, row].Value = dr["ModifiedDate"].ToString();
                        row++;
                    } 
                }
            }
            isLoaded = true;
        }
        private void LoadModuleDetails()
        {
            var id = dgItems[dtlId.Index, dgItems.CurrentRow.Index].Value.ToString();
            var dt = services.GetRoleDetails(int.Parse(id));
            if(dt != null)
            {
                if(dgItems.Rows.Count > 0)
                {
                    txtId.Text = dt.Rows[0]["RoleId"].ToString();
                    txtCode.Text = dt.Rows[0]["Code"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Prompt.Question("Are you sure to save the current record?",this.Text) == DialogResult.Yes)
            {
                if (AreValidEntries())
                {
                    var item = new RoleModel
                    {
                        RoleId = txtId.Text.Length > 0 ? int.Parse(txtId.Text) : 0,
                        Code = txtCode.Text,
                        Description = txtDescription.Text,
                    };
                    var result = await services.Save(item);
                    if (result.Contains("successfully"))
                    {
                        Prompt.Information(result, this.Text);
                        ClearFields();
                        EnableFields(false);
                        LoadAllRecords();
                        EnableButtons(OperationType.Default);
                        isNew = false;

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
            if (txtCode.Text.Length <= 0)
                result += "Cannot Continue. Code is required.\n";
            if (txtDescription.Text.Length <= 0)
                result += "Cannot Continue. Description is required.\n";
            if (isNew && services.IsExist(txtCode.Text))
                result += "Cannot Continue. Role code already exists.\n";
            if(result.Length > 0)
            {
                Prompt.Error(result, this.Text);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void EnableButtons(OperationType type)
        {
            switch (type)
            {
                case OperationType.Default:
                    dgItems.ClearSelection();
                    btnSave.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnCancel.Enabled = false;
                    btnNew.Enabled = true;
                    ClearFields();
                    EnableFields(false);
                    dgItems.Enabled = true;
                    break;
                case OperationType.New:
                    dgItems.ClearSelection();
                    btnNew.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                    btnSave.Enabled = btnFind.Enabled = btnCancel.Enabled = true;
                    ClearFields();
                    EnableFields(true);
                    txtCode.Focus();
                    dgItems.Enabled = false;
                    break;
                case OperationType.Edit:
                    btnNew.Enabled = btnEdit.Enabled = btnFind.Enabled = btnDelete.Enabled = false;
                    btnSave.Enabled = btnCancel.Enabled = true;
                    EnableFieldsForEditing();
                    dgItems.Enabled = false;
                    break;
                case OperationType.Search:
                    btnDelete.Enabled = btnEdit.Enabled = btnNew.Enabled = btnFind.Enabled = true ;
                    btnSave.Enabled = false;
                    break;
                case OperationType.Cancel:
                    dgItems.ClearSelection();
                    btnSave.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnCancel.Enabled = false;
                    btnNew.Enabled = true;
                    ClearFields();
                    EnableFields(false);
                    dgItems.Enabled = true;
                    break;
            }
        }

        private void EnableFieldsForEditing()
        {
            txtCode.ReadOnly = true;
            txtDescription.ReadOnly = false;
            txtDescription.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EnableButtons(OperationType.New);
            isNew = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isNew = false;
            EnableButtons(OperationType.Edit);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isNew = false;
            EnableButtons(OperationType.Cancel);
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(Prompt.Question("Are you sure you want to delete this record?",this.Text) == DialogResult.Yes)
            {
                var result = await services.Delete(int.Parse(txtId.Text));
                if (result.Contains("successfully"))
                {
                    Prompt.Information(result, this.Text);
                    ClearFields();
                    EnableFields(false);
                    LoadAllRecords();
                    EnableButtons(OperationType.Default);
                    isNew = false;
                }
                else
                {
                    Prompt.Error(result, this.Text);
                }
            }
        }
        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {
            if(dgItems.CurrentRow.Index >= 0 && isLoaded && !isNew)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                var id = dgItems[dtlId.Index, dgItems.CurrentRow.Index].Value.ToString();
               
                DataTable dt = services.GetRoleDetails(int.Parse(id));
                if(dt != null)
                {
                    txtId.Text = dt.Rows[0]["RoleId"].ToString();
                    txtCode.Text = dt.Rows[0]["Code"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
            }
        }
        private void CodeChanged(object sender, EventArgs e)
        {
            txtCode.Text = txtCode.Text.Replace(" ", "");
            txtCode.Text = txtCode.Text.Replace("\t", "");
        }

        private void IdChanged(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }


    }
}
