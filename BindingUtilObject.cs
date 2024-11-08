using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopApp
{
    // CON ESTA CLASE PODEMOS HACER CAMBIOS DINAMICOS EN LA PAGES
    public class BindingUtilObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged( 
                [CallerMemberName] string propertyName = null 
            )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
