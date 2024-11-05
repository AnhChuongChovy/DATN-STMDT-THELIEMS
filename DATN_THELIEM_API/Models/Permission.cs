namespace DATN_THELIEM_API.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public ICollection<Role_Permission> Role_Permissions { get; set; }
    }
}
