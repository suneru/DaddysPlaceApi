using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Entity.AllEntity;
using Dapper;

namespace DaddysPlaceApi.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbConnectors _dbConnectors;

        public ReportRepository(IDbConnectors dbConnectors)
        {
            this._dbConnectors = dbConnectors;
        }

        public async Task<IEnumerable<AllBillEntity>> GetDateRangeWiseSales(DateTime StartDate, DateTime EndDate)
        {
            string sqlString = "SELECT  Bill.Frn_OrderId as Id, Bill.CreateOn, Bill.Frn_UserId,  Bill.TotalAmount As BillTotal,[User].email, PaymentType.PaymentType, (select sum(Bill.TotalAmount) from Bill  where Bill.CreateOn between @StartDate and @EndDate ) As TotalAmount FROM Bill INNER JOIN PaymentType ON Bill.Frn_PaymentId = PaymentType.Id INNER JOIN [User] ON Bill.Frn_UserId = [User].Id where Bill.CreateOn between @StartDate and @EndDate ";
            var con = _dbConnectors.CreateConnection();
            var categories = await con.QueryAsync<AllBillEntity>(sqlString, new { StartDate, EndDate });
            return categories;
        }

    }
}
