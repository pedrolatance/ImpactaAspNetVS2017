using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositories.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositories.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        private ProductRepository _repository = new ProductRepository();

        [TestMethod()]
        public void PostTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Café";
            product.UnitsInStock = 35;
            product.UnitPrice = 11.36m;

            var response = _repository.Post(product).Result;

            Console.WriteLine(response.ProductID);
        }

        [TestMethod()]
        public void PutTest()
        {
            var product = new ProductViewModel();
            product.ProductID = 79;
            product.ProductName = "Café com leite";
            product.UnitsInStock = 49;
            product.UnitPrice = 11.48m;

            _repository.Put(product.ProductID,product).Wait();

            var response = _repository.Get(79).Result;

            Assert.AreEqual(response.UnitPrice, product.UnitPrice);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _repository.Delete(84).Wait();

            var response = _repository.Get(84).Result;

            Assert.IsNull(response);
        }

        [TestMethod]
        public void GetTest()
        {
            var produtos = _repository.Get().Result;

            Assert.IsTrue(produtos.Count > 1);
        }

        [TestMethod]
        public void GetProductOrderTest()
        {
            var orders = _repository.GetProductOrders(3).Result;

            Assert.IsTrue(orders.Count > 0);

        }
    }
}