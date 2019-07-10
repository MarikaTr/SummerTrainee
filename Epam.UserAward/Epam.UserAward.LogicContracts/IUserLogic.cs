using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UserAward.Entities;

namespace Epam.UserAward.LogicContracts
{
    public interface IUserLogic
    {
        bool Delete(int userId);
        bool Save(User user);
        User[] GetAll();
        
    }
}
