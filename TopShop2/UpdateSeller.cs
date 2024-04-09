using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopShop.Models;
using TopShop.Repository.SellersRepository;

namespace TopShop2
{
    public class UpdateSeller
    {
        public void UpdateUser(string fullname, string password, string phonenumber,int id, ISellerRepository sellerRepository)
        {
            if (fullname == "" || password == "" || phonenumber == "")
                MessageBox.Show("Вы не заполнили все поля!", "Упс", MessageBoxButtons.OK);
            else
            {
                sellerRepository.Update(new Seller() { FullName = fullname, Password = password, PhoneNumber = phonenumber },id);
            }
        }
    }
}
