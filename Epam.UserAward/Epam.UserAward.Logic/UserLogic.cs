using Epam.UserAward.DalContracts;
using Epam.UserAward.Entities;
using Epam.UserAward.LogicContracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Epam.UserAward.FileDal;

namespace Epam.UserAward.Logic
{
    public class UserLogic : IUserLogic

    {
        private IUserDao userDao;
        public UserLogic()
        {
            userDao = new FileUserDao();
        }
        

        public bool Delete(int userId)
        {
            return userDao.Delete(userId);
        }

        public User[] GetAll()
        {
            return userDao.GetAll().ToArray();
        }

        public bool Save(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User can't be null", nameof(user));
            }
            if (userDao.Save(user))
            {
                return true;
            }
            throw new InvalidOperationException("Error on user saving");
        }
    }
}
