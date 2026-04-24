using System.Collections.Generic;
using System.Linq;
using MixedLangDemo.Models;
using MixedLangDemo.Utils;

namespace MixedLangDemo.Services;

public class UserService
{
    private readonly Dictionary<int, User> _users = new();
    private int _nextId = 1;

    public User Create(string username, string email)
    {
        Validator.RequireNonEmpty(username, nameof(username));
        Validator.RequireEmail(email);

        var user = new User { Id = _nextId++, Username = username, Email = email };
        _users[user.Id] = user;
        Logger.Info($"Created {user}");
        return user;
    }

    public User? GetById(int id) => _users.TryGetValue(id, out var u) ? u : null;

    public IEnumerable<User> All() => _users.Values.OrderBy(u => u.Id);

    public bool Delete(int id) => _users.Remove(id);
}
