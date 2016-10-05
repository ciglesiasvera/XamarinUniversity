using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;
using System.Threading.Tasks;

namespace People
{
	public class PersonRepository
	{
		private readonly SQLiteAsyncConnection conn;

		public string StatusMessage { get; set; }

		public PersonRepository(string dbPath)
		{
			conn = new SQLiteAsyncConnection(dbPath);
			conn.CreateTableAsync<Person>().Wait();
		}

		public void AddNewPerson(string name,string email,string twitter)
		{
		    try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

				//insert a new person into the Person table
				var result = conn.InsertAsync(new Person { Name = name, Email=email, Twitter=twitter });
				StatusMessage = string.Format("{0} adicionado: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Error al realizar la adicion {0}. Error: {1}", name, ex.Message);
			}

		}

		public async Task<List<Person>> GetAllPeople()
		{
			//return a list of people saved to the Person table in the database
			return await conn.Table<Person>().ToListAsync();
		}
	}
}