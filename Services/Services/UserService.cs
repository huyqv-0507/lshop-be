using System;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Mapster;
using Services.ConvertionModels;
using Services.IServices;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public User GetUser(string username)
        {
            return userRepository.GetMany(user => username == user.UserName).FirstOrDefault();
        }

        public bool Login(string userName, string password)
        {
            User user = userRepository.Get(u => (userName == u.UserName && password == u.Password));
            if (user != null) return true;
            return false;
        }

        public void Register(RegisterModel registerModel)
        {
            User user = registerModel.Adapt<User>();
            //Set role for customer
            user.RoleId = 2;

            userRepository.Add(user);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }
    }
}
