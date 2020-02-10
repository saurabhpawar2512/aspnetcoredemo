using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public interface IPersonRepo
    {
        Person GetPerson();
    }
}
