using CSharpEgitimKampi601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)   // Ekle Butonu İçin  // Dışarıdan Customer türünde customer ekledik 
        {
            var connection = new MongoDbConnection();    // Burada MongoDbConnection(hazırladığımız sınıf) hazırlandı. Yani bağlantı adresi ve veri tabanına eriştim.
            var customerCollection = connection.GetCustomersCollection();   // Burada tabloya erişmiş oldum

            var document = new BsonDocument     // burada ekleme işlemi için gerekli olan parametreleri ekledim
            {
                {"CustomerName", customer.CustomerName },   // "CustomerName" customer deki CustomerName den gelecek
                {"CustomerSurname", customer.CustomerSurname },
                {"CustomerCity", customer.CustomerCity },
                {"CustomerBalance", customer.CustomerBalance },
                {"CustomerShoppingCount", customer.CustomerShoppingCount }
            };

            customerCollection.InsertOne(document);  // customerCollection içine document den gelen değerleri ekledik. MongoDb de kullanılan ekleme metodu InsertOne() dur
        }

        public List<Customer> GetAllCustomer()   // Listele Butonu İçin
        {
            var connection = new MongoDbConnection();   // MongoDb ile bağlantımızı oluşturduk
            var customerCollection = connection.GetCustomersCollection();   // GetCustomersCollection() metodu ile Customer sınıfıma ait değerleri(tabloya erişim) getirdim. Bu metot MongoDbConnection sınıfımın içinde
            var customers = customerCollection.Find(new BsonDocument()).ToList();   // MongoDb deki dökümanları getirmek için burada yeni bir BsonDocument() kullanıyoruz. Ayrıca customerCollection içindeki verileri hafızaya(customers) almış oldum
            List<Customer> customerList = new List<Customer>();  // Customer türünde yeni bir boş Customer listesi oluşturdum.
            foreach (var c in customers)   // burada döngü yazarak customers içinde gezdik ve verileri yukarıda oluşturduğumuz boş liste içine attık
            {
                customerList.Add(new Customer    // ve customerList içine aşağıdaki parametreleri (Add)ekledik.
                {
                    CustomerId = c["_id"].ToString(),   // burada MondoDb _id olarak kaydettiği için buraya da _id yazdık.
                    CustomerBalance = decimal.Parse(c["CustomerBalance"].ToString()),
                    CustomerCity = c["CustomerCity"].ToString(),
                    CustomerName = c["CustomerName"].ToString(),
                    CustomerShoppingCount = int.Parse(c["CustomerShoppingCount"].ToString()),
                    CustomerSurname = c["CustomerSurname"].ToString()
                });
            }
            return customerList;   // sonra Listeyi geriye döndürdük
        }

        public void DeleteCustomer(string id)   // Silme Butonu İçin   // id ye göre silme işlemi yapacak
        {
            var connection = new MongoDbConnection();  // MongoDb bağlantısını yaptık
            var customerCollection = connection.GetCustomersCollection();  // Veritabanına erişim sağladım
            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(id));        // silinecek değeri filtreledik
            customerCollection.DeleteOne(filter);  // MongoDb de silme işlemi
            
            // Builders<BsonDocument>.Filter → MongoDB için filtre oluşturmayı sağlayan yardımcı sınıftır.
            // .Eq("_id", ObjectId.Parse(id)) → _id alanının verilen değere eşit olduğu belgeyi bul anlamına gelir.
            // "_id" → MongoDB'deki her belgenin benzersiz kimliği (primary key) olan ObjectId alanıdır.
            // ObjectId.Parse(id) → id değişkenini bir ObjectId nesnesine çevirir. (Çünkü MongoDB'nin _id alanı string değil, ObjectId türündedir.)
        }

        public void UpdateCustomer(Customer customer)     // Güncelle Butonu İçin   // Customer türünde customer property si alacak
        {
            var connection = new MongoDbConnection();   // bağlantı oluşturuldu
            var customerCollection = connection.GetCustomersCollection();   // Veritabanına erişim sağladım
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerId));    // Hangi belgeyi güncelleyeceğini belirler
            var updatedValue = Builders<BsonDocument>.Update       // aşağıda güncellenecek değerleri giriyoruz.
                .Set("CustomerName", customer.CustomerName)
                .Set("CustomerSurname", customer.CustomerSurname)
                .Set("CustomerCity", customer.CustomerCity)
                .Set("CustomerBalance", customer.CustomerBalance)
                .Set("CustomerShoppingCount", customer.CustomerShoppingCount);
            customerCollection.UpdateOne(filter, updatedValue);       // MongoDb de güncelleme işlemi UpdateOne dır.
        }

        public Customer GetCustomerById(string id)     // Id'ye Göre Getirme 
        {
            var connection = new MongoDbConnection();  // Bağlantı oluşturuldu
            var customerCollection = connection.GetCustomersCollection();    // Koleysiyona bağlanıldı
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));    // id ye göre filtre yapıldı  // Eq : eşitlik
            var result = customerCollection.Find(filter).FirstOrDefault();    // Find : bulmak
            return new Customer    // Yeni bir Customer oluşturduk ve döndüreceği değerleri aşağıda girdik. 
            {
                CustomerBalance = decimal.Parse(result["CustomerBalance"].ToString()),
                CustomerCity = result["CustomerCity"].ToString(),
                CustomerId = id,
                CustomerName = result["CustomerName"].ToString(),
                CustomerShoppingCount = int.Parse(result["CustomerShoppingCount"].ToString()),
                CustomerSurname = result["CustomerSurname"].ToString()
            };

        }
    }
}
