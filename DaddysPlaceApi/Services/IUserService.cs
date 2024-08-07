﻿using DaddysPlaceApi.Entity;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewEntity>> GetUsers();
        public Task<UserViewEntity> GetUser(int id);
        public Task<UserViewEntity> GetUserName(string email, string password);
        public Task<UserViewEntity> GetUserexist(string email);
        public Task<UserViewEntity> CreateUser(UserViewEntity userViewEntity);
        public Task UpdateUser(int id, UserVEditEntity userVEditEntity);
        public Task UpdateUserRole(int id, UserEditVRoleEntity userEditVRoleEntity);
        public Task DeleteUser(int id);
    }
}
