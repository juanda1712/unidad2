using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad3.ViewModel;
using Unidad3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}