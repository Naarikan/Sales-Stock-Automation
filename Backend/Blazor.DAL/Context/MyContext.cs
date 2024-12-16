using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account>Accounts { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Locality> Localities  { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<StockMovement> StockMovements { get; set; }


    }
}
