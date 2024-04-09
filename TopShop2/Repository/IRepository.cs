using System.Collections.Generic;

namespace TopShop.Repository
{
    public interface IRepository<TValue> where TValue : class
    {
        void Insert(TValue item);
        void Update(TValue item,int ID);
        void Delete(int ID);
        List<TValue> GetAll();
    }
}
