using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopShop.Repository.SellersRepository;

namespace TopShop2
{
    public class Enter
    {
        private ISellerRepository _sellerRepository;

        public Enter()
        {
            _sellerRepository = new MsSqlSellerRepository();
        }

        public void LogIn()
        {
            
        }
    }
}
