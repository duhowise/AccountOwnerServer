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

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
          return await FindAll().ToListAsync();
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefaultAsync();
        }

        public async Task<Owner> GetOwnerWithDetails(Guid ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId)).Include(ac=>ac.Accounts).FirstOrDefaultAsync();
        }

        public async Task CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
          await  Create(owner);
           await Save();
        }

        public async Task DeleteOwner(Owner owner)
        {
          await  Delete(owner);
           await Save();
        }

        public async Task UpdateOwner(Owner dbOwner, Owner owner)
        {
           dbOwner.Map(owner);
            await Update(dbOwner);
           await Save();
        }
    }
}