using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointsTracker
{
    public class HistoryViewModel : BaseViewModel
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        private List<FoodEntry> _FoodEntries = null;

        public List<FoodEntry> FoodEntries
        {
            get { return _FoodEntries; }
        }

        public HistoryViewModel()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
            _FoodEntries = _PointsTrackerManager.GetFoodEntries().ToList();
        }
    }
}
