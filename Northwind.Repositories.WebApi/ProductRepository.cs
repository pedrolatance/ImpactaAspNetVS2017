using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositories.WebApi
{
    public class ProductRepository
    {
        private string _url = "http://localhost:50177/api/products";
        public HttpClient Cliente { get; set; } = new HttpClient();

        public async Task<List<ProductViewModel>> Get()
        {
            using (var resposta = await Cliente.GetAsync(_url))
            {
                return await resposta.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            using (var resposta = await Cliente.GetAsync($"{_url}/{id}"))
            {
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task<ProductViewModel> Post(ProductViewModel product)
        {
            using (var resposta = await Cliente.PostAsJsonAsync(_url, product))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Put(int id, ProductViewModel product)
        {
            using (var resposta = await Cliente.PutAsJsonAsync($"{_url}/{id}", product))
            {
                resposta.EnsureSuccessStatusCode();;
            }
        }

        public async Task Delete(int id)
        {
            using (var resposta = await Cliente.DeleteAsync($"{_url}/{id}"))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<OrderViewModel>> GetProductOrders(int id)
        {
            using (var resposta = await Cliente.GetAsync($"{_url}/{id}/orders"))
            {
                return await resposta.Content.ReadAsAsync<List<OrderViewModel>>();
            }
        }

    }
}
