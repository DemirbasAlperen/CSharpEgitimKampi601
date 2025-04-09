using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class FrmCustomer: Form      // PostgreSql İşlemleri İçin
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postgres;Password=54321";   // PostgreSql için bağlantı adresi
        
        void GetAllCustomers()     // Bütün Customer ları getirecek olan metot(aşağıdaki tüm metotlar içinde kullanacağımız için bu metodu buraya yazdık)
        {
            var connection = new NpgsqlConnection(connectionString);   // burada connection değişkeni tanımlayarak yukarıdaki bağlantı adresini okudum
            connection.Open(); //  bağlantıyı açtım
            string query = "Select * From Customers";    // tablomu getirmek için gerekli sql sorgumu yazdım 
            var command = new NpgsqlCommand(query, connection);  //  Command içine query ve connection u gönderdim
            var adapter = new NpgsqlDataAdapter(command);   //  NpgsqlDataAdapter; datagridview ile PostgreSql arasında köprü görevi görmektedir.
            DataTable dataTable = new DataTable();  // bir dataTable oluşturdum.
            adapter.Fill(dataTable);   // dataTable ile doldur
            dataGridView1.DataSource = dataTable;     // dataTable ı ekrana yazdırdık.
            connection.Close();  // bağlantıyı kapattım.

        }
        private void btnCustomerList_Click(object sender, EventArgs e)   // Listeleme butonu
        {
            GetAllCustomers();   // yukarıda yazdığımız metodu kulllandım.
        }

        private void btnCustomerCreate_Click(object sender, EventArgs e)   // Ekleme butonu
        {
            string customerName = txtCustomerName.Text;
            string customerCity = txtCustomerCity.Text;
            string customerSurname = txtCustomerSurname.Text;
            var connection = new NpgsqlConnection(connectionString);  // Bağlantı adresimi bağladım
            connection.Open();   // bağlantıyı açtık
            string query = "insert into Customers (CustomerName,CustomerSurname,CustomerCity) values (@customerName,@customerSurname,@customerCity)";   // sql sorgusu ile ekleme işlemini yaptık ve eklenecek değerleri atadık
            var command = new NpgsqlCommand(query, connection);    //  Command içine query ve connection u gönderdim
            command.Parameters.AddWithValue("@customerName", customerName);   // buradan itibaren parametrelerimi girdim.
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();    // Değişiklikleri sql tarafına kaydettik.
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close(); // bağlantıyı kapattık
            GetAllCustomers();   // yukarıdaki metodu çağırdık
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)  // Silme Butonu
        {
            int id = int.Parse(txtCustomerId.Text);   // Silme işlemi için id kullanacağız.
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete From Customers where CustomerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi başarılı");
            connection.Close();
            GetAllCustomers();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)   // Güncelleme Butonu
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update Customers Set CustomerName=@customerName,CustomerSurname=@customerSurname,CustomerCity=@customerCity where CustomerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi başarılı");
            connection.Close();
            GetAllCustomers();
        }
    }
}
