using DaddysPlaceApi.Entity;

namespace DaddysPlaceApi.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetUsers();
        public Task<UserEntity> GetUser(int id);
        public Task<UserEntity> CreateUser(UserEntity userEntity);
        public Task UpdateUser(int id, UserEntity userEntity);
        public Task DeleteUser(int id);


    }
}
