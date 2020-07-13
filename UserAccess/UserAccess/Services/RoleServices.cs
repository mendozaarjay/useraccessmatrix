using Reports;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserAccess.Models;

namespace UserAccess.Services
{
    public class RoleServices
    {
        private const string StoredProcedure = "[dbo].[spRoles]";
        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var items = new List<RoleModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);

            if (result != null)
            {
                foreach (DataRow dr in result.Rows)
                {
                    var item = new RoleModel
                    {
                        RoleId = int.Parse(dr["RoleId"].ToString()),
                        Code = dr["Code"].ToString(),
                        Description = dr["Description"].ToString(),
                    };
                    items.Add(item);
                }
            }
            return items;
        }

        public DataTable GetAllRolesDataTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result = DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public DataTable GetRoleDetails(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@QueryType", 4);
            var result = DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> Save(RoleModel item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", item.RoleId);
            cmd.Parameters.AddWithValue("@Code", item.Code);
            cmd.Parameters.AddWithValue("@Description", item.Description);
            cmd.Parameters.AddWithValue("@UserId", Properties.Settings.Default.CurrentUserId);
            cmd.Parameters.AddWithValue("@QueryType", item.RoleId == 0 ? 1 : 2);
            var result = await DatabaseHelper.ExecNonQueryAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@QueryType", 3);
            var result = await DatabaseHelper.ExecNonQueryAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public bool IsExist(string code)
        {
            var sql = string.Format("SELECT [dbo].[fnIsRoleExist]('{0}')", code);
            var result = DatabaseHelper.ReturnText(sql, Properties.Settings.Default.UserConnectionString);
            return result.Length > 0;
        }
    }
}
