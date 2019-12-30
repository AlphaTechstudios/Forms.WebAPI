using Forms.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DA
{
    public class FormsContext : DbContext
    {
        public FormsContext() : base()
        {

        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Forms;Integrated Security=SSPI;");
        }

    }
}
