using SalesWeb.Domain.Interfaces.Repositories;
using SalesWeb.Domain.Interfaces.Services;
using SalesWeb.Models;
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