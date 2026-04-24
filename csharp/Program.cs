using System;
using MixedLangDemo.Models;
using MixedLangDemo.Services;
using MixedLangDemo.Utils;

namespace MixedLangDemo;

public class Program
{
    public static void Main(string[] args)
    {
        Logger.Info("Starting MixedLangDemo");

        var userService = new UserService();
        var productService = new ProductService();
        var orderService = new OrderService(userService, productService);

        var alice = userService.Create("alice", "alice@example.com");
        var bob = userService.Create("bob", "bob@example.com");

        var widget = productService.Create("Widget", 9.99m, 100);
        var gadget = productService.Create("Gadget", 24.50m, 40);

        var order1 = orderService.PlaceOrder(alice.Id, new[] { (widget.Id, 3), (gadget.Id, 1) });
        var order2 = orderService.PlaceOrder(bob.Id, new[] { (widget.Id, 10) });

        Logger.Info($"Order1 total: {order1.Total:C}");
        Logger.Info($"Order2 total: {order2.Total:C}");

        foreach (var u in userService.All())
        {
            Console.WriteLine($"User {u.Id}: {u.Username} <{u.Email}>");
        }

        Logger.Info("Done.");
    }
}
