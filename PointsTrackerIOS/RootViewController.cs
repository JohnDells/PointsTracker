﻿using System;
using System.Drawing;

using Foundation;
using UIKit;
using PointsTracker;

namespace PointsTrackerIOS
{
    public partial class RootViewController : UIViewController
    {
        private PointsTrackerManager _PointsTrackerManager;

        public RootViewController(IntPtr handle)
            : base(handle)
        {
            _PointsTrackerManager = new PointsTrackerManager();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Refresh();
        }

        private void Refresh()
        {
            lblPointsLeft.Text = _PointsTrackerManager.GetPointsLeftToday().ToString();
            txtFoodName.Text = "";
            txtFoodPoints.Text = "";
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}