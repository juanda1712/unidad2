using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unidad3.Views;
using Unidad3.DataBase;
using Unidad3.Models;
using System.IO;
using System.Collections.Generic;

namespace Unidad3
{
    public partial class App : Application
    {
        static DataBaseQuery database;
        public static DataBaseQuery Db
        {
            get
            {
                if(database == null)
                {
                    database = new DataBaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"DBUnidad3.db"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {

            List<UserModel> ListUsr = new List<UserModel>();
            ListUsr = Db.GetUserModel().Result;
                

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
