using System;
using System.Windows.Forms;
using TopShop.Models;
using TopShop.Repository.SellersRepository;

namespace TopShop2
{
    public partial class UpdateSellerWindow : Form
    {
        private ISellerRepository _sellerRepository;
        private UpdateSeller _updateSeller;

        public UpdateSellerWindow(ISellerRepository sellerRepository)
        {
            InitializeComponent();

            _sellerRepository = sellerRepository;
            _updateSeller = new UpdateSeller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _updateSeller.UpdateUser(textBox1.Text, textBox2.Text, textBox3.Text, (int)numericUpDown1.Value, _sellerRepository);
        }
    }
}
