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
                return new RelayCommand(PostDataMethod);
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

        public async void GetListDataMethod()
        {
            string urlls = "https://jsonplaceholder.typicode.com/comments?postId=1";
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlls);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var objClient = JsonConvert.DeserializeObject<List<ClientModel>>(jsonResult);
              
            }
            else { }
        }


        public async void PostDataMethod()
        {
            string urlpost = "https://jsonplaceholder.typicode.com/posts";
            var client = new HttpClient();
            PostClientModel objclient = new PostClientModel
            {
                userId = 0,
                title = "Prueba",
                body = "hola soy un post"

            };
            string strjson = JsonConvert.SerializeObject(objclient);
            StringContent content = new StringContent(strjson, Encoding.UTF8, "application/json");

            client.BaseAddress = new Uri(urlpost);
            var response = await client.PostAsync(client.BaseAddress,content);
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {

                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var objClient = JsonConvert.DeserializeObject<ClientModel>(jsonResult);

            }
            else { }
        }


    }
}
