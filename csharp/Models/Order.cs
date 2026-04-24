using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedLangDemo.Models;

public class OrderLine
{
    public int ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal LineTotal => UnitPrice * Quantity;
}

public class Order
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public List<OrderLine> Lines { get; init; } = new();
    public DateTime PlacedAt { get; init; } = DateTime.UtcNow;

    public decimal Total => Lines.Sum(l => l.LineTotal);
}
