namespace DATN_STMDT_THELIEMS.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Role_Permission> Role_Permissions { get; set; }
        public ICollection<Users> Users { get; set; }

    }
}
