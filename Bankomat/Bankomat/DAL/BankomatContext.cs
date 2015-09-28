﻿using System;
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Atm> Atms { get; set; }
        public DbSet<Bank> Banks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}