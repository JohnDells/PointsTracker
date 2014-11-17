using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PointsTracker
{
    public class SettingsViewModel : BaseViewModel
    {
        private PointsTrackerManager _PointsTrackerManager = null;

        public SettingsViewModel()
        {
            if (_PointsTrackerManager == null) _PointsTrackerManager = new PointsTrackerManager();
            _MaxPoints = _PointsTrackerManager.GetMaxPoints();
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

        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(ExecuteSaveCommand)); }
        }

        private void ExecuteSaveCommand()
        {
            _PointsTrackerManager.SetMaxPoints(MaxPoints);
        }

    }
}
