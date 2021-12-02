using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Input;
using Unidad3.Models;
using GalaSoft.MvvmLight.Command;

namespace Unidad3.ViewModel
{
    class ChistesViewModel:BaseViewModel
    {
        #region Att
        public string chiste;
        public string icon_url;
        private static string url = "https://api.chucknorris.io/jokes/random";

        #endregion

        #region Prop

        public string Chistetxt
        {
            get
            {
                return this.chiste;
            }
            set { SetValue(ref this.chiste, value); }
        }


        public string Icon_urlTxt
        {
            get
            {
                return this.icon_url;
            }
            set { SetValue(ref this.icon_url, value); }
        }
                   


        #endregion

        public ICommand GetData
        {
            get
            {
                return new RelayCommand(GetDataMethod);
            }
            set { }
        }


        public async void GetDataMethod()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            if(response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var objChiste = JsonConvert.DeserializeObject<ChistesModel>(jsonResult);
                Chistetxt = objChiste.value;
                Icon_urlTxt = objChiste.icon_url;
            }
            else { }
        }

    }
}
