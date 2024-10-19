using DATN_STMDT_THELIEMS.Models;
using Microsoft.EntityFrameworkCore;
namespace DATN_STMDT_THELIEMS.DATA
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

        
    }
}
    