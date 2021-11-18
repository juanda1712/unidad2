using System;
using System.Collections.Generic;
using System.Text;
using Unidad3.Models;
using System.Threading.Tasks;

namespace Unidad3.ViewModel
{
    class ContactosViewModal: BaseViewModel
    {
        #region Att
        public string nombre;
        public string numero;
        public string imagen;
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


        #region Metodos
        public async Task LoadList()
        {
            this.ListViewSource =  await App.Db.GetTableModel<ContactosModel>();
        
        }
        #endregion


        #region Constructor
        public ContactosViewModal()
        {
            LoadList();
            IsRefreshing = false;
        }
     
        #endregion

    }
}
