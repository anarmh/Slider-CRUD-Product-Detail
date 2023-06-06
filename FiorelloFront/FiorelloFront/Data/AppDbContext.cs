using FiorelloFront.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option) 
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<FlowersExpert> FlowersExperts { get; set; }
        public DbSet<Say> Says { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Anar Huseynov",
                    Age= 36
                },
                 new Customer
                 {
                     Id = 2,
                     FullName = "Tunar Huseynli",
                     Age = 36
                 },
                   new Customer
                   {
                       Id = 3,
                       FullName = "Elnar Huseynli",
                       Age = 36
                   }
            );
            modelBuilder.Entity<Setting>().HasData(
              new Setting
              {
                  Id = 1,
                  Key = "HeaderLogo",
                  Value = "logo.png"
              },
               new Setting
               {
                   Id = 2,
                   Key = "Phone",
                   Value = "0505728218"
               },
                 new Setting
                 {
                     Id = 3,
                     Key = "Email",
                     Value = "fiorello@gmail.com"
                 }
          );
        }
    }
}
