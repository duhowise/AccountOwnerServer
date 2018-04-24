using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public IOwnerRepository Owner
        {
            get { return _owner ?? (_owner = new OwnerRepository(_repoContext)); }
        }

        public IAccountRepository Account
        {
            get { return _account ?? (_account = new AccountRepository(_repoContext)); }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}