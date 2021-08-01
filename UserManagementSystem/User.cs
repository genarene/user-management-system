using System;

namespace UserManagementSystem
{
    class User
    {
        // constructor for setting the user properties
        public User(string name, string email, string food, string hobby)
        {
            Name = name;
            Email = email;
            FavouriteFood = food;
            Hobby = hobby;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string FavouriteFood { get; set; }
        public string Hobby { get; set; }

    }
}