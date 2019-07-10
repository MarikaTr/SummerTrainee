using Epam.UserAward.DalContracts;
using Epam.UserAward.FileDal;
using Epam.UserAward.MemoryDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.Logic
{
    internal static class DaoProvider
    {
        public static IUserDao UserDao { get; }
        //public static IAwardDao AwardDao { get; }

        static DaoProvider()
        {
            string typeDAL = ConfigurationManager.AppSettings["typeDAL"];

            switch (typeDAL)
            {
                case "Files":
                    {
                        UserDao = new FileUserDao();
                        //AwardDao = new FileAwardDao();

                    }
                    break;
                case "Memory":
                    {
                        UserDao = new MemoryUserDao();
                    }
                    break;
            }
        }
    }
}