using System.Linq;
using UserAccess.Utilities;

namespace UserAccess
{
    public class SampleClass
    {
        private void SampleFormLoad()
        {

            //AccessMatrix resides in UserAccess.Utilities
            //you can use asynchronous method
            //var result = await AccessMatrix.GetUserAccessAsync(1);//Sample User Id = 1
            var result = AccessMatrix.GetUserAccess(1);//Sample User Id = 1
            var generalSettingsAccess = result.FirstOrDefault(a => a.ModuleCode == "SGS"); //SGS is the module code for General Settings

            //Modular Access Are the Following
            //CanAdd 
            //CanEdit 
            //CanSave 
            //CanDelete 
            //CanSearch 
            //CanPrint 
            //CanExport 
            //CanAccess 
            var isCanAccess = generalSettingsAccess.CanAccess; //Meaning the user can access the module(or general settings tab)
        }
    }
}
