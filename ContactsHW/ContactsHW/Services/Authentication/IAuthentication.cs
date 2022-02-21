using System.Threading.Tasks;

namespace ContactsHW.Services.Authentication
{
    public interface IAuthentication
    {
        Task<bool> SingInAsync(string login, string password);
        Task<bool> SingUpAsync(string login, string password);
    }
}
