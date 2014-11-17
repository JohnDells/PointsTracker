// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace PointsTrackerIOS
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnHistory { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSettings { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPointsLeft { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFoodName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFoodPoints { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnHistory != null) {
				btnHistory.Dispose ();
				btnHistory = null;
			}
			if (btnSettings != null) {
				btnSettings.Dispose ();
				btnSettings = null;
			}
			if (lblPointsLeft != null) {
				lblPointsLeft.Dispose ();
				lblPointsLeft = null;
			}
			if (txtFoodName != null) {
				txtFoodName.Dispose ();
				txtFoodName = null;
			}
			if (txtFoodPoints != null) {
				txtFoodPoints.Dispose ();
				txtFoodPoints = null;
			}
		}
	}
}
