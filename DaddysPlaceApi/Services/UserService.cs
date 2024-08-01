using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;



namespace DaddysPlaceApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserViewEntity> CreateUser(UserViewEntity userViewEntity)
        {
            var entity = _mapper.Map<UserEntity>(userViewEntity);
            var createUser = await _userRepository.CreateUser(entity);
            var responce = _mapper.Map<UserViewEntity>(createUser);
            return responce;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<UserViewEntity> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            var responce = _mapper.Map<UserViewEntity>(user);
            return responce;
        }

        public async Task<UserViewEntity> GetUserName(string email, string password)
        {
            var user = await _userRepository.GetUserName(email, password);
            var responce = _mapper.Map<UserViewEntity>(user);
            return responce;
        }

        public async Task<IEnumerable<UserViewEntity>> GetUsers()
        {
            var users= await _userRepository.GetUsers();
            var responce=_mapper.Map<IEnumerable<UserViewEntity>> (users);
            return responce;
        }

        public async Task UpdateUser(int id, UserViewEntity userViewEntity)
        {
            var entity = _mapper.Map<UserEntity>(userViewEntity);
            await _userRepository.UpdateUser(id,entity);
        }
    }
}
