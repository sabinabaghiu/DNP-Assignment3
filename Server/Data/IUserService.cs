using Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}