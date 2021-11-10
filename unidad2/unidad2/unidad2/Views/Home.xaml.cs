using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace unidad2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

       

        private async void btnAgenda_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Agenda());
        }
    }
}