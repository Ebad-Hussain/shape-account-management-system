using AutoMapper;
using ShapeAccountManagemenSystem.Application.Helpers;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Entities;
using ShapeAccountManagementSystem.Core.Interfaces;

namespace ShapeAccountManagemenSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(CreateUserReceivableDto user)
        {
            #region Check If email already registered or not
            var isEmailExist = _repository.Find(user => user.Email == user.Email).Result.Any();
            if (isEmailExist)
                return false;
            #endregion

            #region Insert New User To Database
            var newUser = _mapper.Map<User>(user);
            newUser.Hash = PasswordHashHelper.CreateSalt();
            newUser.Password = await PasswordHashHelper.Hash(user.Password, newUser.Hash);
            await _repository.Add(newUser);
            return true;
            #endregion
        }

        public async Task<bool> Login(string name, string password)
        {
            var user = _repository.Find(user => user.FirstName == name).Result.FirstOrDefault();
            if (user != null)
                return await PasswordHashHelper.VerifyPassword(password, Convert.ToBase64String(user?.Hash!), Convert.ToBase64String(user?.Password!));
            else 
                return false;
        }
    }
}
