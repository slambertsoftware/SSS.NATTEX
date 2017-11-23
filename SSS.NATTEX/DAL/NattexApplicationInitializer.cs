using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class NattexApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NattexApplicationContext>
    {
        protected override void Seed(NattexApplicationContext context)
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Description = "Administrator", IsActive = true, CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new ApplicationRole {Description = "Developer", IsActive = true, CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new ApplicationRole {Description = "User", IsActive = true, CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1}
            };
            roles.ForEach(role => context.ApplicationRoles.Add(role));
            context.SaveChanges();
            var date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            var users = new List<ApplicationUser>
            {
                new ApplicationUser {ApplicationRoleID = 1, UserName = "administrator", Password="password1", FirstName = "Winston", LastName="Williams", Email="winston.nattex@gmail.com",
                    IsActive = true, CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new ApplicationUser {ApplicationRoleID = 2, UserName = "developer", Password="password2", FirstName = "Neil", LastName="Slambert", Email="slambert.sofware@gmail.com",
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new ApplicationUser {ApplicationRoleID = 3, UserName = "user", FirstName = "Anna", Password="password3", LastName="Office", Email="nattexfuneralscheme@gmail.com",
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
            };
            users.ForEach(user => context.ApplicationUsers.Add(user));
            context.SaveChanges();

            var adminFees = new List<AdminFee>
            {
                new AdminFee{Fee = 150M, Description="General Admin Fee", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            adminFees.ForEach(fee => context.AdminFees.Add(fee));
            context.SaveChanges();

            var covers = new List<PolicyCover>
            {
                new PolicyCover {Amount = 3000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 5000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 6000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 7500M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyCover {Amount = 8000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyCover {Amount = 10000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 15000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 18000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 20000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyCover {Amount = 25000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyCover {Amount = 30000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            covers.ForEach(cover => context.PolicyCovers.Add(cover));
            context.SaveChanges();


            var pricingModels = new List<PricingModel>
            {
                new PricingModel {PricingName = "Liberty", Description = "Pricing tables based on Liberty cover tables", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PricingModel {PricingName = "Avbob", Description = "Pricing tables based on Avbob cover tables", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };

            pricingModels.ForEach(pricingModel => context.PricingModels.Add(pricingModel));
            context.SaveChanges();

            var policySchemeTypes = new List<PolicySchemeType>
            {
                new PolicySchemeType {PricingModelID = 1, Name = "Single", Description = "Individual Schemes: Single", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicySchemeType {PricingModelID = 1, Name = "Single Parent", Description = "Individual Schemes: Single Parent", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicySchemeType {PricingModelID = 1, Name = "Married", Description = "Individual Schemes: Married", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicySchemeType {PricingModelID = 1, Name = "Family", Description = "Individual Schemes: Family", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicySchemeType {PricingModelID = 1, Name = "Society", Description = "Society Schemes: 1 + Schemes", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };

            policySchemeTypes.ForEach(schemeType => context.PolicySchemeTypes.Add(schemeType));
            context.SaveChanges();


            var policySchemes = new List<PolicyScheme>
            {
                // Scheme 1 - 3
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5, Name = "1 + 13 Member < 65 Years", Description = "Society Scheme: 1 + 13 Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 9  Member < 65 Years", Description = "Society Scheme: 1 + 9  Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 5  Member < 65 Years", Description = "Society Scheme: 1 + 5  Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 4 - 6
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 13 Member 65 - 70 Years", Description = "Society Scheme: 1 + 13 Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 9  Member 65 - 70 Years", Description = "Society Scheme: 1 + 9  Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5, Name = "1 + 5  Member 65 - 70 Years", Description = "Society Scheme: 1 + 5  Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 7 - 9
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 13 Member 71 - 74 Years", Description = "Society Scheme: 1 + 13 Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 9  Member 71 - 74 Years", Description = "Society Scheme: 1 + 9  Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "1 + 5  Member 71 - 74 Years", Description = "Society Scheme: 1 + 5  Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 10
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5,  Name = "75 to 84 years", Description = "Single Scheme: Members with age 75 to 84 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                 // Scheme 11
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5, Name = "85 to 99 years", Description = "Single Scheme: Members with age 85 to 99 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 12
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 5, Name = "Older than 99 years", Description = "Single Scheme: Members with age older than 99 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 13
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 1, Name = "Single: 18 - 64 Years", Description = "Single Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                
                // Scheme 14
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 1, Name = "Single: 65 - 74 Years", Description = "Single Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 15
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 1, Name = "Single: 75 - 84 Years", Description = "Single Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                
                // Scheme 16
                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 1, Name = "Single: 85 - 99 Years", Description = "Single Scheme: 85 - 99 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},



                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 2, Name = "Single Parent: 18 - 64 Years", Description = "Single Parent Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 2, Name = "Single Parent: 65 - 74 Years", Description = "Single Parent Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 2, Name = "Single Parent: 75 - 84 Years", Description = "Single Parent Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 3, Name = "Married 18 - 64 Years", Description = "Married Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 3, Name = "Married 65 - 74 Years", Description = "Married Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 3, Name = "Married 75 - 84 Years", Description = "Married Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 4, Name = "Family 18 - 64 Years", Description = "Family Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 4, Name = "Family 65 - 74 Years", Description = "Family Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyScheme {PricingModelID = 1, PolicySchemeTypeID = 4, Name = "Family 75 - 84 Years", Description = "Family Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

            };

            policySchemes.ForEach(scheme => context.PolicySchemes.Add(scheme));
            context.SaveChanges();


            var premiums = new List<PolicyPremium>
            {

                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 3000M,  PremiumAmount=70M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 5000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 7500M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 10000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 15000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 20000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 2,  StartAge= 0, EndAge=65, CoverAmount= 3000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 2, StartAge= 0, EndAge=65,  CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 2, StartAge= 0, EndAge=65, CoverAmount= 7500M,  PremiumAmount=110M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 2, StartAge= 0, EndAge=65,  CoverAmount= 10000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 2,StartAge= 0, EndAge=65, CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 2, StartAge= 0, EndAge=65, CoverAmount= 20000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 3000M,  PremiumAmount=50M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65, CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 7500M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65, CoverAmount= 10000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 20000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 20000M,  PremiumAmount=290M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 7500M,  PremiumAmount=220M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 4, StartAge= 65, EndAge=70, CoverAmount= 20000M,  PremiumAmount=590M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 3000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70, CoverAmount= 7500M,  PremiumAmount=160M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=210M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=290M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 5, StartAge= 65, EndAge=70, CoverAmount= 20000M,  PremiumAmount=370M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 3000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 7500M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=190M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 20000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 25000M,  PremiumAmount=420M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 30000M,  PremiumAmount=500M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 7, StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=350M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 10000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 7, StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=660M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=870M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74,CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=90M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=160M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 10000M,  PremiumAmount=240M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9,StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=410M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 25000M,  PremiumAmount=510M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 30000M,  PremiumAmount=600M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 10,StartAge= 75, EndAge=84, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 10, StartAge= 75, EndAge=84, CoverAmount= 5000M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 6000M,  PremiumAmount=180M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 8000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 11, StartAge= 85, EndAge=99, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 11,  StartAge= 85, EndAge=99,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 11, StartAge= 85, EndAge=99,   CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 11, StartAge= 85, EndAge=99,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 11, StartAge= 85, EndAge=99,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12,  StartAge= 100, EndAge=1000,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12,  StartAge= 100, EndAge=1000,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 12, StartAge= 100, EndAge=1000,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 3000M,  PremiumAmount=30M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13,  StartAge= 18, EndAge=64, CoverAmount= 5000M,  PremiumAmount=40M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64,  CoverAmount= 6000M,  PremiumAmount=45M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 8000M,  PremiumAmount=50M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13 ,StartAge= 18, EndAge=64,  CoverAmount= 10000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 15000M,  PremiumAmount=85M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13,  StartAge= 18, EndAge=64, CoverAmount= 18000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64,  CoverAmount= 20000M,  PremiumAmount=130M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 25000M,  PremiumAmount=135M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 13 ,StartAge= 18, EndAge=64,  CoverAmount= 30000M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 3000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 6000M,  PremiumAmount=90M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 8000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 10000M,  PremiumAmount=130M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 5000M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 15, StartAge= 75, EndAge=84,  CoverAmount= 6000M,  PremiumAmount=180M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 8000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 15, StartAge= 75, EndAge=84,  CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new PolicyPremium {PricingModelID = 1, SchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 16, StartAge= 85, EndAge=89,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new PolicyPremium {PricingModelID = 1, SchemeID = 16, StartAge= 85, EndAge=89,  CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            premiums.ForEach(premium => context.PolicyPremiums.Add(premium));
            context.SaveChanges();

            var quotationTypes = new List<QuotationType>
            {
                new QuotationType {TypeName = "Society Scheme Quotation", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new QuotationType {TypeName = "Single Member Quotation", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new QuotationType {TypeName = "Burial Book Quotation", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            quotationTypes.ForEach(quotationType => context.QuotationTypes.Add(quotationType));
            context.SaveChanges();

            var centuries = new List<Century>
            {
                new Century {Year = "19", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new Century {Year = "20", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            centuries.ForEach(century => context.Centuries.Add(century));
            context.SaveChanges();
        }
    }
}
