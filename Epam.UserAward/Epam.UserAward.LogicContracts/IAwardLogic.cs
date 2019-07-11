using Epam.UserAward.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.LogicContracts
{
    public interface IAwardLogic
    {
        bool Save(Award award);
        bool Delete(int awardId);

        Award GetById(int Id);

        Award[] GetAll();
    }
}
