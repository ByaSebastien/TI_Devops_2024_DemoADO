
using System.Data.SqlClient;
using System.Net;
using TI_Devops_2024_DemoADO;
using TI_Devops_2024_DemoADO.Interfaces;
using TI_Devops_2024_DemoADO.Models;
using TI_Devops_2024_DemoADO.Repositories;

string connectionString = @"server=BSTORM\SQLSERVER;database=PokemonDB;integrated security=true";

#region GetAll

//List<Pokemon> pokemons = new List<Pokemon>();

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = "Select * from pokemon";

//    connection.Open();

//    SqlDataReader reader = cmd.ExecuteReader();

//    while (reader.Read())
//    {
//        int id = (int)reader["Id"];
//        string name = (string)reader["Name"];
//        int weight = (int)reader["Weight"];
//        int height = (int)reader["Height"];
//        string? description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
//        int type1Id = (int)reader["Type1Id"];
//        int? type2Id = reader["Type2Id"] == DBNull.Value ? null : (int)reader["Type2Id"];

//        Pokemon p = new Pokemon()
//        {
//            Id = id,
//            Name = name,
//            Weight = weight,
//            Height = height,
//            Description = description,
//            Type1Id = type1Id,
//            Type2Id = type2Id,
//        };

//        pokemons.Add(p);
//    }

//}

//foreach (Pokemon p in pokemons)
//{
//    Console.WriteLine(p);
//}
//pokemons.ForEach(p => Console.WriteLine(p.ToString()));

#endregion

#region GetOne

//Pokemon p = new Pokemon();
//int idReceived = 1;

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = $"Select * from pokemon where Id = @id";

//    cmd.Parameters.AddWithValue("@id",idReceived);

//    connection.Open();

//    SqlDataReader reader = cmd.ExecuteReader();

//    if (reader.Read())
//    {
//        int id = (int)reader["Id"];
//        string name = (string)reader["Name"];
//        int weight = (int)reader["Weight"];
//        int height = (int)reader["Height"];
//        string? description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
//        int type1Id = (int)reader["Type1Id"];
//        int? type2Id = reader["Type2Id"] == DBNull.Value ? null : (int)reader["Type2Id"];

//        p = new Pokemon()
//        {
//            Id = id,
//            Name = name,
//            Weight = weight,
//            Height = height,
//            Description = description,
//            Type1Id = type1Id,
//            Type2Id = type2Id,
//        };

//    }

//}

//Console.WriteLine(p);

#endregion

#region getCount

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = $"select count(*) from pokemon";

//    connection.Open();

//    int count = (int)cmd.ExecuteScalar();

//    Console.WriteLine($"{count} pokemon(s) in PokemonDB");
//}

#endregion

#region create

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = $"INSERT INTO pokemon " +
//                      $"VALUES(@name,@height,@weight,@description,@type1Id,@type2Id)";

//    cmd.Parameters.AddWithValue("@name", "Arcanin");
//    cmd.Parameters.AddWithValue("@height", 50);
//    cmd.Parameters.AddWithValue("@weight", 100);
//    cmd.Parameters.AddWithValue("@description", "Belle bête!");
//    cmd.Parameters.AddWithValue("@type1Id", 2);
//    cmd.Parameters.AddWithValue("@type2Id", DBNull.Value);

//    connection.Open();

//    int nbRows = cmd.ExecuteNonQuery();

//    Console.WriteLine($"{nbRows} row(s) affected");
//}

#endregion

#region Test Repo

IPokemonRepository pokemonRepository = new PokemonRepository(connectionString);

List<Pokemon> pokemons = pokemonRepository.GetAll().ToList();
int count = pokemonRepository.Count();
Console.WriteLine($"Count = {count}");
pokemons.ForEach(p => Console.WriteLine(p));

Console.WriteLine("_______________________________________________________________________");

Pokemon? pokemon = pokemonRepository.GetById(4);

if(pokemon is not null)
{
    Console.WriteLine($"Name {pokemon.Name}\nType1 {pokemon.Type1?.Name}\nType2 {pokemon.Type2?.Name}");
}

Console.WriteLine("_______________________________________________________________________");

Pokemon newPokemon = new Pokemon()
{
    Name = "Leviator",
    Height = 50,
    Weight = 100,
    Description = "The GOAT",
    Type1Id = 4,
    Type2Id = 7
};

int newId = pokemonRepository.Create(newPokemon);

Console.WriteLine($"Pokemon inséré avec id {newId}");

Console.WriteLine("_______________________________________________________________________");

Pokemon updatePokemon = new Pokemon()
{
    Name = "Magikarp",
    Height = 10,
    Weight = 2,
    Description = "The real GOAT",
    Type1Id = 4
};

if (pokemonRepository.Update(newId, updatePokemon))
{
    Console.WriteLine("OK");
}
else
{
    Console.WriteLine("KO");
}

if (pokemonRepository.Delete(newId))
{
    Console.WriteLine("Deleted");
}

#endregion

RappelGenerique<Pokemon> r = new RappelGenerique<Pokemon>();

r.execute(pokemon);