using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Repository;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Mvc;

namespace DaddysPlaceApi.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepositor _billRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepositor billRepository, IMapper mapper)
        {
            this._billRepository = billRepository;
            this._mapper = mapper;
        }

        public async Task<BillViewEntity> CreateBill(BillViewEntity billViewEntity)
        {
            var entity = _mapper.Map<BillEntity>(billViewEntity);
            var createBill = await _billRepository.CreateBill(entity);
            var responce = _mapper.Map<BillViewEntity>(createBill);
            return responce;
        }

        public async Task DeleteBill(int id)
        {
            await _billRepository.DeleteBill(id);
        }

        public async Task<BillViewEntity> GetBill(int id)
        {
            var bill = await _billRepository.GetBill(id);
            var responce = _mapper.Map<BillViewEntity>(bill);
            return responce;
        }

        public async Task<IEnumerable<BillViewEntity>> GetBills()
        {
            var bill = await _billRepository.GetBills();
            var responce = _mapper.Map<IEnumerable<BillViewEntity>>(bill);
            return responce;
        }

        public async Task UpdateBill(int id, BillViewEntity billViewEntity)
        {
            var entity = _mapper.Map<BillEntity>(billViewEntity);
            await _billRepository.UpdateBill(id, entity);
        }

       
    }
}
