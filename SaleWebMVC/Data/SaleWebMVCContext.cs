
using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Models;

namespace SaleWebMVC.Data
{
    public class SaleWebMVCContext : DbContext
    {
        public SaleWebMVCContext (DbContextOptions<SaleWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        
    }
}
