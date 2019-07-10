using Epam.UserAward.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.DalContracts
{
    public interface IUserDao
    {
        bool Save(User user);
        IEnumerable<User> GetAll();

        bool Delete(int id);
    }
}
