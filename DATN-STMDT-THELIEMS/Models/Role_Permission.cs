namespace DATN_STMDT_THELIEMS.Models
{
    public class Role_Permission
    {
        public int Id { get; set; }
        public int Role_id { get; set; }
        public Role Role { get; set; }

        // Foreign key for Permission
        public int Permission_id { get; set; }
        public Permission Permission { get; set; }
    }
}
