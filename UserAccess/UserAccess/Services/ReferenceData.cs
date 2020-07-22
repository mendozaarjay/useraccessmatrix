using Reports;
using System.Data;

namespace UserAccess
{
    public static class ReferenceData
    {
        public static  DataTable ModuleTypes()
        {
            var sql = "SELECT * FROM  [dbo].[fnGetAllModuleTypes]() [fgamt]";
            var result =  DatabaseHelper.LoadDataTable(sql, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public static DataTable Roles()
        {
            var sql = "SELECT * FROM [dbo].[fnGetAllRoles]() [fgar]";
            var result =  DatabaseHelper.LoadDataTable(sql, Properties.Settings.Default.UserConnectionString);
            return result;
        }
        public static DataTable Modules()
        {
            var sql = "SELECT * FROM  [dbo].[fnGetAllModules]() [f] ORDER BY [f].[Type], [f].[ModuleId]";
            var result =  DatabaseHelper.LoadDataTable(sql, Properties.Settings.Default.UserConnectionString);
            return result;
        }
    }
}
