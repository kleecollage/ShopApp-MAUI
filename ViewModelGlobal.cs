using CommunityToolkit.Mvvm.ComponentModel;

namespace ShopApp;

// CON ESTA CLASE PODEMOS HACER CAMBIOS DINAMICOS EN LA PAGES
public partial class ViewModelGlobal : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !isBusy;
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

