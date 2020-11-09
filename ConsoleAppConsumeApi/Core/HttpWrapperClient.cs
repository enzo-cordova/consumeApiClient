using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppConsumeApi.Core
{
    public class HttpWrapperClient : IHttpWrapperClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient client;
        private readonly string _clientName;

        public HttpWrapperClient(IHttpClientFactory httpClientFactory, string ClientName)
        {
            _httpClientFactory = httpClientFactory;
            _clientName = ClientName;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            T data;
            client = _httpClientFactory.CreateClient(_clientName);
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                using (HttpContent content = response.Content)
                {
                    string respuesta = await content.ReadAsStringAsync();
                    if (respuesta != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(respuesta);
                        return (T)data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PostAsync<T>(string url, HttpContent contentPost)
        {
            T data;
            client = _httpClientFactory.CreateClient(_clientName);
            try
            {
                using (HttpResponseMessage response = await client.PostAsync(url, contentPost))
                using (HttpContent content = response.Content)
                {
                    string respuesta = await content.ReadAsStringAsync();
                    if (respuesta != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(respuesta);
                        return (T)data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PatchAsync<T>(string url, HttpContent contentPatch)
        {
            T data;
            client = _httpClientFactory.CreateClient(_clientName);
            try
            {
                using (HttpResponseMessage response = await client.PatchAsync(url, contentPatch))
                using (HttpContent content = response.Content)
                {
                    string respuesta = await content.ReadAsStringAsync();
                    if (respuesta != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(respuesta);
                        return (T)data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Object o = new Object();
            return (T)o;
        }

    }

}
