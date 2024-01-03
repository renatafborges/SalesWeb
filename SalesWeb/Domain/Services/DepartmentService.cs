using SalesWeb.Domain.Interfaces;
using SalesWeb.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }
    }
}