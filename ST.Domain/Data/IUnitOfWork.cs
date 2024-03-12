using System;
using System.Threading.Tasks;

namespace ST.Domain.Data;

public interface IUnitOfWork :  IDisposable
{
    Task<int> CommitAsync();
    Task RollbackAsync();
}