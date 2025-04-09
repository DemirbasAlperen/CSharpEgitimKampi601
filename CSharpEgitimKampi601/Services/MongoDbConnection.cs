using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Services
{
    public class MongoDbConnection    // Bağlantı adresimi burada tutacağım
    {
        private IMongoDatabase _database;   // _database isimli field örnekledim

        public MongoDbConnection()   // Constructor (ctor yaz tab bas) 
        {
            var client = new MongoClient("mongodb://localhost:27017");  // MongoDb bağlantı adresi eklendi ve client içine atandı    
            _database = client.GetDatabase("Db601Customer");   // Db601Customer isimli veritabanı oluşturduk
        }

        public IMongoCollection<BsonDocument> GetCustomersCollection()
        {
            return _database.GetCollection<BsonDocument>("Customers");  // Db601Customer içine bir koleksiyon eklemiş olduk
        }
    }
}
