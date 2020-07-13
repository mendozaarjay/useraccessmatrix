namespace UserAccess.Models
{
    public class UserAccessItem
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleDescription { get; set; }
        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleDescription { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanSave { get; set; }
        public bool CanDelete { get; set; }
        public bool CanSearch { get; set; }
        public bool CanPrint { get; set; }
        public bool CanExport { get; set; }
        public bool CanAccess { get; set; }
    }
}
