using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Unidad3.Models;
using Xamarin.Forms;

namespace Unidad3.ViewModel
{
    class LoginViewModel : BaseViewModel
    {

        #region Atributos
        public string user;
        public string password;
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

        #endregion


        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
            set { }
        }

        #endregion


        #region Methods

        public async void LoginMethod()
        {

            List<UserModel> ListUser = App.Db.ValidateUserModel(user, password).Result;

            UserModel Usr = App.Db.GetUserModel(user, password).Result;
            

            if(Usr == null)
            {

            }
            else
            {

            }

            if(ListUser.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("WELCOME", "Bienvenido... Aplicacion ", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new Landing());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "Usuario o Contraseña  Incorrecta...", "OK");
            }
        }

        #endregion



    }
}
