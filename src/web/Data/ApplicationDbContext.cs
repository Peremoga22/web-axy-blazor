using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using web.EF.Models;
using web.Extension;

namespace web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            if (!string.IsNullOrEmpty(Database.GetDbConnection().ConnectionString))
            {
                ConnectionString.Value = Database.GetDbConnection().ConnectionString;
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
    }
}
