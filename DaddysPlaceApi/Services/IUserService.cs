using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewEntity>> GetUsers();
        public Task<UserViewEntity> GetUser(int id);
        public Task<UserViewEntity> GetUserName(UserViewEntity userViewEntity);
        public Task<UserViewEntity> CreateUser(UserViewEntity userViewEntity);
        public Task UpdateUser(int id, UserViewEntity userViewEntity);
        public Task DeleteUser(int id);
    }
}
