using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseWork.ViewModel
{
    public abstract class BaseVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
