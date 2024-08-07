using DaddysPlaceApi.Entity;
using DaddysPlaceApi.ViewEntity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class BillRepositor : IBillRepositor
    {
        private readonly IDbConnectors _dbConnectors;

        public BillRepositor(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<BillEntity> CreateBill(BillEntity billEntity)
        {
            string sqlString = "INSERT INTO Bill (CreateOn,Frn_UserId,Frn_PaymentId,Frn_OrderId,TotalAmount) " +
                               " VALUES (@CreateOn,@Frn_UserId,@Frn_PaymentId,@Frn_OrderId,@TotalAmount)" +
                               "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var con = _dbConnectors.CreateConnection();
            int billId = await con.ExecuteScalarAsync<int>(sqlString, billEntity);
            billEntity.Id = billId;
            return billEntity;
        }
        public async Task DeleteBill(int id)
        {
            string sqlString = "DELETE  FROM Bill WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            await con.QueryAsync(sqlString, new { id });
        }

        public async Task<BillEntity> GetBill(int id)
        {
            string sqlString = "SELECT * FROM Bill WHERE Id=@Id";
            var con = _dbConnectors.CreateConnection();
            var billId = await con.QuerySingleOrDefaultAsync<BillEntity>(sqlString, new { id });
            return billId;
        }

        public async Task<IEnumerable<BillEntity>> GetBills()
        {
            string sqlString = "SELECT * FROM Bill";
            var con = _dbConnectors.CreateConnection();
            var bill = await con.QueryAsync<BillEntity>(sqlString);
            return bill.ToList();
        }

        public async Task UpdateBill(int id, BillEntity billEntity)
        {
            string sqlString = "UPDATE [Bill] SET CreateOn=@CreateOn,Frn_UserId=@Frn_UserId,Frn_PaymentId=@Frn_PaymentId,Frn_OrderId=@Frn_OrderId,TotalAmount=@TotalAmount " +
                               "WHERE Id=@Id";
            billEntity.Id=id;
            var con = _dbConnectors.CreateConnection();
            await con.ExecuteAsync(sqlString, billEntity);

        }

        public async Task<BillOrdernoEntity> GetBillOrderNo()
        {
            string sqlString = "select next value for OrderNo AS BillOrderNo";
            var con = _dbConnectors.CreateConnection();
            var billId = await con.QuerySingleOrDefaultAsync<BillOrdernoEntity>(sqlString);
            return billId;
        }
    }
}
