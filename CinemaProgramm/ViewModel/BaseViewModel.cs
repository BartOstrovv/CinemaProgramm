using System.ComponentModel;

namespace CinemaProgramm.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel()
        { 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
