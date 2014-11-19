using System;
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

			btnAdd.TouchUpInside += btnAdd_TouchUpInside;
        }

        private void Refresh()
        {
            lblPointsLeft.Text = _PointsTrackerManager.GetPointsLeftToday().ToString();
            txtFoodName.Text = "";
            txtFoodPoints.Text = "";
        }

        private void btnAdd_TouchUpInside (object sender, EventArgs e)
        {
			var foodName = txtFoodName.Text;
			var foodPoints = txtFoodPoints.Text.ToSafeNullableInt ();

			if (!string.IsNullOrEmpty (foodName) && foodPoints != null)
			{
				var foodEntry = new FoodEntry () { Points = (int)foodPoints, Name = foodName, Added = DateTime.Now };
				_PointsTrackerManager.AddPoints (foodEntry);
				Refresh ();
			}
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
			Refresh();
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