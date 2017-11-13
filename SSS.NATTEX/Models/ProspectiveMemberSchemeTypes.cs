﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProspectiveMemberSchemeTypes
    { 
        public ObservableCollection<MemberSchemeType> Types { get; set; }

        public ProspectiveMemberSchemeTypes()
        {

            this.Types = new ObservableCollection<MemberSchemeType>();
            this.Types.Add(new MemberSchemeType(@"1+13 Member < 65 Years",    @"1+13 Member < 65 Years"));
            this.Types.Add(new MemberSchemeType("1+13 Member 65 - 70 Years", "1+13 Member 65 - 70 Years"));
            this.Types.Add(new MemberSchemeType("1+13 Member 71 - 74 Years", "1+13 Member 71 - 74 Years"));

            this.Types.Add(new MemberSchemeType(@"1+9 Member < 65 Years", @"1+9 Member < 65 Years"));
            this.Types.Add(new MemberSchemeType("1+9 Member 65 - 70 Years", "1+9 Member 65 - 70 Years"));
            this.Types.Add(new MemberSchemeType("1+9 Member 71 - 74 Years", "1+9 Member 71 - 74 Years"));

            this.Types.Add(new MemberSchemeType(@"1 + 5 Member < 65 Years", @"1+5 Member < 65 Years"));
            this.Types.Add(new MemberSchemeType("1+5 Member 65 - 70 Years", "1+5 Member 65 - 70 Years"));
            this.Types.Add(new MemberSchemeType("1+5 Member 71 - 74 Years", "1+5 Member 71 - 74 Years"));
        }
    }
}
