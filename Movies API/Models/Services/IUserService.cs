using Movies_API.Models.Viewmodels;
using Movies_API.Models.Response;

namespace Movies_API.Models.Services
{
    public interface IUserService
    {

        UserResponse Auth(AuthViewmodel model);
    }
}
