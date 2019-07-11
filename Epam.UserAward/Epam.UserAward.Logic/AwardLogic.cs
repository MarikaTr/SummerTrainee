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
        private IAwardDao awardDao;
        public AwardLogic()
        {
            awardDao = new FileAwardDao();
        }

        public Award[] GetAll()
        {
            return awardDao.GetAll().ToArray();
        }

        public Award GetById(int Id)
        {
            return awardDao.GetById(Id);
        }

        public bool Save(Award award)
        {
            if (award == null)
            {
                throw new ArgumentException("Award can't be null", nameof(award));
            }
            if (awardDao.Save(award))
            {
                return true;
            }
            throw new InvalidOperationException("Error on award saving");
        }

        bool IAwardLogic.Delete(int awardId)
        {
            return awardDao.Delete(awardId);
        }
    }
}
