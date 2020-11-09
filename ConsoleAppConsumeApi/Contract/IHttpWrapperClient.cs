using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppConsumeApi.Contract
{
    class IHttpWrapperClient
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, HttpContent contentPost);
        Task<T> PatchAsync<T>(string url, HttpContent contentPatch);
    }
}
