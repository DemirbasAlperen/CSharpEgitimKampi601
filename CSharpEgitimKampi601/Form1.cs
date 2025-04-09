using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();   // burada CustomerOperations sınıfından customerOperations nesne örneği aldım.
        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            var customer = new Customer()      
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text)
            };

            customerOperations.AddCustomer(customer);    // customer içine yukarıda yazdığımız verileri AddCustomer kullanarak ekledik
            MessageBox.Show("Müşteri ekleme işlemi başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();    // CustomerOperations da oluşturduğum Listeleme metodumu buraya ekledim ve aşağıda da ekrana yazdırdım.
            dataGridView1.DataSource = customers;
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;    // string türde customerId tanımladık ve txtCustomerId label ıyla eşitledik
            customerOperations.DeleteCustomer(customerId);   // CustomerOperation servisi içine yazdığımız DeleteCustomer metodu ile customerId sine göre silme işlemini buraya çağırdık
            MessageBox.Show("Müşteri Başarıyla Silindi");
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var updateCustomer = new Customer()    // Güncellenecek değerleri Customer türüne çevirerek ve label içine atama yaparak ilerlemem gerekiyor.
            {
                CustomerName = txtCustomerName.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text),
                CustomerSurname = txtCustomerSurname.Text,
                CustomerId = id
            };
            customerOperations.UpdateCustomer(updateCustomer);   // CustomerOperation servisi içine yazdığımız UpdateCustomer metodunu kullanarak updateCustomer olarak tanımladığımız yeni Customer ın güncellemesini yaptık
            MessageBox.Show("Müşteri Başarıyla Güncellendi");
        }

        private void btnGetByCustomerId_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers };   // Ekrana yeni bir liste olarak Customer ı al ve customers ı gönder
        }
    }
}
