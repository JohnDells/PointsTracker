using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using PointsTracker;

namespace PointsTrackerIOS
{
	partial class SettingsViewController : UIViewController
	{
        private PointsTrackerManager _PointsTrackerManager;

		public SettingsViewController (IntPtr handle) : base (handle)
		{
            _PointsTrackerManager = new PointsTrackerManager();
		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            btnSave.TouchUpInside += btnSave_TouchUpInside;
        }

        void btnSave_TouchUpInside(object sender, EventArgs e)
        {
            var maxPoints = txtMaxPoints.Text.ToSafeNullableInt();
            if (maxPoints != null)
            {
                _PointsTrackerManager.SetMaxPoints((int)maxPoints);
                this.DismissViewController(true, null);
            }
        }
	}
}
