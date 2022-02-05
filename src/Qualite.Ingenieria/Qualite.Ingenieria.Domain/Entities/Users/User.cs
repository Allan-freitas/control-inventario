﻿namespace Qualite.Ingenieria.Domain.Entities.Users
{
    public class User
    {
        public User(long id, string name, string email, string password, string username)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Username = username;
        }

        public long Id { get; init; }

        public string Name { get; init; }

        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }
    }
}