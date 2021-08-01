using System;
using System.IO;
using ConsoleTables;


namespace UserManagementSystem
{

    class Users
    {
        private UserQueue<User> users = new UserQueue<User>();

        // method to add users to the queue
        public void AddUser(User user)
        {

            users.Enqueue(user);
            System.Console.WriteLine("User has been added successfuly");

        }

        // method to remove users
        public void RemoveUser()
        {
            users.Dequeue();
            System.Console.WriteLine("User removed successfuly");
        }


        // method to display all the users in tabular form using ConsoleTables package
        public void DisplayUsers()
        {
            System.Console.WriteLine("Users currently in the system \n");
            ConsoleTable table = new ConsoleTable("Name", "Email", "Food", "Hobby");

            foreach (User user in users)
            {
                table.AddRow(user.Name, user.Email, user.FavouriteFood, user.Hobby);
            }
            table.Write();
        }

        // Store the path of the file in the system
        string file = @"../Users/users.txt";

        // method to store users in the file
        public void PersistUsersToFile()
        {

            if (File.Exists(file))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.Name}, {user.Email}, {user.FavouriteFood}, {user.Hobby}");
                    }
                }

                // To display current contents of the file
                Console.WriteLine("Changes have been saved to the file system");

            }

        }

        // method to read the saved data from the file and add it tho the queue
        public void ReadUsersFromFile()
        {
            using (StreamReader streamReader = File.OpenText(file))
            {
                var read = streamReader.ReadToEnd();
                read = read.TrimEnd();
                var storedUsers = read.Split(Environment.NewLine);
                var last = storedUsers[^1];
                // get the details of each user read from the file and instantiate a user with the details and add the user to the queue
                if (storedUsers.Length > 1)
                {

                    foreach (var item in storedUsers)
                    {

                        var userInfo = item.Split(',');
                        if (userInfo.Length > 1)
                        {
                            User user = new User(userInfo[0], userInfo[1], userInfo[2], userInfo[3]);
                            users.Enqueue(user);
                        }

                    }
                    DisplayUsers();
                }


            }
        }


    }
}