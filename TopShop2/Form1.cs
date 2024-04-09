using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopShop.Repository.SellersRepository;
using TopShop2.Enums;

namespace TopShop2
{
    public partial class Form1 : Form
    {
        private ISellerRepository _repository;


        public Form1()
        {
            InitializeComponent();

            _repository = new MsSqlSellerRepository();

            ShowData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _repository.Delete((int)numericUpDown1.Value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            InsertWindow window = new InsertWindow(_repository);
            window.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UpdateSellerWindow window = new UpdateSellerWindow(_repository);
            window.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        private void ShowData()
        {
            listBox1.Items.Clear();

            var sellers =  _repository.GetAll();

            foreach(var seller in sellers) 
            {
                listBox1.Items.Add($"ID : {seller.Id} ,FullName : {seller.FullName}, Password : {seller.Password}, PhoneNumber : {seller.PhoneNumber}");
            }
        }

    }
}
