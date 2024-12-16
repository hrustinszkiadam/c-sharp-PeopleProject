using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
	public class Person
	{
		public int Id { get; init; }
		public string Name { get; init; }
		public int Age { get; init; }
		public bool IsStudent { get; init; }
		public int Score { get; init; }

		public Person(int id, string name, int age, bool isStudent, int score)
		{
			if (id <= 0) throw new ArgumentException("Az id számozása 1-től kezdődik", nameof(id));
            if (score < 0 || score > 100) throw new ArgumentException("A pontszám 0 és 100 közötti szám lehet", nameof(score));
			if (age < 0) throw new ArgumentException("Az életkor nem lehet negatív szám", nameof(age));
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("A név nem lehet üres", nameof(name));
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A név nem lehet csak szóköz", nameof(name));

			Id = id;
			Name = name;
			Age = age;
			IsStudent = isStudent;
			Score = score;
		}
	}
}
