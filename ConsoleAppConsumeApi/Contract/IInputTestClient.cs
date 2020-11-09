using System.Threading.Tasks;

namespace ConsoleAppConsumeApi.Contract
{
    public interface IInputTestClient
    {
        Task<string> Run();
    }
}
