using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;    //Not currently needed. Here just in case.
using System.Data.Entity;

namespace Gathering.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext()
            : base("Gathering")
        { }
        public DbSet<Platform> Platforms { get; set; }      //Copy these and make them public for new tables.
        public DbSet<Member> Members { get; set; }

        //Paypal stuff

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
    }
}
