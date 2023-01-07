using Newtonsoft.Json;
using ProiectSincretic.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSincretic
{
    public sealed class DatabaseService
    {

        string DbPath { get; set; }
        SQLiteConnection Connection = null;
        SQLiteAsyncConnection AsyncConnection = null;
        public DatabaseService(string db,bool asyncDb = false) 
        {
            DbPath = db;
            if (string.IsNullOrEmpty(DbPath)) { throw new ArgumentNullException(); }

            if(!asyncDb)
            {
                Connection = new SQLiteConnection(DbPath);
                Connection.CreateTable(typeof(Product));
                Connection.CreateTable(typeof(LiteTable));
            }
           else
            {
               

                Load();
            }
           
        }

        async void Load()
        {
            try
            {
                AsyncConnection = new SQLiteAsyncConnection(DbPath);
                await AsyncConnection.CreateTableAsync(typeof(Product));
               await AsyncConnection.CreateTableAsync(typeof(LiteTable));
            }
            catch (Exception ex)
            {
;
            }
        }
        public void Inser(object obj)
        {
            


            Connection.InsertOrReplace(obj);
            
        }
        public async Task<int> AsyncInser(object obj)
        {


           return await AsyncConnection.InsertAsync(obj);

        }

        public void BulkInser(IEnumerable<object> obj)
        {

            Connection.InsertAll(obj);

        }
        public object Read(int id,Type t)
        {
           
            return Connection.Get(id,new TableMapping(t));
        }
        public IEnumerable<object> ReadAllProduct()
        {
            return Connection.Table<Product>().ToList();
        }
        public IEnumerable<object> ReadAllLiteTable()
        {
            return Connection.Table<LiteTable>().Select(x => JsonConvert.DeserializeObject<Product>(x.ObjectSource)).ToList();
        }
     
    }
}
