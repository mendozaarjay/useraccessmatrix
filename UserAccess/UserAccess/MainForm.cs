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
using UserAccess.Utilities;

namespace UserAccess
{
    public partial class MainForm : Form
    {
        private IEnumerable<UserAccessItem> AccessItems { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.AccessItems = AccessMatrix.GetUserAccess(int.Parse(Properties.Settings.Default.CurrentUserId));
            var module = AccessItems.Any(a => a.ModuleCode == "SMOD");
            var role = AccessItems.Any(a => a.ModuleCode == "SROL");
            var roleass = AccessItems.Any(a => a.ModuleCode == "SRMA");
            var uam = AccessItems.Any(a => a.ModuleCode == "SUAM");

            if (module || role || roleass || uam)
            {
                menuStrip1.Visible = true;
            }
            else
            {
                menuStrip1.Visible = false;
            }
            modulesToolStripMenuItem.Visible = module;
            rolesToolStripMenuItem.Visible = role;
            roleModuleAssignmentToolStripMenuItem.Visible = roleass;
            userAccessMatrixToolStripMenuItem.Visible = uam;
            base.OnLoad(e);
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
            var module = AccessItems.FirstOrDefault(a => a.ModuleCode == "SMOD");
            if (!IsAlreadyOpen("Modules") && module.CanAccess)
            {
                Modules frm = new Modules();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.UserAccess = module;
                frm.Show();
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var roles = AccessItems.FirstOrDefault(a => a.ModuleCode == "SROL");
            if (!IsAlreadyOpen("Roles") && roles.CanAccess)
            {
                Roles frm = new Roles();
                frm.UserAccess = roles;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void roleModuleAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var roleass = AccessItems.FirstOrDefault(a => a.ModuleCode == "SRMA");
            if (!IsAlreadyOpen("RoleModulesAssignment") && roleass.CanAccess)
            {
                RoleModulesAssignment frm = new RoleModulesAssignment();
                frm.UserAccess = roleass;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void userAccessMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uam = AccessItems.FirstOrDefault(a => a.ModuleCode == "SUAM");
            if (!IsAlreadyOpen("UserAccessMatrix") && uam.CanAccess)
            {
                UserAccessMatrix frm = new UserAccessMatrix();
                frm.UserAccess = uam;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
    }
}
