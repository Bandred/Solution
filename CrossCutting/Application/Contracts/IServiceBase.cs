using CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossCutting.Application.Contracts
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> AddAsync(T model);

        Task<bool> ExistAsync(Guid id);

        Task<T> FindAsync(Guid id);

        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task<DataCollection<T>> GetPagedAsync(int page, int take);

        Task<bool> RemoveAsync(Guid id);

        Task<T> UpdateAsync(T model);
    }
}
