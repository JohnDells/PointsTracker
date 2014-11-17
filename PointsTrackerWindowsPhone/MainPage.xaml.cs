using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PointsTrackerWindowsPhone.Resources;
using PointsTracker;
using System.Windows.Input;

namespace PointsTrackerWindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new MainViewModel();
        }
    
        private void AddCommand(object sender, EventArgs e)
        {
            var item = this.DataContext as MainViewModel;
            if (item != null)
            {
                Helpers.FixFocus();
                item.AddCommand.Execute(null);
            }
        }

        private void HistoryCommand(object sender, EventArgs e)
        {
            var item = this.DataContext as MainViewModel;

            if (item != null)
            {
                NavigationService.Navigate(new Uri("/HistoryPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void SettingsCommand(object sender, EventArgs e)
        {
            var item = this.DataContext as MainViewModel;

            if (item != null)
            {
                NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

    }
}