using DaddysPlaceApi.Entity;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetUsers();
        public Task<UserEntity> GetUser(int id);
        public Task<UserEntity> GetUserName(string email,string password);
        public Task<UserEntity> GetUserexist(string email);
        public Task<UserEntity> CreateUser(UserEntity userEntity);
        public Task UpdateUser(int id, UsereditEntity userEditEntity);
        public Task UpdateUserRole(int id, UserEditRoleEntity userEditRoleEntity);
        public Task DeleteUser(int id);


    }
}
