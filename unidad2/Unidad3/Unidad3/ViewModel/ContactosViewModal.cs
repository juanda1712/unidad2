using System;
using System.Collections.Generic;
using System.Text;
using Unidad3.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Plugin.Messaging;

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

        public ICommand SmsCommand
        {
            get
            {
                return new RelayCommand(SmsMethod);
            }
            set { }
        }
        public ICommand CallCommand
        {
            get
            {
                return new RelayCommand(CallMethod);
            }
            set { }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteContactMethod);
            }
            set { }
        }

        #region Metodos
        public async Task LoadList()
        {
            this.ListViewSource =  await App.Db.GetTableModel<ContactosModel>();
        
        }
        public async void SmsMethod()
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if(sms.CanSendSms)
            {
                sms.SendSms(numero, "Xamarin UTP");
                await PopupNavigation.Instance.PopAsync(true);

            }
        }

        public async void CallMethod()
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(numero);
                await PopupNavigation.Instance.PopAsync(true);
            }
        }


        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }

        #endregion

        #region Methods
        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor Ingrese su Nombre.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.numero))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor Ingrese su Numero.",
                    "Aceptar");
                return;
            }




            var user = new ContactosModel();
            user.Nombre = nombre;
            user.Telefono = numero;
            user.Imagen = "usr.png";
            await App.Db.SaveModelAsync<ContactosModel>(user, true);

            await Application.Current.MainPage.DisplayAlert("Exitoso", nombre.ToString() + " se registro exitosamente en la agenda", "Ok");
            await Application.Current.MainPage.Navigation.PushAsync(new Landing(), true); ;




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


        public async void DeleteContactMethod()
        {

            var contact = new ContactosModel();
            contact.Nombre = nombre;
            contact.Telefono = numero;
            contact.ContactID = id;
            contact.Imagen = "usr.png";

            await App.Db.DeleteModelAsync<ContactosModel>(contact);
            await Application.Current.MainPage.DisplayAlert("OK", " Se elimino correctamente ", "OK");
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
