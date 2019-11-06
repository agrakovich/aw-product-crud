using System;
using System.Collections.Generic;
using System.Linq;
using AdwentureWorksProduct.DbModel;
using AdwentureWorksProduct.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AdwentureWorksProduct.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var departmentService = new ProductService();
                return departmentService.GetProductList().ToList();
            }
            catch (Exception ex)
            {
                Log.Error($"error while getting products: { ex.Message }");
                throw;
            }
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                var departmentService = new ProductService();
                return departmentService.GetProduct(id);

            }
            catch(Exception ex)
            {
                Log.Error($"error while getting product {id}: { ex.Message }");
                throw;
            }
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            try
            {
                var departmentService = new ProductService();
                departmentService.Create(value);
            }
            catch (Exception ex)
            {
                Log.Error($"error while adding: {ex.Message}");
                throw;
            }
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            try
            {
                var departmentService = new ProductService();
                var product = departmentService.GetProduct(id);
                product.Name = value.Name;
                product.MakeFlag = value.MakeFlag;
                product.FinishedGoodsFlag = value.FinishedGoodsFlag;
                product.Color = value.Color;
                product.SafetyStockLevel = value.SafetyStockLevel;
                product.ReorderPoint = value.ReorderPoint;
                product.StandardCost = value.StandardCost;
                product.ListPrice = value.ListPrice;
                product.Size = value.Size;
                product.SizeUnitMeasureCode = value.SizeUnitMeasureCode;
                product.WeightUnitMeasureCode = value.WeightUnitMeasureCode;
                product.Weight = value.Weight;
                product.DaysToManufacture = value.DaysToManufacture;
                product.ProductLine = value.ProductLine;
                product.Class = value.Class;
                product.Style = value.Style;
                product.ProductSubcategoryId = value.ProductSubcategoryId;
                product.SellStartDate = value.SellStartDate;
                product.SellEndDate = value.SellEndDate;
                product.DiscontinuedDate = value.DiscontinuedDate;
                product.ModifiedDate = value.ModifiedDate;

                departmentService.Update(product);
            }
            catch (Exception ex)
            {
                Log.Error($"error while updating: { ex.Message }");
                throw;
            }
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var departmentService = new ProductService();
                departmentService.Delete(id);
            }
            catch(Exception ex)
            {
                Log.Error($"error while deleting: { ex.Message }");
                throw;
            }
        }
    }
}
