using Microsoft.EntityFrameworkCore;
using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core
{
    public class SampleContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAuthorization> CustomerAuthorizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentBrand> InstrumentBrands { get; set; }
        public DbSet<InstrumentModel> InstrumentModels { get; set; }
        public DbSet<InstrumentTune> InstrumentTunes { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
        public DbSet<OrderTask> OrderTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAuthorization> EmployeeAuthorizations { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
        
        }
    }
}
