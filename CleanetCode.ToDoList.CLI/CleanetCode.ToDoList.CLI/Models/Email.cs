﻿namespace CleanetCode.ToDoList.CLI.Models;
public record Email
{
    public string Value { get; init; }

    private Email(string value)
    {
        Value = value;
    }
    public static (Email? Email, string Error) Create(string? email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            return (null, "Email is not valid: " + email);
        }

        return (new Email(email), string.Empty);
    }
}

