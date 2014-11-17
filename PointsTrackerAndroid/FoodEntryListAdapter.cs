using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PointsTracker;

namespace PointsTrackerAndroid
{
    public class FoodEntryListAdapter: BaseAdapter<FoodEntry>
    {
		protected Activity _Context = null;

		protected IList<FoodEntry> _FoodEntries = new List<FoodEntry>();

        public FoodEntryListAdapter(Activity context, IList<FoodEntry> foodEntries)
            : base()
		{
            this._Context = context;
            this._FoodEntries = foodEntries;
		}
		
		public override FoodEntry this[int position]
		{
			get { return _FoodEntries[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return _FoodEntries.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{		
            var view = convertView ?? _Context.LayoutInflater.Inflate(Resource.Layout.HistoryPageDetail, parent, false);

            var item = _FoodEntries[position];

            if (item != null)
            {
                var lblDate = view.FindViewById<TextView>(Resource.Id.lblDate);
                if (lblDate != null) lblDate.Text = item.Added.ToShortDateString();

                var lblFoodName = view.FindViewById<TextView>(Resource.Id.lblFoodName);
                if (lblFoodName != null) lblFoodName.Text = item.Name;

                var lblFoodPoints = view.FindViewById<TextView>(Resource.Id.lblFoodPoints);
                if (lblFoodPoints != null) lblFoodPoints.Text = item.Points.ToString();
            }

            return view;
		}
    }
}