namespace SGT.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUserRepository { get; }
        IApplicationRoleRepository ApplicationRoleRepository { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
        void BeginTransaction();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}
