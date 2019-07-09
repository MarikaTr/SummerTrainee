using Epam.UserAward.Entities;
using Epam.UserAward.Logic;
using Epam.UserAward.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.ConsolePL
{
    class Program
    {
        private static IUserLogic userLogic;

        static Program()
        {
            userLogic = new UserLogic();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int n = 1;
                bool isParseTrue = true;
                do
                {
                    
                    if ((!isParseTrue) || (n < 0) || (n > 3))
                    {
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    
                    Console.WriteLine("\n1. Add User");
                    Console.WriteLine("2. Show User");
                    Console.WriteLine("3. Delete User");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine(DateTime.Now.ToString());
                    isParseTrue = int.TryParse(Console.ReadLine(), out n);
                    Console.Clear();
                }
                while (!isParseTrue || (n < 0) || (n > 3));
                switch (n)
                {
                    case 1: AddUser(); break;
                    case 2: ShowUser(); break;
                    case 3: DeleteUser(); break;
                    case 4: Environment.Exit(0); break;
                }
            }
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            userLogic.Delete(userId);
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter User name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter date of birth:");
            DateTime userdateOfBirth = new DateTime();
            DateTime.TryParse(Console.ReadLine(), out userdateOfBirth);
            Console.WriteLine("Enter age:");
            int.TryParse(Console.ReadLine(),out int userAge);/*int.Parse(System.DateTime.Now.ToString())- int.Parse(userdateOfBirth.ToString());*/
            User user = userLogic.Save(userName, userdateOfBirth, userAge);
        }

        private static void ShowUser()
        {
            User[] users = userLogic.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} {user.Name} {user.DateOfBirth} {user.Age}");
            }
        }
    }
}
