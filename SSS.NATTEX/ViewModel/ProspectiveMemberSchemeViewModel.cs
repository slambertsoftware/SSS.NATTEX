using SSS.NATTEX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.ViewModel
{
    public class ProspectiveMemberSchemeViewModel : MainViewModel
    {
        private ObservableCollection<MemberSchemeType> _memberSchemeTypes;
        public ObservableCollection<MemberSchemeType> MemberSchemeTypes
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

        public ProspectiveMembersViewModel MembersViewModel { get; set; }

        public List<AgeGroupModel> AgeGroups { get; set; }

        public List<List<ProspectiveMember>> ProspectiveMemberGroupList { get; set; }

        public List<ProspectiveMember> ProspectiveMembers { get; set; }
        public ObservableCollection<MemberSchemeType> ProspectiveMemberSchemeList { get; set; }

        public ProspectiveMemberSchemeViewModel(ProspectiveMembersViewModel membersViewModel)
        {
            int index = 0;
            this.MembersViewModel = membersViewModel;
            ProspectiveMemberSchemeTypes schemes = new ProspectiveMemberSchemeTypes();
            MemberSchemeTypes = new ObservableCollection<MemberSchemeType>(schemes.Types);
            DoMemberAgeGrouping();
            DoMemberSchemeGrouping();


        }

        private void DoMemberAgeGrouping()
        {
            for (int i = 0; i < this.MembersViewModel.ProspectiveMembers.Count; i++)
            {
                AgeGroupModel ageGroupModel = null;
                int index = 0;

                if (this.MembersViewModel.ProspectiveMembers[i].Age < 65)
                {
                    if  (this.AgeGroups == null)
                    {
                        this.AgeGroups = new List<AgeGroupModel>();
                    }
                    if (this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "Less than 65 years") == null)
                    {
                        ageGroupModel = new AgeGroupModel()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "Less than 65 years"
                        };
                        this.AgeGroups.Add(ageGroupModel);
                    }
                    else
                    {
                        ageGroupModel = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "Less than 65 years");
                    }

                    index = this.AgeGroups.IndexOf(ageGroupModel);
                    this.AgeGroups[index].GroupMembers.Add(this.MembersViewModel.ProspectiveMembers[i]);
                }

                if (this.MembersViewModel.ProspectiveMembers[i].Age >= 65 && this.MembersViewModel.ProspectiveMembers[i].Age <= 70)
                {
                    ageGroupModel = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "65 to 70 years");
                    if (ageGroupModel == null)
                    {
                        ageGroupModel = new AgeGroupModel()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "65 to 70 years"
                        };
                        this.AgeGroups.Add(ageGroupModel);
                    }
                    index = this.AgeGroups.IndexOf(ageGroupModel);
                    this.AgeGroups[index].GroupMembers.Add(this.MembersViewModel.ProspectiveMembers[i]);
                }

               if (this.MembersViewModel.ProspectiveMembers[i].Age >= 71 && this.MembersViewModel.ProspectiveMembers[i].Age <= 74)
               {
                    ageGroupModel = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "71 to 74 years");
                    if (ageGroupModel == null)
                    {
                        ageGroupModel = new AgeGroupModel()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "71 to 74 years"
                        };
                        this.AgeGroups.Add(ageGroupModel);
                    }
                    index = this.AgeGroups.IndexOf(ageGroupModel);
                    this.AgeGroups[index].GroupMembers.Add(this.MembersViewModel.ProspectiveMembers[i]);
                }

                if (this.MembersViewModel.ProspectiveMembers[i].Age >= 75 && this.MembersViewModel.ProspectiveMembers[i].Age <= 84)
                {
                    ageGroupModel = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "75 to 84 years");
                    if (ageGroupModel == null)
                    {
                        ageGroupModel = new AgeGroupModel()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "75 to 84 years"
                        };
                        this.AgeGroups.Add(ageGroupModel);
                    }
                    index = this.AgeGroups.IndexOf(ageGroupModel);
                    this.AgeGroups[index].GroupMembers.Add(this.MembersViewModel.ProspectiveMembers[i]);
                }

                if (this.MembersViewModel.ProspectiveMembers[i].Age >= 85 && this.MembersViewModel.ProspectiveMembers[i].Age <= 99)
                {
                    ageGroupModel = this.AgeGroups.FirstOrDefault(x => x.GroupDescription == "85 to 99 years");
                    if (ageGroupModel == null)
                    {
                        ageGroupModel = new AgeGroupModel()
                        {
                            GroupMembers = new List<ProspectiveMember>(),
                            GroupDescription = "85 to 99 years"
                        };
                        this.AgeGroups.Add(ageGroupModel);
                    }
                    index = this.AgeGroups.IndexOf(ageGroupModel);
                    this.AgeGroups[index].GroupMembers.Add(this.MembersViewModel.ProspectiveMembers[i]);
                }
            }
        }

        private void DoMemberSchemeGrouping()
        {
            int groups = 0;
            List<AgeGroupModel> ageGroups = this.AgeGroups;
            for (int i = 0; i < ageGroups.Count; i++)
            {
                if (this.AgeGroups[i].GroupDescription == "Less than 65 years")
                {
                    if (ageGroups[i].GroupMembers.Count >= 14)
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 14);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 14; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+13 Member < 65 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 14));
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 10) && (ageGroups[i].GroupMembers.Count < 14))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 10);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 10; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+9 Member < 65 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 10) - 1);
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 6) && (ageGroups[i].GroupMembers.Count < 10))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 6);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 6; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+5 Member < 65 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 6) - 1);
                    }

                    if (ageGroups[i].GroupMembers.Count < 6)
                    {
                        if (this.ProspectiveMemberSchemeList == null)
                        {
                            this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                        }
                        var list = new List<ProspectiveMember>();
                        for (int k = 0; k < ageGroups[i].GroupMembers.Count; k++)
                        {
                            list.Add(ageGroups[i].GroupMembers[k]);
                        }
                        MemberSchemeType scheme = new MemberSchemeType("Ungrouped", @"1+5 Member < 65 Years");
                        scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                        this.ProspectiveMemberSchemeList.Add(scheme);
                    }
                }

                if (this.AgeGroups[i].GroupDescription == "65 to 70 years")
                {
                    if (ageGroups[i].GroupMembers.Count >= 14)
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 14);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 14; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+13 Member 65 - 70 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 14));
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 10) && (ageGroups[i].GroupMembers.Count < 14))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 10);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 10; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+9 Member 65 - 70 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 10) - 1);
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 6) && (ageGroups[i].GroupMembers.Count < 10))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 6);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 6; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+5 Member 65 - 70 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 6) - 1);
                    }

                    if (ageGroups[i].GroupMembers.Count < 6)
                    {
                        if (this.ProspectiveMemberSchemeList == null)
                        {
                            this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                        }
                        var list = new List<ProspectiveMember>();
                        for (int k = 0; k < ageGroups[i].GroupMembers.Count; k++)
                        {
                            list.Add(ageGroups[i].GroupMembers[k]);
                        }
                        MemberSchemeType scheme = new MemberSchemeType("Ungrouped", @"1+5 Member < 65 Years");
                        scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                        this.ProspectiveMemberSchemeList.Add(scheme);
                    }
                }

                if (this.AgeGroups[i].GroupDescription == "71 to 74 years")
                {
                    if (ageGroups[i].GroupMembers.Count >= 14)
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 14);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 14; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+13 Member 71 - 74 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 14));
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 10) && (ageGroups[i].GroupMembers.Count < 14))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 10);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 10; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+9 Member 71 - 74 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 10) - 1);
                    }

                    if ((ageGroups[i].GroupMembers.Count >= 6) && (ageGroups[i].GroupMembers.Count < 10))
                    {
                        groups = (ageGroups[i].GroupMembers.Count / 6);
                        for (int j = 0; j < groups; j++)
                        {
                            if (this.ProspectiveMemberSchemeList == null)
                            {
                                this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                            }

                            var list = new List<ProspectiveMember>();
                            for (int k = 0; k < (j + 1) * 6; k++)
                            {
                                list.Add(ageGroups[i].GroupMembers[k]);
                            }
                            MemberSchemeType scheme = new MemberSchemeType("Group " + Convert.ToString(j + 1), @"1+5 Member 71 - 74 Years");
                            scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                            this.ProspectiveMemberSchemeList.Add(scheme);
                        }
                        ageGroups[i].GroupMembers.RemoveRange(0, (groups * 6) - 1);
                    }

                    if (ageGroups[i].GroupMembers.Count < 6)
                    {
                        if (this.ProspectiveMemberSchemeList == null)
                        {
                            this.ProspectiveMemberSchemeList = new ObservableCollection<MemberSchemeType>();
                        }
                        var list = new List<ProspectiveMember>();
                        for (int k = 0; k < ageGroups[i].GroupMembers.Count; k++)
                        {
                            list.Add(ageGroups[i].GroupMembers[k]);
                        }
                        MemberSchemeType scheme = new MemberSchemeType("Ungrouped", @"1+5 Member < 65 Years");
                        scheme.Members = new ObservableCollection<ProspectiveMember>(list);
                        this.ProspectiveMemberSchemeList.Add(scheme);
                    }
                }

                if (this.AgeGroups[i].GroupDescription == "75 to 84 years")
                {
                }

                if (this.AgeGroups[i].GroupDescription == "85 to 99 years")
                {
                }
            }
        }

       
    }
}
