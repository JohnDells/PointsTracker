using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointsTracker
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly SynchronizationContext _Context;

        public BaseViewModel()
        {
            _Context = SynchronizationContext.Current;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null) return;

            _Context.Post(x =>
            {
                PropertyChanged(this, new PropertyChangedEventArgs((string)x));
            }, name);
        }

    }
}
