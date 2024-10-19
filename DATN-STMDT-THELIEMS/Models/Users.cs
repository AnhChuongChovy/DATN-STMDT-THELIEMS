namespace DATN_STMDT_THELIEMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public bool IsSeller { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
