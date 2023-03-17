using Microsoft.EntityFrameworkCore;
using OrderManager.Domain.Entity;
using OrderManager.Domain.StaticDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CreateDate = new DateTime(2023, 01, 23, 10, 14, 57, 26),
                    Status = StatusSD.Delivery,
                    ClientName = "Viacheslav",
                    OrderPrice = 1049.96m,
                    Address = "Bliżniąt 12/a",
                    City = "Poznań",
                    AdditionalInfo = "Deliver only in extra hard packaging"
                },
                new Order
                {
                    Id = 2,
                    CreateDate = new DateTime(2023, 02, 04, 8, 46, 34, 18),
                    Status = StatusSD.Delivery,
                    ClientName = "LuckyOnEnd",
                    OrderPrice = 499.99m,
                    Address = "Szamarzewskiego 23",
                    City = "Wroclaw",
                    AdditionalInfo = "shipping cost is calculated separately"
                },
                new Order
                {
                    Id = 3,
                    CreateDate = new DateTime(2023, 01, 23, 10, 14, 57, 26),
                    Status = StatusSD.Confirm,
                    ClientName = "KaterinaMaslova",
                    OrderPrice = 600.00m,
                    Address = "Bliżniąt 12/a",
                    City = "Poznań",
                    AdditionalInfo = " "
                },
                new Order
                {
                    Id = 4,
                    CreateDate = new DateTime(2023, 01, 23, 10, 14, 57, 26),
                    Status = StatusSD.Delivery,
                    ClientName = "EhorDev",
                    OrderPrice = 299.00m,
                    Address = "Slowackiego 37",
                    City = "Poznań",
                    AdditionalInfo = " "
                },
                new Order
                {
                    Id = 5,
                    CreateDate = new DateTime(2023, 01, 23, 10, 14, 57, 26),
                    Status = StatusSD.Confirm,
                    ClientName = "Sławek274",
                    OrderPrice = 356.00m,
                    Address = "",
                    City = "Gdańsk",
                    AdditionalInfo = " "
                }
                );


            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine
                {
                    Id = 1,
                    OrderID = 1,
                    Product = "Battery",
                    Price = 262.49m
                },
                new OrderLine
                {
                    Id = 2,
                    OrderID = 1,
                    Product = "Battery",
                    Price = 262.49m
                },
                new OrderLine
                {
                    Id = 3,
                    OrderID = 1,
                    Product = "Battery",
                    Price = 262.49m
                },
                new OrderLine
                {
                    Id = 4,
                    OrderID = 1,
                    Product = "Battery",
                    Price = 262.49m
                },
                new OrderLine
                {
                    Id = 5,
                    OrderID = 2,
                    Product = "Smart Watch",
                    Price = 499.99m
                },
                new OrderLine
                {
                    Id = 6,
                    OrderID = 3,
                    Product = "Wazon dla kwitów",
                    Price = 300.00m
                },
                new OrderLine
                {
                    Id = 7,
                    OrderID = 3,
                    Product = "Wazon dla kwitów",
                    Price = 300.99m
                },
                new OrderLine
                {
                    Id = 8,
                    OrderID = 4,
                    Product = "Zara - Kurtka Pikowana",
                    Price = 299.99m
                },
                new OrderLine
                {
                    Id = 9,
                    OrderID = 5,
                    Product = "Mysz LOGITECH G502 Hero",
                    Price = 299.99m
                },
                new OrderLine
                {
                    Id = 10,
                    OrderID = 5,
                    Product = "Mysz LOGITECH G102",
                    Price = 299.99m
                }
                );

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
