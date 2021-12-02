using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unidad3.Models;
using Unidad3.Views;

namespace Unidad3.ViewModel
{
    class MenuLateralFlyoutViewModel: BaseViewModel 
    {
        #region Att
        public string icon;
        public string title;    
        public object listViewSource;

        #endregion

        #region Prop

        public string Icon
        {
            get
            {
                return this.icon;
            }
            set { SetValue(ref this.icon, value); }
        }


        public string Title
        {
            get
            {
                return this.title;
            }
            set { SetValue(ref this.title, value); }
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

        #region Metodos
        public async Task LoadList()
        {
            this.ListViewSource = new List<MenuLateralModel>(new[]
                {
                    new MenuLateralModel { Id = 0, Title = "New user" , Icon = "usr.png" , TargetType = typeof(NewUser)},
                    new MenuLateralModel { Id = 1, Title = "Service ", Icon = "usr.png" , TargetType = typeof(Services) },

                });


        }

        #endregion



        #region Constructor
        public MenuLateralFlyoutViewModel()
        {
            LoadList();
        
        }
        #endregion

    }
}
