using ConsoleAppConsumeApi.Contract;
using ConsoleAppConsumeApi.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConsumeApi.Core
{
    public class PersonApiClient : IPersonApiClient
    {
        private readonly IHttpWrapperClient _httpWrapperClient;
        public PersonApiClient(IHttpWrapperClient httpWrapperClient)
        {
            _httpWrapperClient = httpWrapperClient;
        }

        public async Task<ReadOnlyPerson> GetPersonAsync(int id)
        {
            // string url = $"api/v1/employee/" + id.ToString();
            string url = $"person/" + id.ToString();
            ReadOnlyPerson person = await _httpWrapperClient.GetAsync<ReadOnlyPerson>(url);
            return person;
        }


        public async Task<string> PostPersonAsync(AddPerson addPerson)
        {
            HttpContent content = new StringContent(
                          JsonConvert.SerializeObject(addPerson),
                         Encoding.UTF8,
                         "application/json"
                      );
            string url = $"person";
            //string url = $"api/v1/create";
            return await _httpWrapperClient.PostAsync<string>(url, content);
        }
        public async Task<string> PatchPersonAsync(EditPerson editPerson)
        {

            HttpContent content = new StringContent(
                         JsonConvert.SerializeObject(editPerson),
                         Encoding.UTF8,
                         "application/json"
                      );
            string url = $"person/" + editPerson.Id.ToString();
            return await _httpWrapperClient.PostAsync<string>(url, content); ;
        }
    }

}
