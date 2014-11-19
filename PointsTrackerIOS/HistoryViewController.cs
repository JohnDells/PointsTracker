using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using PointsTracker;
using System.Collections.Generic;
using System.Drawing;

namespace PointsTrackerIOS
{
	partial class HistoryViewController : UITableViewController
	{
		private PointsTrackerManager _PointsTrackerManager;

		public HistoryViewController (IntPtr handle) : base (handle)
		{
			_PointsTrackerManager = new PointsTrackerManager ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var items = _PointsTrackerManager.GetFoodEntries ();
			this.TableView.Source = new TableSource (items);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public class TableSource : UITableViewSource
		{
			List<FoodEntry> tableItems;
			string cellIdentifier = "TableCell";

			public TableSource (List<FoodEntry> items)
			{
				tableItems = items;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return tableItems.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomCell;
				if (cell == null) cell = new CustomCell (cellIdentifier);
				cell.UpdateCell (tableItems[indexPath.Row]);
				return cell;
			}					

			public class CustomCell : UITableViewCell
			{
				UILabel lblDate;
				UILabel lblName;
				UILabel lblPoints;

				public CustomCell (string cellId) : base (UITableViewCellStyle.Default, cellId)
				{
					SelectionStyle = UITableViewCellSelectionStyle.Gray;
					ContentView.BackgroundColor = UIColor.White;

					lblDate = GetNewUILabel();
					lblName = GetNewUILabel();
					lblPoints = GetNewUILabel(UITextAlignment.Right);

					ContentView.AddSubviews(new UIView[] {lblDate, lblName, lblPoints});

				}

				private UILabel GetNewUILabel(UITextAlignment uiTextAlignment = UITextAlignment.Left)
				{
					return new UILabel()
					{
						Font = UIFont.PreferredBody,
						TextColor = UIColor.DarkTextColor,
						TextAlignment = uiTextAlignment,
						BackgroundColor = UIColor.Clear
					};
				}

				public void UpdateCell (FoodEntry foodEntry)
				{
					lblDate.Text = foodEntry.Added == DateTime.MinValue ? "" : foodEntry.Added.ToShortDateString();
					lblName.Text = foodEntry.Name;
					lblPoints.Text = foodEntry.Points.ToString ();
				}

				public override void LayoutSubviews ()
				{
					base.LayoutSubviews ();
					lblDate.Frame = new RectangleF(5, 5, 100, 30);
					lblName.Frame = new RectangleF(105, 5, 100, 30);
					lblPoints.Frame = new RectangleF((float)ContentView.Bounds.Width - 100, 5, 100, 30);
				}
			}
		}
	}
}
