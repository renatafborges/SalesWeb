using SalesWeb.Domain.Interfaces.Repositories;
using SalesWeb.Domain.Interfaces.Services;
using SalesWeb.Models;
using SalesWeb.Models.InputModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<Seller> InsertAsync(AddSellerInputModel obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public async Task UpdateAsync(Seller obj)
        {
            await _repository.UpdateAsync(obj);
        }
    }
}