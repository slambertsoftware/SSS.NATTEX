﻿using SSS.NATTEX.DAL;
using SSS.NATTEX.Models;
using SSS.NATTEX.ViewModel;
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
    /// Interaction logic for NavigationPaneUserControl.xaml
    /// </summary>
    public partial class NavigationPaneUserControl : UserControl
    {
        public NavigationPaneUserControl()
        {
            InitializeComponent();
            var viewModel = new NavigationPaneViewModel();
            DataContext = viewModel;
        }

        public NavigationPaneUserControl(ConfirmedQuotation message)
        {
            InitializeComponent();
            var viewModel = new NavigationPaneViewModel(message);
            DataContext = viewModel;
        }

        public void UpdatePendingQuotations(ConfirmedQuotation message)
        {
            (this.DataContext as NavigationPaneViewModel).UpdatePendingQuotations(message);
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem obj = (sender as ListBoxItem);
            var pendingQuotation = (obj.DataContext as LibertyPendingQuotation);
            (this.DataContext as NavigationPaneViewModel).ShowPendingQuotationDetailWindow(pendingQuotation);
        }

        public int GetNumOfPendingQuotations()
        {
            int count = 0;
            if ((this.DataContext as NavigationPaneViewModel).PendingQuotations == null)
            {
                return count;
            }
            else
            {
                return (this.DataContext as NavigationPaneViewModel).PendingQuotations.Count;
            }
        }

        public int GetNumOfAvbobPendingQuotations()
        {
            int count = 0;
            if ((this.DataContext as NavigationPaneViewModel).AvbobPendingQuotations == null)
            {
                return count;
            }
            else
            {
                return (this.DataContext as NavigationPaneViewModel).AvbobPendingQuotations.Count;
            }
        }

        private void AvbobListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem obj = (sender as ListBoxItem);
            var pendingQuotation = (obj.DataContext as AvbobPendingQuotation);
            (this.DataContext as NavigationPaneViewModel).ShowPendingQuotationDetailWindow(pendingQuotation);

        }
    }
}
