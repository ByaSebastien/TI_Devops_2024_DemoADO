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
        int Create(Pokemon pokemon);
        bool Update(int id, Pokemon pokemon);
        bool Delete(int id);
    }
}
