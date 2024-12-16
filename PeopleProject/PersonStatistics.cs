using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
	public class PersonStatistics
	{
		private List<Person> people;
		public List<Person> People {
			private get => people;
			set {
				if (value == null) throw new ArgumentNullException("Az emberek listája nem lehet null", nameof(value));

				people = value;
			}
		}

		public PersonStatistics(List<Person> people)
		{
			if (people == null) throw new ArgumentNullException("Az emberek listája nem lehet null", nameof(people));

			this.people = people;
		}

		public double GetAverageAge()
		{
			return People.Average(p => p.Age);
		}

		public int GetNumberOfStudents()
		{
			return People.Count(p => p.IsStudent);
		}

		public Person GetPersonWithHighestScore()
		{
			return People.OrderByDescending(p => p.Score).First();
		}

		public double GetAverageScoreOfStudents()
		{
			List<Person> students = People.Where(p => p.IsStudent).ToList();
			if (students.Count == 0) return 0;

			return students.Average(p => p.Score);
		}

		public Person? GetOldestStudent()
		{
			List<Person> students = People.Where(p => p.IsStudent).ToList();
			if (students.Count == 0) return null;

			return students.OrderByDescending(p => p.Age).First();
	}

		public bool IsAnyOneFailing()
		{
			return People.Any(p => p.Score < 40);
		}
	}
}
