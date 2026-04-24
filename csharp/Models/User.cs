using System;

namespace MixedLangDemo.Models;

public class User
{
    public int Id { get; init; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public override string ToString() => $"User({Id}, {Username})";
}
