using System.Collections.Generic;
using MixedLangDemo.Models;
using MixedLangDemo.Services;

namespace MixedLangDemo.Controllers;

public class UserController
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    public User Register(string username, string email) => _service.Create(username, email);

    public IEnumerable<User> List() => _service.All();

    public User? Find(int id) => _service.GetById(id);

    public bool Remove(int id) => _service.Delete(id);
}
