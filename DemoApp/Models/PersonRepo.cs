using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class PersonRepo : IPersonRepo
    {
        public Person GetPerson()
        {
            Person p1 = new Person() { Name = "Saurabh", Age = 1 };
            return p1;            
        }
    }
}
