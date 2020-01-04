using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
          return await FindAll().OrderBy(ow=>ow.Name).ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId)).Include(ac=>ac.Accounts).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task CreateOwnerAsync(Owner owner)
        {
            owner.Id = Guid.NewGuid();
          await  Create(owner);
           await Save();
        }

        public async Task DeleteOwnerAsync(Owner owner)
        {
          await  Delete(owner);
           await Save();
        }

        public async Task UpdateOwnerAsync(Owner dbOwner)
        {
            await Update(dbOwner);
           await Save();
        }
    }
}