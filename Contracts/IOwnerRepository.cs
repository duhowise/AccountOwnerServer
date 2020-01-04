using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Extensions;
using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
       Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(Guid ownerId);
        Task<Owner> GetOwnerWithDetails(Guid ownerId);
        Task CreateOwner(Owner owner);
        Task DeleteOwner(Owner owner);
        Task UpdateOwner(Owner ownerEntity);
    }
}