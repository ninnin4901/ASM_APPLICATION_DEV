﻿using ASM_APPLICATION_DEV.Models;
using ASM_APPLICATION_DEV.Utils;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM_APPLICATION_DEV.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "dasdasdqw-3b7d-4bad-9bdd-2b0d7b3dcb6d",
                Name = Role.CUSTOMER,
                ConcurrencyStamp = "1",
                NormalizedName = Role.CUSTOMER
            },
            new IdentityRole()
            {
                Id = "qweqwe21-3b7d-4bad-9bdd-2b0d7b3d23423",
                Name = Role.ADMIN,
                ConcurrencyStamp = "2",
                NormalizedName = Role.ADMIN
            },
            new IdentityRole()
            {
                Id = "gdffdgf3-3b7d-4bad-9bdd-2b0d7basd23",
                Name = Role.STORE_OWNER,
                ConcurrencyStamp = "3",
                NormalizedName = Role.STORE_OWNER
            }
            );
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { set; get; }
        public DbSet<Order>? Orders { set; get; }
        public DbSet<OrderDetail>? OrderDetails { set; get; }
    }
}