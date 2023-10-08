using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Domain.Interfaces.Repositories;
using SalesWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SalesWebContext _context;

        public DepartmentRepository(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        } 
    }
}