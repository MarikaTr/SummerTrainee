using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.LogicContracts
    {
        bool Save(string type);

        Award GetById(int Id);

        Award[] GetAll();
    }