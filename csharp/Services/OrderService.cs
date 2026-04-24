using System;
using System.Collections.Generic;
using MixedLangDemo.Models;
using MixedLangDemo.Utils;

namespace MixedLangDemo.Services;

public class OrderService
{
    private readonly Dictionary<int, Order> _orders = new();
    private readonly UserService _users;
    private readonly ProductService _products;
    private int _nextId = 1;

    public OrderService(UserService users, ProductService products)
    {
        _users = users;
        _products = products;
    }

    public Order PlaceOrder(int userId, IEnumerable<(int productId, int qty)> items)
    {
        var user = _users.GetById(userId) ?? throw new InvalidOperationException($"unknown user {userId}");
        var order = new Order { Id = _nextId++, UserId = user.Id };

        foreach (var (productId, qty) in items)
        {
            var product = _products.GetById(productId) ?? throw new InvalidOperationException($"unknown product {productId}");
            _products.Reduce(productId, qty);
            order.Lines.Add(new OrderLine
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = qty,
                UnitPrice = product.Price,
            });
        }

        _orders[order.Id] = order;
        Logger.Info($"Placed order #{order.Id} for user {user.Username}, total {order.Total:C}");
        return order;
    }

    public Order? GetById(int id) => _orders.TryGetValue(id, out var o) ? o : null;
}
