using System.Threading.Tasks;
using TestYourStudents.Core.Entities;
using TestYourStudents.Core.Identity.Utils;

namespace TestYourStudents.Core.Identity.Repository
{
    public interface IIdentityRepository
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request, string requesterRole);
        Task<AuthenticationResult> LoginAsync(string email, string password);

    }
}