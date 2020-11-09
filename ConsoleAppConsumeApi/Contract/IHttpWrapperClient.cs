using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConsumeApi.Contract
{
    public interface IHttpWrapperClient
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, HttpContent contentPost);
        Task<T> PatchAsync<T>(string url, HttpContent contentPatch);
    }
}
