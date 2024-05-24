using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoADO.Models;

namespace TI_Devops_2024_DemoADO.Interfaces
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetAll();
        Pokemon? GetById(int id);
        int Count();
        int Create(Pokemon p);
        bool Update(int id, Pokemon p);
        bool Delete(int id);
    }
}
