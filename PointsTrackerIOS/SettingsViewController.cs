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

			LoadScreen ();
        }

        void btnSave_TouchUpInside(object sender, EventArgs e)
        {
            var maxPoints = txtMaxPoints.Text.ToSafeNullableInt();
            if (maxPoints != null)
            {
                _PointsTrackerManager.SetMaxPoints((int)maxPoints);
				NavigationController.PopViewController (true);
            }
        }

		private void LoadScreen()
		{
			var maxPoints = _PointsTrackerManager.GetMaxPoints ();
			txtMaxPoints.Text = maxPoints.ToString ();
		}
	}
}
