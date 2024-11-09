using CommunityToolkit.Mvvm.ComponentModel;

namespace ShopApp;

// CON ESTA CLASE PODEMOS HACER CAMBIOS DINAMICOS EN LA PAGES
public abstract class ViewModelGlobal : ObservableObject
{
    
}


//  **** CON LA INSTALACION DE 'CommunityToolKit.MVVM YA NO ES NECESARIA ESTA IMPLEMENTACION'  ****
// public class BindingUtilObject : INotifyPropertyChanged
// {
//    public void RaisePropertyChanged( 
//            [CallerMemberName] string propertyName = null 
//        )
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }
//    public event PropertyChangedEventHandler? PropertyChanged;
// }

