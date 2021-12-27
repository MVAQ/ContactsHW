using ContactsHW.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsHW.Services.Repositorys
{
    internal interface IUserRepository
    {
        Task<int> InsertAsync<T>(T entity) where T : IEntityBase, new();
    }
}
