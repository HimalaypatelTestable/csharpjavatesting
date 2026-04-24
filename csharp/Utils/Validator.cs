using System;
using System.Text.RegularExpressions;

namespace MixedLangDemo.Utils;

public static class Validator
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static void RequireNonEmpty(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{paramName} must not be empty", paramName);
    }

    public static void RequireEmail(string email)
    {
        RequireNonEmpty(email, nameof(email));
        if (!EmailRegex.IsMatch(email))
            throw new ArgumentException($"invalid email: {email}");
    }
}
