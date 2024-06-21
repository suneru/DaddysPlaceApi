using System.Data;

namespace DaddysPlaceApi
{
    public interface IDbConnectors
    {
        IDbConnection CreateConnection();
    }
}
