using Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccess.Models;

namespace UserAccess.Services
{
    public class RoleModuleAssignmentServices
    {
        private const string StoredProcedure = "[dbo].[spRoleModuleAssignment]";

        public async Task<DataTable> GetAssignmentPerRole(int role)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RoleId", role);
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> Save(IEnumerable<RoleModuleAssignmentModel> items)
        {
            List<SqlCommand> cmdList = new List<SqlCommand>();
            foreach(var item in items)
            {
                var cmd = new SqlCommand();
                cmd.CommandText = StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@RoleId", item.RoleId);
                cmd.Parameters.AddWithValue("@ModuleId", item.ModuleId);
                cmd.Parameters.AddWithValue("@CanAdd", item.CanAdd);
                cmd.Parameters.AddWithValue("@CanEdit", item.CanEdit);
                cmd.Parameters.AddWithValue("@CanSave", item.CanSave);
                cmd.Parameters.AddWithValue("@CanDelete", item.CanDelete);
                cmd.Parameters.AddWithValue("@CanSearch", item.CanSearch);
                cmd.Parameters.AddWithValue("@CanPrint", item.CanPrint);
                cmd.Parameters.AddWithValue("@CanExport", item.CanExport);
                cmd.Parameters.AddWithValue("@CanAccess", item.CanAccess);
                cmd.Parameters.AddWithValue("@UserId", Properties.Settings.Default.CurrentUserId);
                cmd.Parameters.AddWithValue("@QueryType", item.Id == 0 ? 1 : 2);
                cmdList.Add(cmd);
            }
            var result = await DatabaseHelper.ExecNonQueryAsync(cmdList, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> DeleteData(string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@QueryType", 3);
            var result = await DatabaseHelper.ExecNonQueryAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<DataTable> GetAllRolesAsync()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 4);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }

        public async Task<DataTable> GetAllRolesNotInAssignmentAsync()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 5);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<DataTable> GetAllRolesWithAssignmentAsync()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 6);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<List<ReferenceItem>> CopyFromRoles(int role)
        {
            var items = new List<ReferenceItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RoleId", role);
            cmd.Parameters.AddWithValue("@QueryType", 7);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            if(result != null)
            {
                foreach(DataRow dr in result.Rows)
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
            return items;
        }

    }
}
