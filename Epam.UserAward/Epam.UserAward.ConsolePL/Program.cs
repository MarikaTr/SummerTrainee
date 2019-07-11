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
        private static IAwardLogic awardLogic;

        static Program()
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();
        }
        static int mainMenu()
        {
            int n = 1;
            bool isParseTrue = true;
            do
            {
                if ((!isParseTrue) || (n < 0) || (n > 6))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Add Award");
                Console.WriteLine("5. Show Award");
                Console.WriteLine("6. Delete Award");
                Console.WriteLine("0. Exit");
                Console.WriteLine(DateTime.Now.ToString());
                isParseTrue = int.TryParse(Console.ReadLine(), out n);
                Console.Clear();
            }
            while (!isParseTrue || (n < 0) || (n > 6));
            return n;
        }
        static int checkInput()
        {
            int n;
            bool isParseTrue = true;
            do
            {
                if (!isParseTrue)
                {
                    Console.WriteLine("Wrong input.Try again.");
                }
                isParseTrue = int.TryParse(Console.ReadLine(), out n);
            }
            while (!isParseTrue||n<0);
            return n;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int n = mainMenu();
                switch (n)
                {
                    case 1: AddUser(); break;
                    case 2: ShowUser(); break;
                    case 3: DeleteUser(); break;
                    case 4: AddAward(); break;
                    case 5: ShowAward();break;
                    case 6: DeleteAward(); break;
                    case 0: Environment.Exit(0); break;
                }
            }
        }

        private static void ShowAward()
        {
            Award[] awards = awardLogic.GetAll();
            foreach (var item in awards)
            {
                Console.WriteLine($"{item.Id} {item.Title} .");
            }
        }

        private static void DeleteAward()
        {
            Console.WriteLine("Enter Award ID:");
            bool isParseTrue = true;
            int awardId = checkInput();
            if (awardLogic.Delete(awardId))
            {
                Console.WriteLine("Delete successfull");
            }
            else { Console.WriteLine("Award can't be deleted"); }
        }

        private static void AddAward()
        {
            Console.WriteLine("Enter Title:");
            string awardTitle = Console.ReadLine();
            Award award = new Award { Title = awardTitle };
            if (awardLogic.Save(award))
            {
                Console.WriteLine("Award was saved");
            }
            else { Console.WriteLine("Award can't be saved"); };
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter User ID:");
            bool isParseTrue = true;
            int userId = checkInput();
            if (userLogic.Delete(userId))
            {
                Console.WriteLine("Delete successfull");
            }
            else { Console.WriteLine("User can't be deleted"); }
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter User name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter date of birth:");
            DateTime userdateOfBirth = new DateTime();
            DateTime.TryParse(Console.ReadLine(), out userdateOfBirth);

            Console.WriteLine("Enter age:");
            //int userAge = checkInput();
            int userAge ;
            
                
                /*int.Parse(System.DateTime.Now.ToString())- int.Parse(userdateOfBirth.ToString());*/
            Console.WriteLine("Does user have awards? y/n");
            int yn = int.Parse(Console.ReadLine());
           // List<int> awardId;
            int i = 0;
            switch (yn)
            {
                case 1: {
                        User user = new User { Name = userName, DateOfBirth = userdateOfBirth, Awards = new List<Award>()};
                        Console.WriteLine("How many awards user has?");
                        int count =  int.Parse(Console.ReadLine());
                        for(i = 0; i<count; i++)
                        {
                            Console.WriteLine("Input {0} Award's Id:", i+1);
                            int awar = checkInput();
                            if (awardLogic.GetById(awar) == null)
                            {
                                Console.WriteLine("Wrong input. This award doesn't exist.");
                            }
                            else
                            {
                                user.Awards.Add(awardLogic.GetById(awar));
                            }
                        //    awardId.Add(awar)
                        }
                        if (userLogic.Save(user))
                        {
                            Console.WriteLine("User was saved");
                        }
                        else { Console.WriteLine("User can't be saved"); };
                    }
                    break;
                case 2:
                    {
                        User user = new User { Name = userName, DateOfBirth = userdateOfBirth};
                        if (userLogic.Save(user))
                        {
                            Console.WriteLine("User was saved");
                        }
                        else { Console.WriteLine("User can't be saved"); };
                    } break;
            }
           
            
        }

        private static void ShowUser()
        {
            User[] users = userLogic.GetAll();
            foreach (var user in users)
            {
                if (user.Awards == null)
                {
                    Console.Write("{0}|{1}|{2}|{3}", user.Id, user.Name, user.DateOfBirth, user.Age);
                }
                else
                {
                    Console.Write("{0}|{1}|{2}|{3}", user.Id, user.Name, user.DateOfBirth, user.Age);
                    foreach (var h in user.Awards)
                    {
                        Console.Write("|{0}|{1}", h.Id, h.Title);
                    }
                }
                Console.WriteLine();
                //Console.WriteLine($"{user.Id} {user.Name} {user.DateOfBirth} {user.Age}");
            }
        }
    }
}
