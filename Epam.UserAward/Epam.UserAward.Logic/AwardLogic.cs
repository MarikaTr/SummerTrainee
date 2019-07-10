using Epam.UserAward.DalContracts;
using Epam.UserAward.Entities;
using Epam.UserAward.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UserAward.FileDal;


namespace Epam.UserAward.Logic
{
    public class AwardLogic : IAwardLogic

    {
        private IAwardDao userDao;
        public AwardLogic()
        {
            userDao = new FileAwardDao();
        }
    }
