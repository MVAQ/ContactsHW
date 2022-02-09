
using ContactsHW.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ContactsHW.Services.Repositorys
{ 
    public class UserRepository : IRepository
    {
        private Lazy<SQLiteAsyncConnection> _database;
        public UserRepository() 
        {
            _database = new Lazy<SQLiteAsyncConnection>(() =>
              {
                  var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userDB.db3");
                  var database = new SQLiteAsyncConnection(path);
                  database.CreateTableAsync<UserModel>();
                  return database;
              });
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : IEntityBase, new()
        {
            return await _database.Value.DeleteAsync(entity);
        }
        public async Task<List<T>> GetAllAsync<T>() where T : IEntityBase, new()
        {
            return await _database.Value.Table<T>().ToListAsync();
        }
        public async Task<int> InsertAsync<T>(T entity) where T : IEntityBase, new()
        {
            return await _database.Value.InsertAsync(entity);
        }
        public async Task<int> UpdateAsync<T>(T entity) where T : IEntityBase, new()
        {
            return await _database.Value.UpdateAsync(entity);
        }

    }
}

