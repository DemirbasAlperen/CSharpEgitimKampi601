# :boom: C# Eğitim Kampı (YouTube)

Merhabalar. Bu repomda Murat Yücedağ'ın YouTube kanalında vermiş olduğu C# Kampı eğitimi boyunca yapmış olduğu 601 seviye dersler ve projeler bulunmaktadır. Aşağıda her ders içerisinde yapılan projelerin teknik detayları bulunmaktadır. Yeni dersler ve projeler de yapıldıkça eklenecektir. :blush: 


# :sunny: Proje 24 (601) C# ile MongoDb Kullanımı 1
Bu projede; Burada MongoDb kullanarak form uygulamaları yaptık. MongoDB, NoSQL kategorisinde yer alan, doküman tabanlı bir veritabanı yönetim sistemidir. JSON benzeri BSON (Binary JSON) formatında veri saklar ve ilişkisel veritabanlarına (SQL tabanlı sistemlere) kıyasla daha esnek bir veri modeline sahiptir. MongoDb veritabanı adresimiz için bir class(MongoDbConnection) açtık ve adresimizi burada tuttuk. Açtığımız form içinde bulunan butonlardan sadece ekleme butonu kodları yazıldı ve birkaç kullanıcı eklemesi yazpıldı. 

# :sunny: Proje 25 (601) C# ile MongoDb Kullanımı 2
Bu projede; Bu derste yarım kalan form işlemlerini tamamladık. Öncelikle GetAll işlemini Listeleme butonu için yaptık. Sonrasında Silme, Güncelleme ve Id ye Göre Getir butonu için gerekli kodlar yazıldı ve çalıştırıldı. Aşağıya yapılan form sayfasının resmi eklenmiştir.  

![FrmMongoDb](https://github.com/DemirbasAlperen/CSharpEgitimKampi601/blob/master/FrmMongoDb.png)

# :sunny: Proje 26 (601) C# ile PostgreSQL Kullanımı 1
Bu projede; PostgreSql kullanımına geçtik ve özelliklerine değinildi. PostgreSQL (veya Postgres), açık kaynaklı, güçlü, nesne-ilişkisel bir veritabanı yönetim sistemidir. SQL standartlarını destekler ve büyük ölçekli, yüksek performans gerektiren uygulamalar için uygundur. MsSql de veri depolama sınırı varken PostgreSql de bu sınır yoktur ve tamamen ücretsizdir. PostgreSql de tablomuzu oluşturup, C# da FrmCustomer isimli bir form açtık ve mongoDb nin form tasarımını baz aldık. Sonrasında Ekle butonu kod sayfasını açıp EntityFramework6.Npgsql paketini paket yöneticisinden yükledik. Sonrasında tüm butonlar için gerekli kodları yazıp bu projeyi tamamladık. 

# :sunny: Proje 27 (601) C# ile PostgreSQL Kullanımı 2
Bu projede; PostgreSql e devam ettik ve ilişkili tablo üzernden bir uygulama yaptık. Bunun için FrmDepartment(departman) ve FrmEmployee(çalışan) isimli iki tane form dosyası açtık. Sonrasında PostgreSql i açıp orada bu ikisi için tablo oluşturduk. FrmEmployee için form tasarımını yaptık ve ekleme butonu için gerekli kodlar yazılarak proje çalıştırıldı. Aşağıya yapılan form sayfasının resmi eklenmiştir.

![FrmPostgreSql](https://github.com/DemirbasAlperen/CSharpEgitimKampi601/blob/master/FrmPostgreSql.png)
