
using DaddysPlaceApi.ViewEntity;
using DaddysPlaceApi.ViewEntity.AllViewEntity;

namespace DaddysPlaceApi.Services
{
    public interface IReportService
    {
        public Task<IEnumerable<AllBillViewEntity>> GetDateRangeWiseSales(DateTime startDate, DateTime endDate);
    }
}
