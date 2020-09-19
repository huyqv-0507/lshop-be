using System;
using Data.Models;
using Services.ConvertionModels;

namespace Services.IServices
{
    public interface IUserService
    {
        bool Login(string userName, string password);
        void Register(RegisterModel registerModel);
        User GetUser(string username);
        void UpdateUser(User user);
        void Save();
    }
}
