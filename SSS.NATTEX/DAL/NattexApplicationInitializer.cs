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
                new ApplicationUser {ApplicationRoleID = 1, UserName = "admin", Password="admin", FirstName = "Winston", LastName="Williams", Email="winston.nattex@gmail.com",
                    IsActive = true, CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new ApplicationUser {ApplicationRoleID = 2, UserName = "developer", Password="password", FirstName = "Neil", LastName="Slambert", Email="slambert.sofware@gmail.com",
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new ApplicationUser {ApplicationRoleID = 3, UserName = "user", FirstName = "Anna", Password="password", LastName="Anna", Email="nattexfuneralscheme@gmail.com",
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

            var avbobAgeGroups = new List<AvbobPendingQuotationAgeGroup>
            {

                new AvbobPendingQuotationAgeGroup {StartAge = 0, EndAge = 64, AgeGroup = "0 To 64 Years", Description = "Members up to age of 64 years", IsActive = true, CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationAgeGroup {StartAge = 65, EndAge = 70, AgeGroup = "65 To 70 Years", Description = "Members from the age of 64 years up to age of 70 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationAgeGroup {StartAge = 70, EndAge = 84, AgeGroup = "75 To 84 Years", Description = "Members from the age of 75 years up to age of 84 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationAgeGroup {StartAge = 85, EndAge = 1000, AgeGroup = "85 Years and older", Description = "Members from age 85 years and older", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationAgeGroup {StartAge = 0, EndAge = 18, AgeGroup = "0 To 18 Years", Description = "Extended children up to 18 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1}
            };

            avbobAgeGroups.ForEach(avbobAgeGroup => context.AvbobPendingQuotationAgeGroups.Add(avbobAgeGroup));
            context.SaveChanges();

            var avbobPlans = new List<AvbobPendingQuotationPlan>
            {
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan A", PlanDescription = "Plan A - for members up to the age of 64 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan B", PlanDescription = "Plan B - for members up to the age of 64 years", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan C", PlanDescription = "Plan C - for members up to the age of 64 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan D", PlanDescription = "Plan D - for members up to the age of 64 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},

                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan E", PlanDescription = "Plan E - for members up to the age of 64 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan F", PlanDescription = "Plan F - for members up to the age of 64 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan G", PlanDescription = "Plan G - for members up to the age of 64 years", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 1, PlanName = "Plan H", PlanDescription = "Plan H - for members up to the age of 64 years", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},

                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 2, PlanName = "Plan I", PlanDescription = "Plan I - for members from the age of 64 years up to the age of 74 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID =2, PlanName = "Plan J", PlanDescription = "Plan J - for members from the age of 64 years up to the age of 74 years", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 2,PlanName = "Plan K", PlanDescription = "Plan K - for members from the age of 64 years up to the age of 74 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()),CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 2, PlanName = "Plan L",PlanDescription = "Plan L - for members from the age of 64 years up to the age of 74 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},

                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 3, PlanName = "Plan M", PlanDescription = "Plan M - for members from the age of 75 years up to the age of 84 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID =3, PlanName = "Plan N", PlanDescription = "Plan N - for members from the age of 75 years up to the age of 84 years", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 3,PlanName = "Plan O", PlanDescription = "Plan O - for members from the age of 75 years up to the age of 84 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()),CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 3, PlanName = "Plan P",PlanDescription = "Plan P - for members from the age of 75 years up to the age of 84 years", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},

                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 4, PlanName = "Plan Q", PlanDescription = "Plan Q - for members from the age of 85 years and older", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 4, PlanName = "Plan R", PlanDescription = "Plan R - for members from the age of 85 years and older", IsActive = true,
                    CreateDate =  DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 4,PlanName = "Plan S", PlanDescription = "Plan S - for members from the age of 85 years and older", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()),CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 4, PlanName = "Plan T",PlanDescription = "Plan T - for members from the age of 85 years and older", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},

                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 5,PlanName = "Extended Cover 1", PlanDescription = "Extended Cover 1", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()),CreateUserID = 1},
                new AvbobPendingQuotationPlan {AvbobPendingQuotationAgeGroupID = 5, PlanName = "Extended Cover 2",PlanDescription = "Extended Cover 2", IsActive = true,
                    CreateDate = DateTime.Parse(DateTime.Today.ToString()), CreateUserID = 1},
            };

            avbobPlans.ForEach(avbobPlan => context.AvbobPendingQuotationPlans.Add(avbobPlan));
            context.SaveChanges();

            var avbobMemberUnitTypes = new List<AvbobPendingQuotationMemberUnitType>
            {
                  new AvbobPendingQuotationMemberUnitType {Name ="Single", Description = "Memeber as Single Applicant, with no spouce or dependants", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },
                  new AvbobPendingQuotationMemberUnitType {Name ="Family", Description = "Member as Family Applicant, with either spouce and or dependants", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },
                  new AvbobPendingQuotationMemberUnitType {Name ="Extended Child", Description = "Extended Child", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },
            };

            avbobMemberUnitTypes.ForEach(memberType => context.AvbobPendingQuotationMemberUnitTypes.Add(memberType));
            context.SaveChanges();

            var avbobPremiums = new List<AvbobPendingQuotationPolicyPremium>
            {
                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 1, AvbobPendingQuotationMemberUnitTypeID=2, MemberCover = 10000M, SpouseCover = 10000M, Child14To21YearsCover=10000M, Child6To13YearsCover=5000M, Child1To5YearsCover=3500M, ChildStillBornTo11MonthsCover=2500M, StartAge=0, EndAge = 64, MonthlyMemberPremium=17.96M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=4.04M, TotalMonthlyMemberPremium=22.00M, CompanyMemberPremium=35.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 2, AvbobPendingQuotationMemberUnitTypeID=2, MemberCover = 15000M, SpouseCover = 15000M, Child14To21YearsCover=10000M, Child6To13YearsCover=5000M, Child1To5YearsCover=3500M, ChildStillBornTo11MonthsCover=2500M, StartAge=0, EndAge = 64, MonthlyMemberPremium=24.43M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=5.72M, TotalMonthlyMemberPremium=31.15M, CompanyMemberPremium=40.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 3, AvbobPendingQuotationMemberUnitTypeID=2, MemberCover = 20000M, SpouseCover = 20000M, Child14To21YearsCover=10000M, Child6To13YearsCover=5000M, Child1To5YearsCover=3500M, ChildStillBornTo11MonthsCover=2500M, StartAge=0, EndAge = 64, MonthlyMemberPremium=32.90M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=7.40M, TotalMonthlyMemberPremium=40.30M, CompanyMemberPremium=45.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 4, AvbobPendingQuotationMemberUnitTypeID=2,  MemberCover = 30000M, SpouseCover = 30000M, Child14To21YearsCover=20000M, Child6To13YearsCover=10000M, Child1To5YearsCover=5000M, ChildStillBornTo11MonthsCover=3500M, StartAge=0, EndAge = 64, MonthlyMemberPremium=50.68M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=11.40M, TotalMonthlyMemberPremium=62.08M, CompanyMemberPremium=65.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },


                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 5, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 10000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M,  StartAge=0, EndAge = 64, MonthlyMemberPremium=7.47M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=1.68M, TotalMonthlyMemberPremium=9.15M, CompanyMemberPremium=20.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 6, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 15000M, SpouseCover = 0M,  Child14To21YearsCover=0M, Child6To13YearsCover=0M,  Child1To5YearsCover=0M,  ChildStillBornTo11MonthsCover=0M,  StartAge=0, EndAge = 64, MonthlyMemberPremium=11.20M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=2.52M, TotalMonthlyMemberPremium=13.72M, CompanyMemberPremium=22.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 7, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 20000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M, StartAge=0, EndAge = 64, MonthlyMemberPremium=14.93M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=3.35M, TotalMonthlyMemberPremium=18.28M, CompanyMemberPremium=25.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 1, AvbobPendingQuotationPlanID = 8, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 30000M, SpouseCover = 0M,  Child14To21YearsCover=0M,  Child6To13YearsCover=0M, Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=3500M, StartAge=0, EndAge = 64, MonthlyMemberPremium=22.40M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=5.04M, TotalMonthlyMemberPremium=27.44M, CompanyMemberPremium=30.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },


                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 2, AvbobPendingQuotationPlanID = 9, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 10000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M,  StartAge=65, EndAge = 74, MonthlyMemberPremium=27.96M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=6.29M, TotalMonthlyMemberPremium=34.25M, CompanyMemberPremium=40.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 2, AvbobPendingQuotationPlanID = 10, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 15000M, SpouseCover = 0M,  Child14To21YearsCover=0M, Child6To13YearsCover=0M,  Child1To5YearsCover=0M,  ChildStillBornTo11MonthsCover=0M,  StartAge=65, EndAge = 74, MonthlyMemberPremium=41.94M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=9.43M, TotalMonthlyMemberPremium=51.37M, CompanyMemberPremium=52.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 2, AvbobPendingQuotationPlanID = 11, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 20000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M, StartAge=65, EndAge = 74,  MonthlyMemberPremium=55.92M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=12.58M, TotalMonthlyMemberPremium=68.50M, CompanyMemberPremium=69.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 2, AvbobPendingQuotationPlanID = 12, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 30000M, SpouseCover = 0M,  Child14To21YearsCover=0M,  Child6To13YearsCover=0M, Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=3500M, StartAge=65, EndAge = 74,  MonthlyMemberPremium=83.88M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=18.87M, TotalMonthlyMemberPremium=102.75M, CompanyMemberPremium=105.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },



                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 3, AvbobPendingQuotationPlanID = 13, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 10000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M,  StartAge=75, EndAge = 84, MonthlyMemberPremium=49.21M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=11.07M, TotalMonthlyMemberPremium=60.28M, CompanyMemberPremium=65.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 3, AvbobPendingQuotationPlanID = 14, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 15000M, SpouseCover = 0M,  Child14To21YearsCover=0M, Child6To13YearsCover=0M,  Child1To5YearsCover=0M,  ChildStillBornTo11MonthsCover=0M,  StartAge=75, EndAge = 84, MonthlyMemberPremium=73.82M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=16.60M, TotalMonthlyMemberPremium=90.42M, CompanyMemberPremium=95.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 3, AvbobPendingQuotationPlanID = 15, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 20000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M, StartAge=75, EndAge = 84,  MonthlyMemberPremium=98.43M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=22.14M, TotalMonthlyMemberPremium=120.57M, CompanyMemberPremium=125.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 3, AvbobPendingQuotationPlanID = 16, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 30000M, SpouseCover = 0M,  Child14To21YearsCover=0M,  Child6To13YearsCover=0M, Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=3500M, StartAge=75, EndAge = 84,  MonthlyMemberPremium=147.94M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=33.28M, TotalMonthlyMemberPremium=181.22M, CompanyMemberPremium=185.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },


                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 4, AvbobPendingQuotationPlanID = 17, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 10000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M,  StartAge=85, EndAge = 1000, MonthlyMemberPremium=117.24M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=26.37M, TotalMonthlyMemberPremium=143.61M, CompanyMemberPremium=150M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 4, AvbobPendingQuotationPlanID = 18, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 15000M, SpouseCover = 0M,  Child14To21YearsCover=0M, Child6To13YearsCover=0M,  Child1To5YearsCover=0M,  ChildStillBornTo11MonthsCover=0M,  StartAge=85, EndAge = 1000, MonthlyMemberPremium=175.86M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=39.56M, TotalMonthlyMemberPremium=215.42M, CompanyMemberPremium=220.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 4, AvbobPendingQuotationPlanID = 19, AvbobPendingQuotationMemberUnitTypeID=1, MemberCover = 20000M, SpouseCover = 0M, Child14To21YearsCover=0M,  Child6To13YearsCover=0M,  Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=0M, StartAge=85, EndAge = 1000, MonthlyMemberPremium=234.48M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=52.78M, TotalMonthlyMemberPremium=287.23M, CompanyMemberPremium=295M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },

                new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 4, AvbobPendingQuotationPlanID = 20, AvbobPendingQuotationMemberUnitTypeID=1,  MemberCover = 30000M, SpouseCover = 0M,  Child14To21YearsCover=0M,  Child6To13YearsCover=0M, Child1To5YearsCover=0M, ChildStillBornTo11MonthsCover=3500M, StartAge=85, EndAge = 1000, MonthlyMemberPremium=351.72M, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=79.13M, TotalMonthlyMemberPremium=430.85M, CompanyMemberPremium=440.00M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },


               new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 5, AvbobPendingQuotationPlanID = 21, AvbobPendingQuotationMemberUnitTypeID=3,  ExtendedChildUpTo18YearsCover = 5000M, MonthlyExtendedChildRiskPremium = 5.00M,  StartAge=0, EndAge = 18, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=1.25M, TotalMonthlyMemberPremium=6.12M, CompanyMemberPremium=10M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 },


               new AvbobPendingQuotationPolicyPremium {AvbobPendingQuotationAgeGroupID = 5, AvbobPendingQuotationPlanID = 22, AvbobPendingQuotationMemberUnitTypeID=3, ExtendedChildUpTo18YearsCover = 10000M, MonthlyExtendedChildRiskPremium = 10.00M,  StartAge=0, EndAge = 18, MonthlyMemberCommissionPercentage = 22.50M, MonthlyMemberCommission=2.25M, TotalMonthlyMemberPremium=12.25M, CompanyMemberPremium=15M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1 }

            };


            avbobPremiums.ForEach(premium => context.AvbobPendingQuotationPolicyPremiums.Add(premium));
            context.SaveChanges();

            var expiries = new List<LibertyPendingQuotationParameter>
            {
                new LibertyPendingQuotationParameter {QuotationValidDays = 30, NumMonthlyJoiningFeeInstallments = 3, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
            };

            expiries.ForEach(expiry => context.LibertyPendingQuotationParameters.Add(expiry));
            context.SaveChanges();

            var covers = new List<LibertyPolicyCover>
            {
                new LibertyPolicyCover {Amount = 3000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 5000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 6000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 7500M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyCover {Amount = 8000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyCover {Amount = 10000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 15000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 18000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 20000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyCover {Amount = 25000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyCover {Amount = 30000M ,IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            covers.ForEach(cover => context.LibertyPolicyCovers.Add(cover));
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

            var policySchemeTypes = new List<LibertyPolicySchemeType>
            {
                new LibertyPolicySchemeType {PricingModelID = 1, Name = "Single", Description = "Individual Schemes: Single", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicySchemeType {PricingModelID = 1, Name = "Single Parent", Description = "Individual Schemes: Single Parent", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicySchemeType {PricingModelID = 1, Name = "Married", Description = "Individual Schemes: Married", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicySchemeType {PricingModelID = 1, Name = "Family", Description = "Individual Schemes: Family", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicySchemeType {PricingModelID = 1, Name = "Society", Description = "Society Schemes: 1 + Schemes", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };

            policySchemeTypes.ForEach(schemeType => context.LibertyPolicySchemeTypes.Add(schemeType));
            context.SaveChanges();


            var policySchemes = new List<LibertyPolicyScheme>
            {
                // Scheme 1 - 3
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5, Name = "1 + 13 Member < 65 Years", Description = "Society Scheme: 1 + 13 Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 9  Member < 65 Years", Description = "Society Scheme: 1 + 9  Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 5  Member < 65 Years", Description = "Society Scheme: 1 + 5  Members with age less than 65 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 4 - 6
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 13 Member 65 - 70 Years", Description = "Society Scheme: 1 + 13 Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 9  Member 65 - 70 Years", Description = "Society Scheme: 1 + 9  Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5, Name = "1 + 5  Member 65 - 70 Years", Description = "Society Scheme: 1 + 5  Members with age 65 - 70 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 7 - 9
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 13 Member 71 - 74 Years", Description = "Society Scheme: 1 + 13 Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 9  Member 71 - 74 Years", Description = "Society Scheme: 1 + 9  Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "1 + 5  Member 71 - 74 Years", Description = "Society Scheme: 1 + 5  Members with age 71 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 10
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5,  Name = "75 to 84 years", Description = "Single Scheme: Members with age 75 to 84 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                 // Scheme 11
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5, Name = "85 to 99 years", Description = "Single Scheme: Members with age 85 to 99 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 12
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 5, Name = "Older than 99 years", Description = "Single Scheme: Members with age older than 99 years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 13
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 1, Name = "Single: 18 - 64 Years", Description = "Single Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                
                // Scheme 14
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 1, Name = "Single: 65 - 74 Years", Description = "Single Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                // Scheme 15
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 1, Name = "Single: 75 - 84 Years", Description = "Single Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                
                // Scheme 16
                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 1, Name = "Single: 85 - 99 Years", Description = "Single Scheme: 85 - 99 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},



                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 2, Name = "Single Parent: 18 - 64 Years", Description = "Single Parent Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 2, Name = "Single Parent: 65 - 74 Years", Description = "Single Parent Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 2, Name = "Single Parent: 75 - 84 Years", Description = "Single Parent Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 3, Name = "Married 18 - 64 Years", Description = "Married Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 3, Name = "Married 65 - 74 Years", Description = "Married Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 3, Name = "Married 75 - 84 Years", Description = "Married Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 4, Name = "Family 18 - 64 Years", Description = "Family Scheme: 18 - 64 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 4, Name = "Family 65 - 74 Years", Description = "Family Scheme: 65 - 74 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyScheme {PricingModelID = 1, LibertyPolicySchemeTypeID = 4, Name = "Family 75 - 84 Years", Description = "Family Scheme: 75 - 84 Years", IsActive = true,
                    CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

            };

            policySchemes.ForEach(scheme => context.LibertyPolicySchemes.Add(scheme));
            context.SaveChanges();


            var premiums = new List<LibertyPolicyPremium>
            {

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 3000M,  PremiumAmount=70M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 5000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 7500M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 10000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 15000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 1, StartAge= 0, EndAge=65, CoverAmount= 20000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2,  StartAge= 0, EndAge=65, CoverAmount= 3000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2, StartAge= 0, EndAge=65,  CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2, StartAge= 0, EndAge=65, CoverAmount= 7500M,  PremiumAmount=110M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2, StartAge= 0, EndAge=65,  CoverAmount= 10000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2,StartAge= 0, EndAge=65, CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 2, StartAge= 0, EndAge=65, CoverAmount= 20000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 3000M,  PremiumAmount=50M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65, CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 7500M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65, CoverAmount= 10000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 20000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 3, StartAge= 0, EndAge=65,  CoverAmount= 20000M,  PremiumAmount=290M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 7500M,  PremiumAmount=220M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 4, StartAge= 65, EndAge=70, CoverAmount= 20000M,  PremiumAmount=590M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 3000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70, CoverAmount= 7500M,  PremiumAmount=160M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=210M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=290M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 5, StartAge= 65, EndAge=70, CoverAmount= 20000M,  PremiumAmount=370M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 3000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 5000M,  PremiumAmount=120M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 7500M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 10000M,  PremiumAmount=190M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 15000M,  PremiumAmount=260M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 20000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 25000M,  PremiumAmount=420M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 6,  StartAge= 65, EndAge=70,  CoverAmount= 30000M,  PremiumAmount=500M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7, StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=350M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 10000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7, StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=660M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 7,  StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=870M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74,CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=340M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 8,  StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=450M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 3000M,  PremiumAmount=90M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 5000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 7500M,  PremiumAmount=160M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 10000M,  PremiumAmount=240M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 15000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9,StartAge= 71, EndAge=74, CoverAmount= 20000M,  PremiumAmount=410M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 25000M,  PremiumAmount=510M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 9, StartAge= 71, EndAge=74, CoverAmount= 30000M,  PremiumAmount=600M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 10,StartAge= 75, EndAge=84, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 10, StartAge= 75, EndAge=84, CoverAmount= 5000M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 6000M,  PremiumAmount=180M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 8000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 10,StartAge= 75, EndAge=84,  CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 11, StartAge= 85, EndAge=99, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 11,  StartAge= 85, EndAge=99,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 11, StartAge= 85, EndAge=99,   CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 11, StartAge= 85, EndAge=99,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 11, StartAge= 85, EndAge=99,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12,  StartAge= 100, EndAge=1000,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12,  StartAge= 100, EndAge=1000,  CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,  CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 12, StartAge= 100, EndAge=1000,   CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},


                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 3000M,  PremiumAmount=30M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13,  StartAge= 18, EndAge=64, CoverAmount= 5000M,  PremiumAmount=40M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64,  CoverAmount= 6000M,  PremiumAmount=45M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 8000M,  PremiumAmount=50M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13 ,StartAge= 18, EndAge=64,  CoverAmount= 10000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 15000M,  PremiumAmount=85M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13,  StartAge= 18, EndAge=64, CoverAmount= 18000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64,  CoverAmount= 20000M,  PremiumAmount=130M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13, StartAge= 18, EndAge=64, CoverAmount= 25000M,  PremiumAmount=135M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 13 ,StartAge= 18, EndAge=64,  CoverAmount= 30000M,  PremiumAmount=140M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 3000M,  PremiumAmount=60M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 5000M,  PremiumAmount=80M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 6000M,  PremiumAmount=90M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74, CoverAmount= 8000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 10000M,  PremiumAmount=130M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 14, StartAge= 65, EndAge=74,  CoverAmount= 15000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 3000M,  PremiumAmount=100M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 5000M,  PremiumAmount=170M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 15, StartAge= 75, EndAge=84,  CoverAmount= 6000M,  PremiumAmount=180M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 15, StartAge= 75, EndAge=84, CoverAmount= 8000M,  PremiumAmount=200M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 15, StartAge= 75, EndAge=84,  CoverAmount= 10000M,  PremiumAmount=250M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},

                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 3000M,  PremiumAmount=150M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 5000M,  PremiumAmount=230M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 16, StartAge= 85, EndAge=89,  CoverAmount= 6000M,  PremiumAmount=280M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 16, StartAge= 85, EndAge=89, CoverAmount= 8000M,  PremiumAmount=320M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new LibertyPolicyPremium {PricingModelID = 1, LibertPolicySchemeID = 16, StartAge= 85, EndAge=89,  CoverAmount= 10000M,  PremiumAmount=380M,
                    IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            premiums.ForEach(premium => context.LibertyPolicyPremiums.Add(premium));
            context.SaveChanges();

            var quotationTypes = new List<QuotationType>
            {
                new QuotationType {TypeName = "Avbob Pricing Quotation", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1},
                new QuotationType {TypeName = "Liberty Pricing Quotation", IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
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

            var joiningFees = new List<JoiningFee>
            {
                new JoiningFee {Fee = 50M, IsActive = true, CreateDate = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")), CreateUserID = 1}
            };
            joiningFees.ForEach(joiningFee => context.JoiningFees.Add(joiningFee));
            context.SaveChanges();
        }
    }
}
