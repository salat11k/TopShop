using System.Windows.Forms;
using TopShop.Models;
using TopShop.Repository.SellersRepository;

namespace TopShop2.Enums
{
    public class RegisterNewUser
    {
        public void RegisterUser(string fullname,string password,string phonenumber, ISellerRepository sellerRepository)
        {
            if (fullname == "" || password == "" || phonenumber == "")
                MessageBox.Show("Вы не заполнили все поля!", "Упс", MessageBoxButtons.OK);
            else
            {
                sellerRepository.Insert(new Seller() { FullName = fullname, Password = password, PhoneNumber = phonenumber });
            }
        }
    }
}
