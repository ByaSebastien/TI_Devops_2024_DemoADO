using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoADO.Models;

namespace TI_Devops_2024_DemoADO
{
    public class RappelGenerique<T> where T : class
    {
        public void execute(T truc)
        {
            Console.WriteLine(truc);
        }
    }
}
