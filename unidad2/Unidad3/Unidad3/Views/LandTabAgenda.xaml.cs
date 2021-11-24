using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad3.ViewModel;
using Unidad3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using Unidad3.Views.PopUp;

namespace Unidad3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandTabAgenda : ContentPage
    {
        public LandTabAgenda()
        {
            InitializeComponent();
            BindingContext = new ContactosViewModal();
          //  ListV.ItemsSource = App.Db.GetTableModel<ContactosModel>().Result;

        }

     

        private async void New_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewContact(), true);
        }

        private void ListV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            PopupNavigation.Instance.PushAsync(new PopUpUpdateContact(e.SelectedItem as ContactosModel));
        }
    }
}