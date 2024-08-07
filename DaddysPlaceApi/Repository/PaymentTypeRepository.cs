using DaddysPlaceApi.Entity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class PaymentTypeRepository: IPaymentTypeRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public PaymentTypeRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<PaymentTypeEntity> GetPaymentType(int id)
        {
            string sqlString = "SELECT * FROM PaymentType WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var paymentType = await con.QuerySingleOrDefaultAsync<PaymentTypeEntity>(sqlString, new { id });
            return paymentType;
        }


        public async Task<IEnumerable<PaymentTypeEntity>> GetPaymentTypes()
        {
            string sqlString = "SELECT * FROM PaymentType";
            var con = _dbConnectors.CreateConnection();
            var paymentType = await con.QueryAsync<PaymentTypeEntity>(sqlString);
            return paymentType.ToList();
        }

    }
}
