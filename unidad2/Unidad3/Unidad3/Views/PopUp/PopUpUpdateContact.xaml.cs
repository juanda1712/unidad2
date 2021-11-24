using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unidad3.ViewModel;

namespace Unidad3.Views.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpUpdateContact 
    {
        public PopUpUpdateContact()
        {
            InitializeComponent();
        }

        public PopUpUpdateContact(ContactosModel Item)
        {
            InitializeComponent();
            BindingContext = new ContactosViewModal(Item);
          
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
           await PopupNavigation.Instance.PopAsync();
        }
    }
}