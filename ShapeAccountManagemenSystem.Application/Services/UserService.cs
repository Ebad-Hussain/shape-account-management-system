using ShapeAccountManagementSystem.Core.Entities;
using ShapeAccountManagementSystem.Core.Interfaces;

namespace ShapeAccountManagemenSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateUser(User user)
        {
            var isEmailExist = await _repository.Find(f => f.Email == user.Email);
            if (isEmailExist != null)
                return false;

            await _repository.Add(user);
            return true;
        }
    }
}
