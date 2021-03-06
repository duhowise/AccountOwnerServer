﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<List<Account>> AccountsByOwner(Guid ownerId)
        {
            return await FindByCondition(o => o.OwnerId.Equals(ownerId)).AsNoTracking().ToListAsync();
        }
    }
}