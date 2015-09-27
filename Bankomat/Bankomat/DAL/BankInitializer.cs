using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bankomat.Models;

namespace Bankomat.DAL
{
    public class BankInitializer : DropCreateDatabaseIfModelChanges<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            var customers = new List<Customer>
            {

            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
            

        }
    }
}