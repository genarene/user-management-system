using System;
using System.Linq;

namespace UserManagementSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            Users users = new Users();

            System.Console.WriteLine("User Management Console App:\n");
            //Display users in the system when app starts
            users.ReadUsersFromFile();
            System.Console.WriteLine("\n\n");

            System.Console.WriteLine("Select one of the operations below: \n");
            System.Console.WriteLine("Select 1 to Add user \n");
            System.Console.WriteLine("Select 2 to Save Changes \n");
            System.Console.WriteLine("Select 3 to Remove user \n");
            System.Console.WriteLine("Select 4 to display all users \n");
            System.Console.WriteLine("Select 0 to exit program \n");

            // continuosly run the console app until terminated
            while (true)
            {
                System.Console.WriteLine("Select operation \n");
                var userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        System.Console.WriteLine("Enter user Name \n");
                        var name = GetInput("name");

                        System.Console.WriteLine("Enter user Email \n");
                        var email = GetInput("email");

                        // check if email provided is valid
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(email);
                            email = addr.Address;
                        }
                        catch
                        {
                            System.Console.WriteLine("Please provide a valid email Address");
                            email = GetInput("email");
                        }

                        System.Console.WriteLine("Enter user favourite food \n");
                        var food = GetInput("food");
                        if (food.Any(f => char.IsDigit(f)))
                        {
                            System.Console.WriteLine("Food should not contain numbers");
                            food = GetInput("food");
                        }

                        System.Console.WriteLine("Enter user hobby \n");
                        var hobby = GetInput("hobby");

                        // instantiating a new user
                        User user = new User(name, email, food, hobby);
                        users.AddUser(user);
                        break;


                    case "2":
                        users.PersistUsersToFile();
                        System.Console.WriteLine("User saved successfuly\n\n");
                        break;


                    case "3":
                        users.RemoveUser();
                        break;


                    case "4":
                        users.DisplayUsers();
                        break;

                    // to persist the users and exit the console app
                    case "0":
                        users.PersistUsersToFile();
                        return;

                    default:
                        System.Console.WriteLine("Please select one of the operations above \n");
                        break;
                }
            }

        }

        // input validation to ensure the inputs are not empty
        private static string GetInput(string Prompt)
        {
            string Result = "";
            do
            {
                Console.Write(Prompt + ": ");
                Result = Console.ReadLine();
                if (string.IsNullOrEmpty(Result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(Result));
            return Result;
        }

    }
}
