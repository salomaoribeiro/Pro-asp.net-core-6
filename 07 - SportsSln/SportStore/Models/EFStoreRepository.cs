namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;

        public EFStoreRepository(StoreDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Product> Products => _context.Products;
    }
}
