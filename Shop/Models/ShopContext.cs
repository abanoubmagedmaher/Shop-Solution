using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class ShopContext:DbContext
    {
        #region db_Tables
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; } 
        #endregion

        #region Connection and Default Contractor
        public ShopContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=Shop_db;Trusted_Connection=True ;Encrypt=False"
                );
            base.OnConfiguring(optionsBuilder);
        } 
        #endregion
    }
}
