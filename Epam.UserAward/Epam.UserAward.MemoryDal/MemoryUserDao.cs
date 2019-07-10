using Epam.UserAward.DalContracts;
using Epam.UserAward.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.MemoryDal
{
    public class MemoryUserDao : IUserDao
    {
        private HashSet<User> users;
        private int maxId;

        public MemoryUserDao()
        {
            users = new HashSet<User>();
            maxId = 0;
        }
        public IEnumerable<User> GetAll()
        {
            return users.Select(n => n);
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(n => n.Id == id);
        }

        public bool Save(User user)
        {
            user.Id = ++maxId;
            users.Add(user);
            return true;
        }
        public bool Delete(int id)
        {
            var temp = users.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                Console.WriteLine("Can't delete user. List is empty.");
                return false;
            }
            users.Remove(temp);
            Console.WriteLine("deleting completed:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} {user.Name} {user.DateOfBirth} {user.Age}");
            }
            return true;
        }
    }
}
