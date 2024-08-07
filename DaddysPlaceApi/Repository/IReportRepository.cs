using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Entity.AllEntity;

namespace DaddysPlaceApi.Repository
{
    public interface IReportRepository
    {
        public Task<IEnumerable<AllBillEntity>> GetDateRangeWiseSales(DateTime StartDate, DateTime EndDate);
    }
}
