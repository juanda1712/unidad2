using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Unidad3.Models;
using Xamarin.Forms;

namespace Unidad3.ViewModel
{
    class UserViewModel:BaseViewModel
    {
        #region Atributos
        public string user;
        public string password;
        public string nombre;
        #endregion



        #region Prop

        public string UserTxt
        {
            get
            {
                return this.user;
            }
            set { SetValue(ref this.user, value); }
        }
        public string PasswordTxt
        {
            get
            {
                return this.password;
            }
            set { SetValue(ref this.password, value); }
        }

        public string NombreTxt
        {
            get
            {
                return this.nombre;
            }
            set { SetValue(ref this.nombre, value); }
        }
        #endregion


        #region Commands

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
            set { }
        }

        #endregion


        #region Methods

        public async void RegisterMethod()
        {
            var userMod = new UserModel();
            userMod.Nombre = nombre;
            userMod.Usuario = user;
            userMod.Pw = password;
            await App.Db.SaveUserModelAsync(userMod);

            await Application.Current.MainPage.DisplayAlert("OK", nombre + " Registro Exitoso en Programación Movil", "OK");

        }

        #endregion


    }
}
