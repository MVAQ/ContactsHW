using ContactsHW.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsHW.Services.Repository
{
    public interface IRepository
    {
        Task<int> InsertAsync<T>(T entity) where T : IEntityBase,new();
        Task<int> UpdateAsync<T>(T entity) where T : IEntityBase, new();
        Task<int> DeleteAsync<T>(T entity) where T : IEntityBase, new(); 
        Task<List<T>> GetAllAsync<T>(T entity) where T : IEntityBase, new();
        Task<T> FindWithCommandAsync<T>(string sqlCommand) where T : IEntityBase, new();
    }
}