using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.ViewModel
{
    public class NewProspectiveMemberSchemeViewModel : MainViewModel
    {
        #region fields
        private string _coverAmount;
        private ObservableCollection<ProspectiveMemberScheme> _prospectiveMemberSchemes;
        private ObservableCollection<ProspectiveMemberScheme> _memberSchemeTypes;

        #endregion

        #region properties
        public List<AgeGroup> AgeGroups { get; set; }

        public ObservableCollection<ProspectiveMember> ProspectiveMembers { get; set; }

        public ObservableCollection<ProspectiveMemberScheme> MemberSchemeTypes
        {
            get
            {
                return _memberSchemeTypes;
            }
            set
            {
                _memberSchemeTypes = value;
                this.RaisePropertyChanged("MemberSchemeTypes");
            }
        }

        public ObservableCollection<ProspectiveMemberScheme> ProspectiveMemberSchemes
        {
            get
            {
                return _prospectiveMemberSchemes;
            }
            set
            {
                _prospectiveMemberSchemes = value;
                this.RaisePropertyChanged("ProspectiveMemberSchemes");
            }
        }

        #endregion

        #region constructors
        public string CoverAmount
        {
            get
            {
                return _coverAmount;
            }
            set
            {
                _coverAmount = value;
                this.RaisePropertyChanged("CoverAmount");
            }
        }

        public NewProspectiveMemberSchemeViewModel(string coverAmount)
        {
            this.CoverAmount = coverAmount;
            PopulateSchemeTypes();
        }
        #endregion

        #region methods

        private void PopulateSchemeTypes()
        {
            ProspectiveMemberSchemeTypes schemes = new ProspectiveMemberSchemeTypes();
            this.MemberSchemeTypes = new ObservableCollection<ProspectiveMemberScheme>(schemes.Types);
            if (this.ProspectiveMemberSchemes == null)
            {
                this.ProspectiveMemberSchemes = new ObservableCollection<ProspectiveMemberScheme>();
            }
        }

        public void AddProspectiveMembers(List<ProspectiveMember> members)
        {
            if (this.ProspectiveMembers == null)
            {
                this.ProspectiveMembers = new ObservableCollection<ProspectiveMember>();
            }
            this.ProspectiveMembers = new ObservableCollection<ProspectiveMember>(members);  
        }

        public void ProcessProspectiveMembers()
        {
            DoMemberAgeGrouping();
            DoMemberSchemeGrouping();
        }

        private void DoMemberAgeGrouping()
        {
            if (this.AgeGroups == null)
            {
                this.AgeGroups = new List<AgeGroup>();
            }

            for (int i = 0; i < this.ProspectiveMembers.Count; i++)
            {
                AgeGroup ageGroup = null;
                int index = 0;

                if (this.ProspectiveMembers[i].Age < 65)
                {
                    if (this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "Less than 65 years") == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "Less than 65 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    else
                    {
                        ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "Less than 65 years");
                    }

                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }

                if (this.ProspectiveMembers[i].Age >= 65 && this.ProspectiveMembers[i].Age <= 70)
                {
                    ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "65 to 70 years");
                    if (ageGroup == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "65 to 70 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }

                if (this.ProspectiveMembers[i].Age >= 71 && this.ProspectiveMembers[i].Age <= 74)
                {
                    ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "71 to 74 years");
                    if (ageGroup == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "71 to 74 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }

                if (this.ProspectiveMembers[i].Age >= 75 && this.ProspectiveMembers[i].Age <= 84)
                {
                    ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "75 to 84 years");
                    if (ageGroup == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "75 to 84 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }

                if (this.ProspectiveMembers[i].Age >= 85 && this.ProspectiveMembers[i].Age <= 99)
                {
                    ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "85 to 99 years");
                    if (ageGroup == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "85 to 99 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }


                if (this.ProspectiveMembers[i].Age > 99)
                {
                    ageGroup = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "Greater than 99 years");
                    if (ageGroup == null)
                    {
                        ageGroup = new AgeGroup()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "Greater than 99 years"
                        };
                        this.AgeGroups.Add(ageGroup);
                    }
                    index = this.AgeGroups.IndexOf(ageGroup);
                    this.AgeGroups[index].GroupMembers.Add(this.ProspectiveMembers[i]);
                }
            }
        }

        private void DoMemberSchemeGrouping()
        {
            if ((this.AgeGroups != null) && (this.AgeGroups.Count > 0))
            {
                for (int i = 0; i < this.AgeGroups.Count; i++)
                {
                    if (this.AgeGroups[i].GroupDescription == "Less than 65 years")
                    {
                        while (this.AgeGroups[i].GroupMembers.Count > 0)
                        {
                            if (this.AgeGroups[i].GroupMembers.Count >= 14)
                            {
                                ProcessMemberSchemeTopGroup(i, @"1 + 13 Member < 65 Years", 14);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 10) && (this.AgeGroups[i].GroupMembers.Count < 14))
                            { 
                                ProcessMemberSchemeMiddleGroup(i, @"1 + 9  Member < 65 Years", 14, 10);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 6) && (this.AgeGroups[i].GroupMembers.Count < 10))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member < 65 Years", 10, 6);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count > 0) && (this.AgeGroups[i].GroupMembers.Count < 6))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member < 65 Years", 10, 6);
                            }
                        }
                    }

                    if (this.AgeGroups[i].GroupDescription == "65 to 70 years")
                    {
                        while (this.AgeGroups[i].GroupMembers.Count > 0)
                        {
                            if (this.AgeGroups[i].GroupMembers.Count >= 14)
                            {
                                ProcessMemberSchemeTopGroup(i, @"1 + 13 Member 65 - 70 Years", 14);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 10) && (this.AgeGroups[i].GroupMembers.Count < 14))
                            {
                                ProcessMemberSchemeMiddleGroup(i, @"1 + 9  Member 65 - 70 Years", 14, 10);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 6) && (this.AgeGroups[i].GroupMembers.Count < 10))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member 65 - 70 Years", 10, 6);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count > 0) && (this.AgeGroups[i].GroupMembers.Count < 6))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member 65 - 70 Years", 10, 6);
                            }
                        }
                    }


                    if (this.AgeGroups[i].GroupDescription == "71 to 74 years")
                    {
                        while (this.AgeGroups[i].GroupMembers.Count > 0)
                        {
                            if (this.AgeGroups[i].GroupMembers.Count >= 14)
                            {
                                ProcessMemberSchemeTopGroup(i, @"1 + 13 Member 71 - 74 Years", 14);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 10) && (this.AgeGroups[i].GroupMembers.Count < 14))
                            {
                                ProcessMemberSchemeMiddleGroup(i, @"1 + 9  Member 71 - 74 Years", 14, 10);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count >= 6) && (this.AgeGroups[i].GroupMembers.Count < 10))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member 71 - 74 Years", 10, 6);
                            }
                            else if ((this.AgeGroups[i].GroupMembers.Count > 0) && (this.AgeGroups[i].GroupMembers.Count < 6))
                            {
                                ProcessMemberSchemeBottomGroup(i, @"1 + 5  Member 71 - 74 Years", 10, 6);
                            }
                        }
                    }

                    if (this.AgeGroups[i].GroupDescription == "75 to 84 years")
                    {
                        ProcessMemberSchemeOuterGroup(i, "75 to 84 years");
                    }

                    if (this.AgeGroups[i].GroupDescription == "85 to 99 years")
                    {
                        ProcessMemberSchemeOuterGroup(i, "85 to 99 years");
                    }

                    if (this.AgeGroups[i].GroupDescription == "Older than 99 years")
                    {
                        ProcessMemberSchemeOuterGroup(i, "Older than 99 years");
                    }
                }
            }
        }


        private void ProcessMemberSchemeTopGroup(int ageGroupIndex, string schemeName, int groupCount1)
        {
            int index = 0;
            ProspectiveMemberScheme memberScheme = new ProspectiveMemberScheme(schemeName);

            if (this.ProspectiveMemberSchemes.FirstOrDefault(x => x.SchemeName == schemeName) == null)
            {
                this.ProspectiveMemberSchemes.Add(memberScheme);
            }
            index = this.ProspectiveMemberSchemes.IndexOf(memberScheme);

            if (this.AgeGroups[ageGroupIndex].GroupMembers.Count >= groupCount1)
            {
                int groups = (this.AgeGroups[ageGroupIndex].GroupMembers.Count / groupCount1);
                for (int j = 0; j < groups; j++)
                {
                    var list = new ObservableCollection<ProspectiveMember>();
                    int count = j * groupCount1;
                    for (int k = count; k < (j + 1) * groupCount1; k++)
                    {
                        list.Add(this.AgeGroups[ageGroupIndex].GroupMembers[k]);
                    }
                    this.ProspectiveMemberSchemes[index].ProspectiveMemberGroup.Add(new ProspectiveMemberGroup() { GroupSchemeName = schemeName, GroupCoverAmount = this.CoverAmount , GroupName = "Group " + Convert.ToString(j + 1), ProspectiveMembers = list });
                }
                this.AgeGroups[ageGroupIndex].GroupMembers.RemoveRange(0, (groups * groupCount1));
            }
        }

        private void ProcessMemberSchemeMiddleGroup(int ageGroupIndex, string schemeName, int groupCount1, int groupCount2)
        {
            int index = 0;
            ProspectiveMemberScheme memberScheme = new ProspectiveMemberScheme(schemeName);

            if (this.ProspectiveMemberSchemes.FirstOrDefault(x => x.SchemeName == schemeName) == null)
            {
                this.ProspectiveMemberSchemes.Add(memberScheme);
            }
            index = this.ProspectiveMemberSchemes.IndexOf(memberScheme);

            if ((this.AgeGroups[ageGroupIndex].GroupMembers.Count >= groupCount2) && (this.AgeGroups[ageGroupIndex].GroupMembers.Count < groupCount1))
            {
                int groups = (this.AgeGroups[ageGroupIndex].GroupMembers.Count / groupCount2);
                for (int j = 0; j < groups; j++)
                {
                    var list = new ObservableCollection<ProspectiveMember>();
                    int count = j * groupCount1;
                    for (int k = count; k < (j + 1) * groupCount2; k++)
                    {
                        list.Add(this.AgeGroups[ageGroupIndex].GroupMembers[k]);
                    }
                    this.ProspectiveMemberSchemes[index].ProspectiveMemberGroup.Add(new ProspectiveMemberGroup() { GroupSchemeName = schemeName, GroupCoverAmount = this.CoverAmount, GroupName = "Group " + Convert.ToString(j + 1), ProspectiveMembers = list });
                }
                this.AgeGroups[ageGroupIndex].GroupMembers.RemoveRange(0, (groups * groupCount2) - 1);
            }
        }

        private void ProcessMemberSchemeBottomGroup(int ageGroupIndex, string schemeName, int groupCount2, int groupCount3)
        {
            int index = 0;
            ProspectiveMemberScheme memberScheme = new ProspectiveMemberScheme(schemeName);
            
            if (this.ProspectiveMemberSchemes.FirstOrDefault(x => x.SchemeName == schemeName) == null)
            {
                this.ProspectiveMemberSchemes.Add(memberScheme);
            }
            index = this.ProspectiveMemberSchemes.IndexOf(memberScheme);

            if ((this.AgeGroups[ageGroupIndex].GroupMembers.Count > 0) && (this.AgeGroups[ageGroupIndex].GroupMembers.Count < groupCount3))
            {
                var list = new ObservableCollection<ProspectiveMember>();
    
                for (int k = 0; k < this.AgeGroups[ageGroupIndex].GroupMembers.Count; k++)
                {
                    list.Add(this.AgeGroups[ageGroupIndex].GroupMembers[k]);
                }
                this.ProspectiveMemberSchemes[index].ProspectiveMemberGroup.Add(new ProspectiveMemberGroup() { GroupSchemeName = schemeName, GroupCoverAmount = this.CoverAmount, GroupName = "Group " + Convert.ToString(1), ProspectiveMembers = list });
                this.AgeGroups[ageGroupIndex].GroupMembers.RemoveRange(0, (this.AgeGroups[ageGroupIndex].GroupMembers.Count));
            }
        }

        private void ProcessMemberSchemeOuterGroup(int ageGroupIndex, string schemeName)
        {
            int index = 0;
            ProspectiveMemberScheme memberScheme = new ProspectiveMemberScheme(schemeName);

            if (this.ProspectiveMemberSchemes.FirstOrDefault(x => x.SchemeName == schemeName) == null)
            {
                this.ProspectiveMemberSchemes.Add(memberScheme);
            }
            index = this.ProspectiveMemberSchemes.IndexOf(memberScheme);
  
            var list = new ObservableCollection<ProspectiveMember>();
            for (int k = 0; k < this.AgeGroups[ageGroupIndex].GroupMembers.Count; k++)
            {
                list.Add(this.AgeGroups[ageGroupIndex].GroupMembers[k]);
            }
            this.ProspectiveMemberSchemes[index].ProspectiveMemberGroup.Add(new ProspectiveMemberGroup() { GroupSchemeName = schemeName, GroupCoverAmount = this.CoverAmount, GroupName = "Group " + Convert.ToString(1), ProspectiveMembers = list });
            this.AgeGroups[ageGroupIndex].GroupMembers.RemoveRange(0, (this.AgeGroups[ageGroupIndex].GroupMembers.Count));
        }
        #endregion
    }
}
