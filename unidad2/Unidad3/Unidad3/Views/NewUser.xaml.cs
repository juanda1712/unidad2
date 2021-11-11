using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUser : ContentPage
    {
        public NewUser()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();
        }
    }
}