﻿using SSS.NATTEX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSS.NATTEX.Views.Controls
{
    /// <summary>
    /// Interaction logic for CapturedMembersUserControl.xaml
    /// </summary>
    public partial class CapturedMembersUserControl : UserControl
    {
        public CapturedMembersUserControl(ProspectiveMembersViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}