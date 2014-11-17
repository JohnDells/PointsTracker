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
    [Activity(Label = "History")]
    public class HistoryPage : Activity
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        public HistoryPage()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.HistoryPage);        
        }

        protected override void OnResume()
        {
            base.OnResume();

            var foodEntries = _PointsTrackerManager.GetFoodEntries().ToList();

            lstHistory.Adapter = new FoodEntryListAdapter(this, foodEntries);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Menu_HistoryPage, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                default:
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

        #region Controls

        private ListView lstHistory { get { return FindViewById<ListView>(Resource.Id.lstHistory); } }

        #endregion
    }
}