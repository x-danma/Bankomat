using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bankomat.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bankomat.DAL
{
    public class BankomatContext : DbContext
    {
        public BankomatContext() : base("BankomatContext")
        {
        }

        public DbSet<Atm> Atms { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}