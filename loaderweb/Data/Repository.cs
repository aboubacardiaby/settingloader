namespace loaderweb.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            this._context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(Product product)
        {

            if (product == null)
            {
                throw new ArgumentNullException();
            }
            _context.tblProduct.Add(product);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _context.tblProduct.ToList();
        }
        public Product Get(string id)
        {
            return _context.tblProduct.Where(x => x.Equals(id)).FirstOrDefault();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
