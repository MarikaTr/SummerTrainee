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
    public class FileUserDao : IUserDao
    {
        private static List<User> Users;
        private static string path;

        static FileUserDao()
        {
            path = ConfigurationManager.AppSettings["FilePath"];
            Users = new List<User>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var temp = reader.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Users.Add(new User()
                    {
                        Id = int.Parse(temp[0]),
                        Name = temp[1],
                        DateOfBirth = DateTime.Parse(temp[2]),
                      //  Age = int.Parse(temp[3]),
                        Awards = new List<Award>()
                    });
                    for (int i = 4; i<temp.Length;i += 2)
                    {
                        Users.Last().Awards.Add(new Award { Id = int.Parse(temp[i]) , Title = temp[i+1] });
                    }
                    
                }

            }
        }
        public bool Delete(int id)
        {
            User tmp = Users.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
            {
                Console.WriteLine("Incorrect id");
                return false;
            }
            else
            {
                Users.Remove(tmp);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var item in Users)
                    {
                        if (item.Awards == null)
                        {
                            writer.WriteLine("{0}|{1}|{2}|{3}", item.Id, item.Name, item.DateOfBirth, item.Age);
                        }
                        else
                        {
                            writer.Write("{0}|{1}|{2}|{3}", item.Id, item.Name, item.DateOfBirth, item.Age);
                            foreach (var h in item.Awards)
                            {
                                writer.Write("|{0}|{1}", h.Id, h.Title);
                            }
                        }
                    }
                }
                return true;
            }
        }
            

            public IEnumerable<User> GetAll()
            {
                return Users.ToArray();
            }
            public bool Save(User user)
            {
            if (Users.LastOrDefault() == null)
            {
                user.Id = 1;
            }
            else {
                user.Id = Users.LastOrDefault().Id + 1;
                   }
            Users.Add(user);
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in Users)
                {
                    if (item.Awards == null)
                    {
                        writer.Write("{0}|{1}|{2}|{3}", item.Id, item.Name, item.DateOfBirth, item.Age);
                    }
                    else
                    {
                        writer.Write("{0}|{1}|{2}|{3}", item.Id, item.Name, item.DateOfBirth, item.Age);
                        foreach (var h in item.Awards)
                        {
                            writer.Write("|{0}|{1}", h.Id, h.Title);
                        }   
                    }
                    writer.WriteLine();
                }
            }
            Console.WriteLine("Success");
            return true;
        }
        }

        
    }
