using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad3.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Landing : TabbedPage
    {
        public Landing()
        {
            InitializeComponent();
        }
    }
}