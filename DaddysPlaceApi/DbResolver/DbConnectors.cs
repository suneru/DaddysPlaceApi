using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DaddysPlaceApi
{
    public class DbConnectors : IDbConnectors
    {
        private readonly SqlConnectionSettings _options;

        public DbConnectors(IOptions<SqlConnectionSettings> options)
        {
            this._options = options.Value;
        }

        public IDbConnection CreateConnection()
        {
            var con = new SqlConnection(_options.SqlConnectionString);
            con.Open();
            return con;
        }
    }
}
