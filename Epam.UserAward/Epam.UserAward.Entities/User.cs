using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserAward.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                {

                    if ((DateOfBirth.Month > DateTime.Now.Month) && (DateOfBirth.Day > DateTime.Now.Day))
                    {
                        return DateTime.Now.Year - DateOfBirth.Year - 1;
                    }
                    else
                    {
                        return DateTime.Now.Year - DateOfBirth.Year;
                    }
                }
            }            
        }
        public List<Award> Awards { get;set;}
    }

}

