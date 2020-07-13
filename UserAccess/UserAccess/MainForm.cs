using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccess
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private bool IsAlreadyOpen(string formname)
        {
            FormCollection formCollection = Application.OpenForms;
            foreach (Form item in formCollection)
            {
                if (item.Name.ToLower().Equals(formname.ToLower()))
                {
                    item.Focus();
                    return true;
                }
            }
            return false;
        }

        private void modulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAlreadyOpen("Modules"))
            {
                Modules frm = new Modules();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAlreadyOpen("Roles"))
            {
                Roles frm = new Roles();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void roleModuleAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAlreadyOpen("RoleModulesAssignment"))
            {
                RoleModulesAssignment frm = new RoleModulesAssignment();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void userAccessMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAlreadyOpen("UserAccessMatrix"))
            {
                UserAccessMatrix frm = new UserAccessMatrix();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
    }
}
