using System.Collections.Generic;
using MixedLangDemo.Models;
using MixedLangDemo.Services;

namespace MixedLangDemo.Controllers;

public class ProductController
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    public Product Add(string name, decimal price, int stock) => _service.Create(name, price, stock);

    public Product? Find(int id) => _service.GetById(id);

    public IEnumerable<Product> Search(string keyword) => _service.Search(keyword);
}
