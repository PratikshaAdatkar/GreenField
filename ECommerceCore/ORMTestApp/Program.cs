using Catalog.Entities;
using Catalog.Repositories.Connected;

List<Product> products = ProductRepository.GetAll();
foreach (var product in products)
{
    Console.WriteLine(product);
}