using ConsoleAppConsumeApi.Contract;
using ConsoleAppConsumeApi.Model;
using System.Threading.Tasks;

namespace ConsoleAppConsumeApi
{
    public class InputTestClient : IInputTestClient
    {
        private IPersonApiClient _personApiClient { get; set; }
        public InputTestClient(IPersonApiClient personApiClient)
        {
            _personApiClient = personApiClient;
        }

        public async Task<string> Run()
        {


            //var response = await _personApiClient.GetPersonAsync(1);

            var newPerson = new AddPerson() { Campaign = new Campaign() { Id = 1 }, DetailPerson = new DetailPerson() { Email = "enzoxxxxx@xxxxx.com", Telefono = "60XXXXXXX", Name = "Enzo" } };

            var response = await _personApiClient.PostPersonAsync(newPerson);

            return $"StatusCode: {response}";

        }
    }

}
