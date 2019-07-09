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
        void Delete(int userId);
        User Save(string userName, DateTime userdateOfBirth, int userAge);
        User[] GetAll();
        
    }
}
