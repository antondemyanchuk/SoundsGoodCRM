using Microsoft.EntityFrameworkCore;
using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.InstrumentModels;
using SoundsGoodCRM.DAO.OrderModels;
using SoundsGoodCRM.DAO.UserModels;

namespace SoundsGoodCRM.DAO
{
    public class SampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthorization> UsersAuthorization { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderTask> OrderTasks { get; set; }
        public DbSet<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<InstrumentTuning> InstrumentTunings { get; set; }
        public DbSet<InstrumentModel> InstrumentModels { get; set; }
        public DbSet<InstrumentBrand> InstrumentBrands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustomerPostInfo> CustomerPostInfos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SoundsGood;Integrated Security=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.Contact)
                .WithOne(contact => contact.Customer)
                .HasForeignKey<Customer>(customer => customer.CustomerContactsId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.PostInfo)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.CustomerPostInfoId);

            modelBuilder.Entity<InstrumentModel>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.InstrumentModels)
                .HasForeignKey(m => m.BrandId);


            modelBuilder.Entity<InstrumentModel>()
                .HasOne(m => m.Type)
                .WithMany(t => t.InstrumentModels)
                .HasForeignKey(m => m.TypeId);

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Instruments)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Model)
                .WithMany(m => m.Instuments)
                .HasForeignKey(i => i.ModelId);

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Tuning)
                .WithMany(t => t.Instruments)
                .HasForeignKey(i => i.TuneId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Instrument)
                .WithMany(i => i.Orders)
                .HasForeignKey(o => o.InstrumentId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserContact)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.UserContactsId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserPermission)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.UserPermissionsId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserAuthorization)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.UserAuthorizationId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Instrument)
                .WithMany(i => i.Orders)
                .HasForeignKey(o => o.InstrumentId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderStatuses)
                .WithMany(s => s.Orders)
                .UsingEntity<OrderStatusTimeLog>(
                    join => join
                        .HasOne(j => j.OrderStatus)
                        .WithMany(s => s.OrderStatusTimeLogs)
                        .HasForeignKey(j => j.StatusId),
                    join => join
                        .HasOne(j => j.Order)
                        .WithMany(o => o.OrderStatusTimeLogs)
                        .HasForeignKey(j => j.OrderId)
                        .OnDelete(DeleteBehavior.Restrict),
                    join => join
                        .HasKey(j => new { j.OrderId, j.StatusId }));

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderTasks)
                .WithMany(t => t.Orders)
                .UsingEntity<OrderTaskJoinClass>(
                    join => join
                        .HasOne(j => j.OrderTask)
                        .WithMany(o => o.TaskJoinClasses)
                        .HasForeignKey(j => j.OrderTaskId),
                    join => join
                        .HasOne(j => j.Order)
                        .WithMany(ot => ot.TaskJoinClasses)
                        .HasForeignKey(j => j.OrderId)
                        .OnDelete(DeleteBehavior.Restrict),
                    join => join
                        .HasKey(j => new { j.OrderId, j.OrderTaskId }));
        }
    }
}

