using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopShop.Repository;
using TopShop2.Models;
using TopShop2.Repository.ProductRepository;

namespace TopShop2.Repository
{
    public partial class Form2 : Form
    {
        private IRepository<Product> _repository;
        private string _phoneNumber;



        public Form2(string phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;

            _repository = new MsSqlProducteRepository(FindOutSellerID());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _repository.Delete((int)numericUpDown1.Value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            InsertProductWindow insertProductWindow = new InsertProductWindow(_repository);
            insertProductWindow.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UpdateProducteWindow window = new UpdateProducteWindow(_repository);
            window.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowData();
        }




        private void ShowData()
        {
            listBox1.Items.Clear();

            var products = _repository.GetAll();

            foreach (var product in products)
            {
                listBox1.Items.Add($"ID : {product.Id} ,Title : {product.Title}, Price : {product.Price}");
            }
        }
        private int FindOutSellerID()
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ERULHJ1;Initial Catalog=TopShop;Integrated Security=True"))
            {
                connection.Open();


                SqlCommand command = new SqlCommand($"SELECT * FROM Seller WHERE PhoneNumber = {_phoneNumber};", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader.GetValue(0);
                    }
                }
                else
                {
                    return 0;
                }

                reader.Close();
            }
            return 0;
        }

    }
}
