using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eCommerceFrontend.Models.REST.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace eCommerceFrontend.Models.REST.Manager
{
    public abstract class RESTManager<T, U>: IRestManager<T, U>
        where T: class
        where U : class
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
      
        protected internal RESTManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<T> Get(string controller, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }
        
        [HttpGet]
        public async Task<IEnumerable<T>> Get(string controller)
        {
            IEnumerable<T> result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            string path = $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<IEnumerable<T>>(x.Result);
            });

            return result;
        }

        [HttpPost]
        public async Task<T> Post(U postObject, string controller, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");

            HttpResponseMessage response;
            if (postObject.GetType().Name == "ProductPostRequest")
            {
                var multiContent = new MultipartFormDataContent {
                    {new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "multipart/form-data")}
                };
         
                string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
                response = await client.PostAsync(path, multiContent).ConfigureAwait(false);
            }
            else
            {
                var content = new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "application/json");
                string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

      

        [HttpPut]
        public async Task<T> Put(U putObject, string controller)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(JsonConvert.SerializeObject(putObject), System.Text.Encoding.UTF8, "application/json");
            string path = $"api/{controller}";
            var response = await client.PutAsync(path, content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpDelete]
        public async Task<T> Delete(string controller, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            string path = $"api/{controller}/{id}";
            var response = await client.DeleteAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }
    }
}
