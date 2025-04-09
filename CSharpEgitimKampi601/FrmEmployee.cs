using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class FrmEmployee: Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postgres;Password=54321";   // PostgreSql veritabanı bağlantı adresi

        void EmployeeList()    // Listeleme metodu
        {
            var connection = new NpgsqlConnection(connectionString);   // connection içine yukarıdaki adresi atadım
            connection.Open();   // bağlantıyı açtık
            string query = "select * from Employees";   // sql sorgumu yazdım
            var command = new NpgsqlCommand(query, connection);   // command içine sorgumu ve bağlantı adresimi atadım
            var adapter = new NpgsqlDataAdapter(command);    // command nesnesini temel alan bir veri adaptörü oluşturur.  // NpgsqlDataAdapter, PostgreSQL veritabanından veri alıp bir DataTable veya DataSet içerisine doldurmak için kullanılan bir bileşendir. Aynı zamanda, değişiklikleri veritabanına geri göndermek için de kullanılabilir.
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);   // veritabanından gelen verileri bir DataTable nesnesine doldurur.   // adapter bir NpgsqlDataAdapter nesnesidir ve PostgreSQL veritabanından veri çekmek için kullanılır. // Fill(dataTable) metodu, belirtilen dataTable nesnesine verileri doldurur.
            dataGridView1.DataSource = dataTable;    // dataTable ı ekrana yazdırdık.
            connection.Close();   // bağlantıyı kapattım.
        }

        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "select * from Departments";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbEmployeeDepartment.DisplayMember = "DepartmentName";     // Yukarıdan farklı olarak biz burada verileri listelemedik amacımız combobox üzerinde departmanları getirmek istiyoruz.
            cmbEmployeeDepartment.ValueMember = "DepartmentId";
            cmbEmployeeDepartment.DataSource = dataTable;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)   // Listeleme için yukarıda metot tanımlıyoruz ve o metodu burada kullanıyoruz.
        {
            EmployeeList();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)  // Form sayfası açıldığında yukarıdaki her iki metodunda çalışmasını istedik.
        {
            EmployeeList();
            DepartmentList();
        }

        private void btnCreate_Click(object sender, EventArgs e)    // Ekleme butonu için
        {
            string employeeName = txtEmployeeName.Text;
            string employeeSurname = txtEmployeeSurname.Text;
            decimal employeeSalaray = decimal.Parse(txtEmployeeSalary.Text);
            int departmentId = int.Parse(cmbEmployeeDepartment.SelectedValue.ToString());

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into Employees (EmployeeName,EmployeeSurname,EmployeeSalary,Departmentid) values (@employeeName,@employeeSurname,@employeeSalary,@departmentid)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeName", employeeName);
            command.Parameters.AddWithValue("@employeeSurname", employeeSurname);
            command.Parameters.AddWithValue("@employeeSalary", employeeSalaray);
            command.Parameters.AddWithValue("@departmentid", departmentId);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close();
            EmployeeList();
        }
    }
}
