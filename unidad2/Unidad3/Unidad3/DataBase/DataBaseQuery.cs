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
            _database.CreateTableAsync<ContactosModel>().Wait();
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

        public Task<List<ContactosModel>> GetContacModel()
        {
            return _database.Table<ContactosModel>().ToListAsync();
        }

        public Task<List<T>> GetTableModel<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
        {
            if (isInsert != true)
            {
                return _database.UpdateAsync(model);
            }
            else
            {
                return _database.InsertAsync(model);
            }
        }


        public Task<int> DeleteModelAsync<T>(T model) where T : new()
        {
           
                return _database.DeleteAsync(model);
          
        }
        public Task<List<T>> QueryModel<T>(string query) where T : new()
        {
            return _database.QueryAsync<T>(query);
        }

        public Task<List<UserModel>> ValidateUserModel(string usr, string pw)
        {
            return _database.QueryAsync<UserModel>("SELECT * FROM UserModel WHERE Usuario = '"+ usr + "' AND Pw = '" + pw + "' ");
        }

        public Task<UserModel> GetUserModel(string usr, string pw)
        {
            return _database.Table<UserModel>().Where(i => i.Usuario == usr && i.Pw ==pw).FirstOrDefaultAsync();

        }




        #endregion
    }
}
