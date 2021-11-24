using System;
using System.Collections.Generic;
using System.Text;
using Unidad3.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace Unidad3.ViewModel
{
    class ContactosViewModal: BaseViewModel
    {
        #region Att
        public string nombre;
        public string numero;
        public string imagen;
        public int id;
        public bool isRefreshing = false;
        public object listViewSource;

        #endregion


        #region Prop

        public string NombreTxt
        {
            get
            {
                return this.nombre;
            }
            set { SetValue(ref this.nombre, value); }
        }


        public string NumeroTxt
        {
            get
            {
                return this.numero;
            }
            set { SetValue(ref this.numero, value); }
        }


        public int  IDTxt
        {
            get
            {
                return this.id;
            }
            set { SetValue(ref this.id, value); }
        }

        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set { SetValue(ref this.isRefreshing, value); }
        }


        public string ImgTxt
        {
            get
            {
                return this.imagen;
            }
            set { SetValue(ref this.imagen, value); }
        }


        public object ListViewSource
        {
            get
            {
                return this.listViewSource;
            }
            set { SetValue(ref this.listViewSource, value); }
        }


        #endregion


        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(UpdateContactMethod);
            }
            set { }
        }



        #region Metodos
        public async Task LoadList()
        {
            this.ListViewSource =  await App.Db.GetTableModel<ContactosModel>();
        
        }


        public async void UpdateContactMethod()
        {

            var contact = new ContactosModel();
            contact.Nombre = nombre;
            contact.Telefono = numero;
            contact.ContactID = id;
            contact.Imagen = "usr.png";

            await App.Db.SaveModelAsync<ContactosModel>(contact, false);
            await Application.Current.MainPage.DisplayAlert("OK", " Actualización Exitosa", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new Landing(), true);
            await PopupNavigation.Instance.PopAsync(true);
        }
        #endregion


        #region Constructor
        public ContactosViewModal()
        {
            LoadList();
            IsRefreshing = false;
        }


        public ContactosViewModal(ContactosModel item)
        {

            NombreTxt = item.Nombre;
            NumeroTxt = item.Telefono;
            IDTxt = item.ContactID;
            
        }
        #endregion

    }
}
