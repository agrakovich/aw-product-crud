using System.Collections.Generic;
using System.Linq;
using AdwentureWorksProduct.DbModel;
using Microsoft.EntityFrameworkCore;

namespace AdwentureWorksProduct.Services
{
    public class ProductService
    {
        private readonly AdventureWorks2017Context db = new AdventureWorks2017Context();

        public ProductService()
        {
        }

        public Product GetProduct(int id)
        {
            var product = db.Product.Find(id);
            return product;
        }

        public IEnumerable<Product> GetProductList()
        {
            return db.Product;
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var product = db.Product.Find(id);
            if (product != null)
            {
                foreach (var workOrder in db.WorkOrder.Where(t => t.ProductId == product.ProductId))
                {
                    db.WorkOrder.Remove(workOrder);

                }
                db.Product.Remove(product);
                Save();
            }
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
