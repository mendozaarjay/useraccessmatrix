using Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccess.Helpers;
using UserAccess.Models;

namespace UserAccess.Utilities
{
    public static class AccessMatrix
    {
        public static IEnumerable<UserAccessItem> GetUserAccess(int userid)
        {
            List<UserAccessItem> items = new List<UserAccessItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[spGetUserAccessMatrix]";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserId", userid);
            var result = DatabaseHelper.ExecGetData(cmd, Properties.Settings.Default.UserConnectionString);
            if(result != null)
            {
                foreach(DataRow dr in result.Rows)
                {
                    var item = new UserAccessItem
                    {
                        UserId = int.Parse(dr["UserId"].ToString()),
                        Username = dr["Username"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        RoleId = int.Parse(dr["RoleId"].ToString()),
                        RoleCode = dr["RoleCode"].ToString(),
                        RoleDescription = dr["RoleDescription"].ToString(),
                        ModuleId = int.Parse(dr["ModuleId"].ToString()),
                        ModuleCode = dr["ModuleCode"].ToString(),
                        ModuleDescription = dr["ModuleDescription"].ToString(),
                        TypeId = int.Parse(dr["TypeId"].ToString()),
                        Type = dr["Type"].ToString(),
                        CanAdd = ValueConverter.ConvertToBoolean(dr["CanAdd"].ToString()),
                        CanEdit = ValueConverter.ConvertToBoolean(dr["CanEdit"].ToString()),
                        CanSave = ValueConverter.ConvertToBoolean(dr["CanSave"].ToString()),
                        CanDelete = ValueConverter.ConvertToBoolean(dr["CanDelete"].ToString()),
                        CanSearch = ValueConverter.ConvertToBoolean(dr["CanSearch"].ToString()),
                        CanPrint = ValueConverter.ConvertToBoolean(dr["CanPrint"].ToString()),
                        CanExport = ValueConverter.ConvertToBoolean(dr["CanExport"].ToString()),
                        CanAccess = ValueConverter.ConvertToBoolean(dr["CanAccess"].ToString()),
                    };
                    items.Add(item);
                }
            }

            return items;
        }
        public static async Task<IEnumerable<UserAccessItem>> GetUserAccessAsync(int userid)
        {
            List<UserAccessItem> items = new List<UserAccessItem>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[spGetUserAccessMatrix]";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserId", userid);
            var result = await DatabaseHelper.ExecGetDataAsync(cmd, Properties.Settings.Default.UserConnectionString);
            if (result != null)
            {
                foreach (DataRow dr in result.Rows)
                {
                    var item = new UserAccessItem
                    {
                        UserId = int.Parse(dr["UserId"].ToString()),
                        Username = dr["Username"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        RoleId = int.Parse(dr["RoleId"].ToString()),
                        RoleCode = dr["RoleCode"].ToString(),
                        RoleDescription = dr["RoleDescription"].ToString(),
                        ModuleId = int.Parse(dr["ModuleId"].ToString()),
                        ModuleCode = dr["ModuleCode"].ToString(),
                        ModuleDescription = dr["ModuleDescription"].ToString(),
                        TypeId = int.Parse(dr["TypeId"].ToString()),
                        Type = dr["Type"].ToString(),
                        CanAdd = ValueConverter.ConvertToBoolean(dr["CanAdd"].ToString()),
                        CanEdit = ValueConverter.ConvertToBoolean(dr["CanEdit"].ToString()),
                        CanSave = ValueConverter.ConvertToBoolean(dr["CanSave"].ToString()),
                        CanDelete = ValueConverter.ConvertToBoolean(dr["CanDelete"].ToString()),
                        CanSearch = ValueConverter.ConvertToBoolean(dr["CanSearch"].ToString()),
                        CanPrint = ValueConverter.ConvertToBoolean(dr["CanPrint"].ToString()),
                        CanExport = ValueConverter.ConvertToBoolean(dr["CanExport"].ToString()),
                        CanAccess = ValueConverter.ConvertToBoolean(dr["CanAccess"].ToString()),
                    };
                    items.Add(item);
                }
            }

            return items;
        }
    }
}
