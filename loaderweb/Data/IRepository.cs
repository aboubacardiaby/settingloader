using System.Data;

namespace loaderweb.Data
{
    public interface IRepository
    {
        void Add(Product product);
        void Delete(string id);
        void Update(Product product);
        Product Get(string id);
        List<Product> GetAll();

    }
}
