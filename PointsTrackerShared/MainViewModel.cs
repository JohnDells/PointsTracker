using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PointsTracker
{
    public class MainViewModel : BaseViewModel
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        public MainViewModel()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
            Refresh();
        }

        public void Refresh()
        {
            MaxPoints = _PointsTrackerManager.GetMaxPoints();
            PointsUsedToday = _PointsTrackerManager.GetPointsUsedToday();
            FoodName = "";
            FoodPoints = "";
        }

        private ICommand _AddCommand;

        public ICommand AddCommand
        {
            get { return _AddCommand ?? (_AddCommand = new RelayCommand(ExecuteAddCommand)); }
        }

        private void ExecuteAddCommand()
        {
            var foodPoints = FoodPoints.ToSafeNullableInt();
            if (foodPoints == null) return;
            var foodEntry = new FoodEntry() { Name = FoodName, Points = (int)foodPoints, Added = DateTime.Now };
            _PointsTrackerManager.AddPoints(foodEntry);

            Refresh();
        }

        private int _MaxPoints = 0;

        public int MaxPoints
        {
            get { return _MaxPoints; }
            set
            {
                if (_MaxPoints == value) return;
                _MaxPoints = value;
                OnPropertyChanged("MaxPoints");
            }
        }

        private int _PointsUsedToday = 0;

        public int PointsUsedToday
        {
            get { return _PointsUsedToday; }
            set
            {
                if (_PointsUsedToday == value) return;
                _PointsUsedToday = value;
                OnPropertyChanged("PointsUsedToday");
                OnPropertyChanged("PointsLeft");
            }
        }

        public int PointsLeft
        {
            get { return MaxPoints - PointsUsedToday; }
        }

        private string _FoodName = "";

        public string FoodName
        {
            get { return _FoodName; }
            set
            {
                if (_FoodName == value) return;
                _FoodName = value;
                OnPropertyChanged("FoodName");
            }
        }

        private string _FoodPoints = "";

        public string FoodPoints
        {
            get { return _FoodPoints; }
            set
            {
                if (_FoodPoints == value) return;
                _FoodPoints = value;
                OnPropertyChanged("FoodPoints");
            }
        }

    }
}
