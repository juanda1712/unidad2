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
    public partial class Eventos : ContentPage
    {

        
        public Eventos()
        {
            InitializeComponent();
        }


        void temp()
        {
            var temp = etyNombre.Text;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string nombre , distincion;
            int edad;
            nombre = etyNombre.Text;
            if (nombre == "")
            {
                DisplayAlert("¡Welcome!", "Por favor Ingrese su nombre " , "Ok");
            }
            else
            {
                edad = int.Parse(etyEdad.Text);
                if (edad < 38)
                {
                    distincion = "Joven";
                }
                else
                {
                    if(rbF.IsChecked)
                    {
                        distincion = "Doña";
                    }
                    else
                    {
                        distincion = "Don";
                    }                                     

                }                   



                DisplayAlert("¡Welcome!", string.Concat("Hola ",distincion," ",nombre), "Ok");
            }          
            
        }

        private void etyNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblContador.Text = etyNombre.Text.Length.ToString();
        }

        private void sldFelicidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblValFelicidad.Text = sldFelicidad.Value.ToString() + " %" ;
        }
    }
}