using SalesWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}