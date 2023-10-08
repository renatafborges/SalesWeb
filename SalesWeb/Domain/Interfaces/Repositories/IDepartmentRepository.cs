using SalesWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> FindAllAsync();
    }
}