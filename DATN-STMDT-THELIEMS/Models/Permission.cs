namespace DATN_STMDT_THELIEMS.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public ICollection<Role_Permission> Role_Permissions { get; set; }
    }
}
