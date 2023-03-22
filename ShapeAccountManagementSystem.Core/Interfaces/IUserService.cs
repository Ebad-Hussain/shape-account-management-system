using ShapeAccountManagementSystem.Core.Entities;

namespace ShapeAccountManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUser(User user);
    }
}
