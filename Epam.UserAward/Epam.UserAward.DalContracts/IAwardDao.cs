using Epam.UserAward.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.DalContracts
{
    public interface IAwardDao
    {
        Award GetById(int id);
        bool Save(Award award);
        IEnumerable<Award> GetAll();
        bool Delete(int id);
    }
}
