using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class NattexApplicationContext : DbContext
    {
        public NattexApplicationContext() : base("name=NattexApplicationContext")
        {

        }

        public DbSet<AdminFee> AdminFees { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Client> Clients { get; set; }


        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JoiningFee> JoiningFees { get; set; }
        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<PolicyCover> PolicyCovers { get; set; }
        public DbSet<PolicyPremium> PolicyPremiums { get; set; }
        public DbSet<PolicyScheme> PolicySchemes { get; set; }
        public DbSet<PolicySchemeType> PolicySchemeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
