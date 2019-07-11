using Epam.UserAward.DalContracts;
using Epam.UserAward.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.FileDal
{
    public class FileAwardDao: IAwardDao
    {
        private static List<Award> Awards;
        private static string path;

        static FileAwardDao()
        {
            path = ConfigurationManager.AppSettings["FilePathAward"];
            Awards = new List<Award>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var temp = reader.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Awards.Add(new Award()
                    {
                        Id = int.Parse(temp[0]),
                        Title = temp[1],
                    });
                }
            }
        }

        public bool Delete(int id)
        {
            Award tmp = Awards.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
            {
                Console.WriteLine("Incorrect id");
                return false;
            }
            else
            {
                Awards.Remove(tmp);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var item in Awards)
                    {
                        writer.WriteLine("{0}|{1}", item.Id, item.Title);
                    }
                }
                return true;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            return Awards.ToArray();
        }

        public bool Save(Award award)
        {
            if (Awards.LastOrDefault() == null)
            {
                award.Id = 1;
            }
            else
            {
                award.Id = Awards.LastOrDefault().Id + 1;
            }
            Awards.Add(award);
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in Awards)
                {
                    writer.WriteLine("{0}|{1}", item.Id, item.Title);
                }
            }
            return true;
        }
        public Award GetById(int id)
        {
            return Awards.FirstOrDefault(p => p.Id == id);
        }
    }
}
