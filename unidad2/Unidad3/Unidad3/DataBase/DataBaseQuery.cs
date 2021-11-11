using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unidad3.Models;




namespace Unidad3.DataBase
{
    public class DataBaseQuery
    {
        readonly SQLiteAsyncConnection _database;

        public DataBaseQuery(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        #region CRUD    
        public Task<int> SaveUserModelAsync(UserModel usermodel)
        {
            if(usermodel.UserID != 0)
            {
                return _database.UpdateAsync(usermodel);
            }
            else
            {
                return _database.InsertAsync(usermodel);
            }
        }


        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }


        #endregion
    }
}
