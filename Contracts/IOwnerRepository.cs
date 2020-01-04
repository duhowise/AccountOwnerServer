using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Extensions;
using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
       Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);
        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);
        Task CreateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner ownerEntity);
    }
}