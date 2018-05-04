﻿using System;
using System.Collections.Generic;
using Entities.Extensions;
using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        OwnerExtended GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void DeleteOwner(Owner owner);
        void UpdateOwner(Owner dbOwner, Owner owner);
    }
}