using Microsoft.EntityFrameworkCore;
using SalesWeb.Data.Context;
using SalesWeb.Domain.Interfaces;
using SalesWeb.Domain.Models.Entities;
using SalesWeb.Domain.Models.InputModel;
using SalesWeb.Domain.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWeb.Data.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SalesWebContext _context;

        public SellerRepository(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Cannot delete seller because he/she has sales");
            }
        }

        public async Task<Seller> InsertAsync(AddSellerInputModel obj)
        {
            var seller = new Seller
            {
                Name = obj.Name,
                Email = obj.Email,
                BirthDate = obj.BirthDate,
                BaseSalary = obj.BaseSalary,
                Department = obj.Department,
                DepartmentId = obj.DepartmentId,
                Sales = obj.Sales
            };

            _context.Add(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundExcepction("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}