using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PointsTracker
{
    public class RelayCommand : ICommand
    {
        private readonly Action _Handler;

        private bool _IsEnabled = true;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                if (value != _IsEnabled)
                {
                    _IsEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, null);
                    }
                }
            }
        }

        public RelayCommand(Action handler)
        {
            _Handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _Handler();
        }
    }
}
