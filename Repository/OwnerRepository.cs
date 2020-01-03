using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;

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
           var data= await FindAll();
               return data.OrderBy(ow => ow.Name);
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            var data=await FindByCondition(owner => owner.Id.Equals(ownerId));
            return data.FirstOrDefault();
        }

        public async Task<OwnerExtended> GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(await GetOwnerById(ownerId))
            {
                Accounts = RepositoryContext.Accounts
                    .Where(a => a.OwnerId == ownerId)
            };
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