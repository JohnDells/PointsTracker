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
    [Activity(Label = "Settings")]
    public class SettingsPage : Activity
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        public SettingsPage()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.SettingsPage);

            if (btnSave != null) btnSave.Click += btnSave_Click;

            if (txtMaxPoints != null) txtMaxPoints.Text = _PointsTrackerManager.GetMaxPoints().ToString();           
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaxPoints != null)
            {
                var maxPoints = txtMaxPoints.Text.ToSafeNullableInt();
                if (maxPoints != null)
                {
                    _PointsTrackerManager.SetMaxPoints((int)maxPoints);
                }
            }
            Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Menu_SettingsPage, menu);
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

        private TextView lblMaxPoints { get { return FindViewById<TextView>(Resource.Id.lblMaxPoints); } }

        private EditText txtMaxPoints { get { return FindViewById<EditText>(Resource.Id.txtMaxPoints); } }

        private Button btnSave { get { return FindViewById<Button>(Resource.Id.btnSave); } }

        #endregion
    }
}