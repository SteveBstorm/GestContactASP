using Dal.Entities;

namespace Dal.Interface
{
    public interface IUserService
    {
        void Insert(string Email, string Password, string ScreenName);
        User Login(string Email, string Password);
    }
}