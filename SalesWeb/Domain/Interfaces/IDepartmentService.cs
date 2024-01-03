using SalesWeb.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}