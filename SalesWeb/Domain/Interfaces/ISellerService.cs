﻿using SalesWeb.Domain.Models.Entities;
using SalesWeb.Domain.Models.InputModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Interfaces
{
    public interface ISellerService
    {
        Task<List<Seller>> FindAllAsync();
        Task<Seller> FindByIdAsync(int id);
        Task RemoveAsync(int id);
        Task<Seller> InsertAsync(AddSellerInputModel obj);
        Task UpdateAsync(Seller obj);
    }
}