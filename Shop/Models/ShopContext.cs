﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class ShopContext:IdentityDbContext<ApplicationUser>
    {
        #region db_Tables
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; } 
        #endregion

        #region Connection and Default Contractor
        public ShopContext() : base()
        {

        }

        public  ShopContext(DbContextOptions options) : base(options)
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
