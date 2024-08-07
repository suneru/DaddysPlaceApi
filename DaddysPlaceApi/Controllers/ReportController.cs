using DaddysPlaceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ILogger<ReportController> _Logger { get; }

        public ReportController(IReportService reportService, ILogger<ReportController> logger)
        {
            this._reportService = reportService;
            _Logger = logger;
        }

       

        [HttpGet("ReportListAdvance/{StartDate}/{EndDate}")]
        public async Task<IActionResult> ReportListAdvance(DateTime StartDate, DateTime EndDate)
        {
            var bills = await _reportService.GetDateRangeWiseSales(StartDate, EndDate);
            if (bills == null)
            {
                return NotFound();
            }
            return Ok(bills);
        }

    }
}
