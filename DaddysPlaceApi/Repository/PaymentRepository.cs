using DaddysPlaceApi.Entity;
using Dapper;



namespace DaddysPlaceApi.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public PaymentRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<PaymentEntity> CreatePayment(PaymentEntity paymentEntity)
        {
            string sqlString = "INSERT INTO [Payment] (Receive_Amount,Balance_Amount,Payment_Type,Frn_OrderId) " +
                               " VALUES (@Receive_Amount,@Balance_Amount,@Payment_Type,@Frn_OrderId)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int paymentid = await con.ExecuteScalarAsync<int>(sqlString, paymentEntity);
            paymentEntity.Id = paymentid;
            return paymentEntity;
        }
        public async Task DeletePayment(int id)
        {
            string sqlString = "DELETE  FROM [Payment] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<PaymentEntity> GetPayment(int id)
        {
            string sqlString = "SELECT * FROM [Payment] WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var payment = await con.QuerySingleOrDefaultAsync<PaymentEntity>(sqlString, new { id });
            return payment;
            
        }

        public async Task<IEnumerable<PaymentEntity>> GetPayments()
        {
            string sqlString = "SELECT * FROM [Payment]";
            var con = _dbConnectors.CreateConnection();
            var payment = await con.QueryAsync<PaymentEntity>(sqlString);
            return payment.ToList();
        }

        public async Task UpdatePayment(int id, PaymentEntity paymentEntity)
        {
            string sqlString = "UPDATE [Payment] SET Receive_Amount=@Receive_Amount,Balance_Amount=@Balance_Amount,Payment_Type=@Payment_Type,Frn_OrderId=@Frn_OrderId " +
                               "WHERE Id=@Id";
            paymentEntity.Id=id;
            var con = _dbConnectors.CreateConnection();
             await con.ExecuteAsync(sqlString, paymentEntity);
           
        }
    }
}
