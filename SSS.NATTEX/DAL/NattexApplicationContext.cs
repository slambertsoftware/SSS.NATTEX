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
        public DbSet<JoiningFee> JoiningFees { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<QuotationType> QuotationTypes { get; set; }
        public DbSet<Century> Centuries { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<LibertyPolicyCover> LibertyPolicyCovers { get; set; }
        public DbSet<LibertyPolicyPremium> LibertyPolicyPremiums { get; set; }
        public DbSet<LibertyPolicyScheme> LibertyPolicySchemes { get; set; }
        public DbSet<LibertyPolicySchemeType> LibertyPolicySchemeTypes { get; set; }

        public DbSet<LibertyPendingQuotation> LibertyPendingQuotations { get; set; }
        public DbSet<LibertyPendingQuotationMember> LibertyPendingQuotationMembers { get; set; }
        public DbSet<LibertyPendingQuotationMemberScheme> LibertyPendingQuotationMemberSchemes { get; set; }
        public DbSet<LibertyPendingQuotationDocument> LibertyPendingQuotationDocuments { get; set; }
        public DbSet<LibertyPendingQuotationMemberGroup> LibertyPendingQuotationMemberGroups { get; set; }
        public DbSet<LibertyPendingQuotationMemberGroupMember> LibertyPendingQuotationMemberGroupMembers { get; set; }
        public DbSet<LibertyPendingQuotationParameter> LibertyPendingQuotationParameters { get; set; }
        

        public DbSet<AvbobAgeGroup> AvbobAgeGroups { get; set; }
        public DbSet<AvbobPlan> AvbobPlans { get; set; }
        public DbSet<AvbobPolicyPremium> AvbobPolicyPremiums { get; set; }
        public DbSet<AvbobPolicyScheme> AvbobPolicySchemes { get; set; }
        public DbSet<AvbobPolicySchemeType> AvbobPolicySchemeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
