using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bankomat.Models;

namespace Bankomat.DAL
{
    public class BankomatInitializer : DropCreateDatabaseIfModelChanges<BankomatContext>
    {
        protected override void Seed(BankomatContext context)
        {
            var atms = new List<Atm>
            {
                new Atm { Bills100 = 50, Bills500 = 20, Receipts = 1000 }
            };

            atms.ForEach(c => context.Atms.Add(c));
            context.SaveChanges();

         
        }
    }
}