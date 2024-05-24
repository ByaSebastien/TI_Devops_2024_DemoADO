using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoADO.Interfaces;
using TI_Devops_2024_DemoADO.Models;

namespace TI_Devops_2024_DemoADO.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly string _connectionString;

        public PokemonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Pokemon Convert(IDataRecord record)
        {
            return new Pokemon()
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Height = (int)record["Height"],
                Weight = (int)record["Weight"],
                Description = record["Description"] == DBNull.Value ? null : (string)record["Description"],
                Type1Id = (int)record["Type1Id"],
                Type2Id = record["Type2Id"] == DBNull.Value ? null : (int)record["Type2Id"]
            };
        }

        public IEnumerable<Pokemon> GetAll()
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * " +
                              "FROM pokemon";

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

            }
        }

        public Pokemon? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Create(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
