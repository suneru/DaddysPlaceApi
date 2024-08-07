using AutoMapper;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;
using DaddysPlaceApi.ViewEntity.AllViewEntity;

namespace DaddysPlaceApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            this._reportRepository = reportRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<AllBillViewEntity>> GetDateRangeWiseSales(DateTime StartDate,DateTime EndDate)
        {
            var bill = await _reportRepository.GetDateRangeWiseSales(StartDate, EndDate);
            var responce = _mapper.Map<IEnumerable<AllBillViewEntity>>(bill);
            return responce;
        }
    }
}
