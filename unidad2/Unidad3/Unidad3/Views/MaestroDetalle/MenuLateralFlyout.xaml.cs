using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unidad3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad3.Views.MaestroDetalle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLateralFlyout : ContentPage
    {
        public ListView ListView;

        public MenuLateralFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuLateralFlyoutViewModel();
            ListView = MenuItemsListView;
        }



        //class MenuLateralFlyoutViewModel : INotifyPropertyChanged
        //{
        //    public ObservableCollection<MenuLateralFlyoutMenuItem> MenuItems { get; set; }

        //    public MenuLateralFlyoutViewModel()
        //    {
        //        MenuItems = new ObservableCollection<MenuLateralFlyoutMenuItem>(new[]
        //        {
        //            new MenuLateralFlyoutMenuItem { Id = 0, Title = "New user" , TargetType = typeof(NewUser)},
        //            new MenuLateralFlyoutMenuItem { Id = 1, Title = "Page 2" },
           
        //        });
        //    }

        //    #region INotifyPropertyChanged Implementation
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        if (PropertyChanged == null)
        //            return;

        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    #endregion
        //}
    }
}