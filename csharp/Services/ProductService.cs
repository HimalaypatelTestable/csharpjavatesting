using System;
using System.Collections.Generic;
using System.Linq;
using MixedLangDemo.Models;
using MixedLangDemo.Utils;

namespace MixedLangDemo.Services;

public class ProductService
{
    private readonly Dictionary<int, Product> _products = new();
    private int _nextId = 1;

    public Product Create(string name, decimal price, int stock)
    {
        Validator.RequireNonEmpty(name, nameof(name));
        if (price < 0) throw new ArgumentException("price must be non-negative");
        if (stock < 0) throw new ArgumentException("stock must be non-negative");

        var p = new Product { Id = _nextId++, Name = name, Price = price, Stock = stock };
        _products[p.Id] = p;
        Logger.Info($"Created {p}");
        return p;
    }

    public Product? GetById(int id) => _products.TryGetValue(id, out var p) ? p : null;

    public IEnumerable<Product> Search(string keyword) =>
        _products.Values.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));

    public void Reduce(int id, int qty)
    {
        var p = GetById(id) ?? throw new InvalidOperationException($"unknown product {id}");
        if (!p.IsInStock(qty)) throw new InvalidOperationException($"insufficient stock for {p.Name}");
        p.Stock -= qty;
    }
}
