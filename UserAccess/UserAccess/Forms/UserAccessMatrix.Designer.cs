namespace UserAccess
{
    partial class UserAccessMatrix
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccessMatrix));
            this.btnUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyFrom = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveRow = new System.Windows.Forms.ToolStripButton();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCheckAll = new System.Windows.Forms.ToolStripButton();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.dtlId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlRoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlRoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlRoleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUncheckAll.Image")));
            this.btnUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(110, 24);
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnCopyFrom
            // 
            this.btnCopyFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyFrom.Image")));
            this.btnCopyFrom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyFrom.Name = "btnCopyFrom";
            this.btnCopyFrom.Size = new System.Drawing.Size(105, 24);
            this.btnCopyFrom.Text = "Copy From";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRow.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRow.Image")));
            this.btnRemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(120, 24);
            this.btnRemoveRow.Text = "Remove Row";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(94, 24);
            this.btnAddRow.Text = "Add Row";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRow,
            this.btnRemoveRow,
            this.btnCopyFrom,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.btnCheckAll,
            this.btnUncheckAll});
            this.toolStrip1.Location = new System.Drawing.Point(5, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(890, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckAll.Image")));
            this.btnCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(94, 24);
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.Visible = false;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtlId,
            this.dtlRoleId,
            this.dtlRoleCode,
            this.dtlRoleDescription});
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Location = new System.Drawing.Point(5, 29);
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            this.dgItems.RowHeadersWidth = 51;
            this.dgItems.RowTemplate.Height = 24;
            this.dgItems.Size = new System.Drawing.Size(890, 502);
            this.dgItems.TabIndex = 1;
            // 
            // dtlId
            // 
            this.dtlId.HeaderText = "Id";
            this.dtlId.MinimumWidth = 6;
            this.dtlId.Name = "dtlId";
            this.dtlId.ReadOnly = true;
            this.dtlId.Visible = false;
            this.dtlId.Width = 125;
            // 
            // dtlRoleId
            // 
            this.dtlRoleId.HeaderText = "RoleId";
            this.dtlRoleId.MinimumWidth = 6;
            this.dtlRoleId.Name = "dtlRoleId";
            this.dtlRoleId.ReadOnly = true;
            this.dtlRoleId.Visible = false;
            this.dtlRoleId.Width = 125;
            // 
            // dtlRoleCode
            // 
            this.dtlRoleCode.HeaderText = "Role Code";
            this.dtlRoleCode.MinimumWidth = 6;
            this.dtlRoleCode.Name = "dtlRoleCode";
            this.dtlRoleCode.ReadOnly = true;
            this.dtlRoleCode.Width = 125;
            // 
            // dtlRoleDescription
            // 
            this.dtlRoleDescription.HeaderText = "Role Description";
            this.dtlRoleDescription.MinimumWidth = 6;
            this.dtlRoleDescription.Name = "dtlRoleDescription";
            this.dtlRoleDescription.ReadOnly = true;
            this.dtlRoleDescription.Width = 250;
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(83, 23);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(357, 31);
            this.cboUsers.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboUsers);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtId);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgItems);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.splitContainer1.Size = new System.Drawing.Size(900, 620);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(154, 23);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(67, 30);
            this.txtId.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 24);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnEdit,
            this.btnDelete,
            this.btnCancel,
            this.btnFind});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(900, 27);
            this.bindingNavigator1.TabIndex = 12;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(63, 24);
            this.btnNew.Text = "New";
            this.btnNew.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 24);
            this.btnSave.Text = "Save";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 24);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 24);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(61, 24);
            this.btnFind.Text = "&Find";
            this.btnFind.Visible = false;
            // 
            // UserAccessMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserAccessMatrix";
            this.Text = "User Access Matrix";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnUncheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCopyFrom;
        private System.Windows.Forms.ToolStripButton btnRemoveRow;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCheckAll;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlRoleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlRoleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlRoleDescription;
    }
}