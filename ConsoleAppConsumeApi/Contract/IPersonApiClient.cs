using ConsoleAppConsumeApi.Model;
using System.Threading.Tasks;

namespace ConsoleAppConsumeApi.Contract
{
    public interface IPersonApiClient
    {
        Task<ReadOnlyPerson> GetPersonAsync(int id);
        Task<string> PatchPersonAsync(EditPerson editPerson);
        Task<string> PostPersonAsync(AddPerson addPerson);
    }
}
