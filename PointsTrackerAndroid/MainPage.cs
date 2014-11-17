using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PointsTracker;

namespace PointsTrackerAndroid
{
    [Activity(Label = "Points Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainPage : Activity
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        public MainPage()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);

            SetContentView(Resource.Layout.MainPage);

            if (btnAdd != null) btnAdd.Click += AddPoints;

            Refresh();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Refresh();
        }

        private void AddPoints(object sender, EventArgs e)
        {
            var foodName = (txtFoodName == null) ? "" : txtFoodName.Text;

            var foodPoints = (txtFoodPoints == null) ? 0 : txtFoodPoints.Text.ToSafeNullableInt();

            if (foodPoints == null) return;

            var foodEntry = new FoodEntry() { Name = foodName, Points = (int)foodPoints, Added = DateTime.Now };
            _PointsTrackerManager.AddPoints(foodEntry);

            Refresh();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Menu_MainPage, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_history:
                    StartActivity(typeof(HistoryPage));
                    return true;
                case Resource.Id.menu_settings:
                    StartActivity(typeof(SettingsPage));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void Refresh()
        {
            if (txtFoodName != null) txtFoodName.Text = "";

            if (txtFoodPoints != null) txtFoodPoints.Text = "";

            if (lblPointsLeft != null) lblPointsLeft.Text = _PointsTrackerManager.GetPointsLeftToday().ToString();            
        }

        #region Controls

        private Button btnAdd { get { return FindViewById<Button>(Resource.Id.btnAdd); } }

        private EditText txtFoodName { get { return FindViewById<EditText>(Resource.Id.txtFoodName); } }

        private EditText txtFoodPoints { get { return FindViewById<EditText>(Resource.Id.txtFoodPoints); } }

        private TextView lblPointsLeft { get { return FindViewById<TextView>(Resource.Id.lblPointsLeft); } }

        #endregion
    }
}

