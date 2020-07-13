using Reports;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserAccess.Models;

namespace UserAccess.Services
{
    public class ModuleServices
    {
        private const string StoredProcedure = "[dbo].[spModules]";
        public async Task<IEnumerable<ModuleModel>> GetAllModules()
        {
            var items = new List<ModuleModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);

            if (result != null)
            {
                foreach (DataRow dr in result.Rows)
                {
                    var item = new ModuleModel
                    {
                        ModuleId = int.Parse(dr["ModuleId"].ToString()),
                        Code = dr["Code"].ToString(),
                        Description = dr["Description"].ToString(),
                        Type = dr["Type"].ToString(),
                    };
                    items.Add(item);
                }
            }
            return items;
        }

        public DataTable GetAllModulesDataTable()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result = DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public DataTable GetModuleDetails(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@QueryType", 4);
            var result = DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> Save(ModuleModel item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", item.ModuleId);
            cmd.Parameters.AddWithValue("@Code", item.Code);
            cmd.Parameters.AddWithValue("@Description", item.Description);
            cmd.Parameters.AddWithValue("@Type", item.Type);
            cmd.Parameters.AddWithValue("@UserId", Properties.Settings.Default.CurrentUserId);
            cmd.Parameters.AddWithValue("@QueryType", item.ModuleId == 0 ? 1 : 2);
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
            var sql = string.Format("SELECT [dbo].[fnIsModuleExist]('{0}')", code);
            var result = DatabaseHelper.ReturnText(sql, Properties.Settings.Default.UserConnectionString);
            return result.Length > 0;
        }
    }
}
