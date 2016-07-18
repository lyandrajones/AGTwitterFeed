using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGTwitterLikeFeed
{
    public class User :IComparable<User>
    {
        public User()
        {
        }
        
        public string Name { get; set; }

        public List<string> Following { get; set; } 

        public int CompareTo(User other)
        {
            return Name.CompareTo(other.Name);
        }

    }
}
