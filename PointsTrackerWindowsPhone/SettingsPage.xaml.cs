using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PointsTracker;

namespace PointsTrackerWindowsPhone
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.DataContext = new SettingsViewModel();
        }

        private void SaveCommand(object sender, EventArgs e)
        {
            var item = this.DataContext as SettingsViewModel;
            if (item != null)
            {
                Helpers.FixFocus();
                item.SaveCommand.Execute(null);
            }
            NavigationService.GoBack();
        }
    }
}