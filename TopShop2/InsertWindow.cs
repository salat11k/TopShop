using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopShop.Repository;
using TopShop.Repository.SellersRepository;

namespace TopShop2.Enums
{
    public partial class InsertWindow : Form
    {
        private ISellerRepository _repository;
        private RegisterNewUser _registser;

        public InsertWindow(ISellerRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            _registser = new RegisterNewUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _registser.RegisterUser(textBox1.Text, textBox2.Text, textBox3.Text, _repository);
            Close();
        }
    }
}
