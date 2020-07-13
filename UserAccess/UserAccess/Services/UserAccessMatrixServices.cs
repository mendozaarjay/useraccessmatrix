using Reports;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserAccess.Models;

namespace UserAccess.Services
{
    public class UserAccessMatrixServices
    {
        private const string StoredProcedure = "[dbo].[spUserAccessMatrix]";
        public DataTable GetUserRoles(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@QueryType", 0);
            var result =  DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> Save(List<UserAccessMatrixModel> items)
        {
            SqlCommand cmd;
            List<SqlCommand> cmdList = new List<SqlCommand>();
            foreach(var item in items)
            {
                cmd = new SqlCommand();
                cmd.CommandText = StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@UserId", item.UserId);
                cmd.Parameters.AddWithValue("@RoleId", item.RoleId);
                cmd.Parameters.AddWithValue("@QueryType", item.Id == 0 ? 1 : 2);
                cmdList.Add(cmd);
            }
            var result = await DatabaseHelper.ExecNonQueryAsync(cmdList, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<string> DeleteData(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@QueryType", 3);
            var result = await DatabaseHelper.ExecNonQueryAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<DataTable> GetAllUsers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@QueryType", 4);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public async Task<DataTable> GetCopyFrom(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@QueryType", 5);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            return result;
        }
    }
}
