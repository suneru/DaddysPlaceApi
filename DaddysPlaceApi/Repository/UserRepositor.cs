using DaddysPlaceApi.Entity;
using Dapper;



namespace DaddysPlaceApi.Repository
{
    public class UserRepositor :IUserRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public UserRepositor(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<UserEntity> CreateUser(UserEntity userEntity)
        {
            string sqlString = "INSERT INTO [User] (Name,ContactNumber,Email,Password,Status,Role) " +
                               " VALUES (@Name,@ContactNumber,@Email,@Password,@Status,@Role)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int userid = await con.ExecuteScalarAsync<int>(sqlString, userEntity);
            userEntity.Id = userid;
            return userEntity;
        }
        public async Task DeleteUser(int id)
        {
            string sqlString = "DELETE * FROM [User] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<UserEntity> GetUser(int id)
        {
            string sqlString = "SELECT * FROM [User] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var user = await con.QuerySingleOrDefaultAsync(sqlString,new {id});
            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            string sqlString = "SELECT * FROM [User]";
            var con = _dbConnectors.CreateConnection();
            var user = await con.QueryAsync<UserEntity>(sqlString);
            return user.ToList();
        }

        public async Task UpdateUser(int id, UserEntity userEntity)
        {
            string sqlString = "UPDATE [User] SET Name=@Name,ContactNumber=@ContactNumber,Email=@Email,Password=@Password,Status=@Status,Role=@Role " +
                               "WHERE Id=@Id";

            var con = _dbConnectors.CreateConnection();
             await con.ExecuteAsync(sqlString);
           
        }
    }
}
