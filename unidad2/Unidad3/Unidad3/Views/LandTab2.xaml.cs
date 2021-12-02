using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;
using Unidad3.Views.MaestroDetalle;
using Unidad3.ViewModel;

namespace Unidad3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandTab2 : ContentPage
    {
        public LandTab2()
        {
            InitializeComponent();
            BindingContext = new ChistesViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var foto  = Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

        }

        private async void Notif_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("UTP", "Clase Programación Movíl");
        }

        private async  void Master_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuLateral());
        }
    }
}