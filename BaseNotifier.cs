using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace UniversalPlatformTools
{
    /// <summary>
    /// A Basic implementation of the <see cref="INotifyPropertyChanged"/> and <see cref="INotifyPropertyChanging"/> interfaces.
    /// </summary>
    [WebHostHidden]
    public class BaseNotifier : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            NotifyPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected virtual void NotifyPropertyChanging([CallerMemberName]string propertyName = "")
        {
            NotifyPropertyChanging(new PropertyChangingEventArgs(propertyName));
        }
        protected virtual void NotifyPropertyChanging(PropertyChangingEventArgs e)
        {
            PropertyChanging?.Invoke(this, e);
        }

        public BaseNotifier()
        {
            PropertyChanged += OnPropertyChanged;
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

    }
}
