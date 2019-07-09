using Epam.UserAward.DalContracts;
using Epam.UserAward.Entities;
using Epam.UserAward.LogicContracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.Logic
{
    public class UserLogic : IUserLogic

    {
        private IUserDao userDao;

        public void Delete(int userId)
        {
             User[] users = GetAll();
            for (int i = 0; i<users.Length; i++)
            {
                if(users[i].Id== userId)
                {
                    users[i] = users[i+1];
                }
            }
            Console.WriteLine("deleting completed:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} {user.Name} {user.DateOfBirth} {user.Age}");
            }
        }

        public User[] GetAll()
        {
            return userDao.GetAll().ToArray();
        }

        public User Save(string userName, DateTime userdateOfBirth, int userAge)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name can't be null or whitespace", nameof(userName));
            }
            User user = new User { Name = userName, DateOfBirth = userdateOfBirth, Age= userAge};
            if (userDao.Save(user))
            {
                return user;
            }
            throw new InvalidOperationException("Error on user saving");
        }
    }
}
