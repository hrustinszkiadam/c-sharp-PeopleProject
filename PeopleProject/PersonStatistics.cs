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
			if (People.Count == 0) return 0;
			return People.Average(p => p.Age);
		}

		public int GetNumberOfStudents()
		{
			if (People.Count == 0) return 0;
			return People.Count(p => p.IsStudent);
		}

		public Person? GetPersonWithHighestScore()
		{
			if (People.Count == 0) return null;
			return People.OrderByDescending(p => p.Score).First();
		}

		public double GetAverageScoreOfStudents()
		{
			if (People.Count == 0) return 0;
			List<Person> students = People.Where(p => p.IsStudent).ToList();
			if (students.Count == 0) return 0;

			return students.Average(p => p.Score);
		}

		public Person? GetOldestStudent()
		{
			if (People.Count == 0) return null;
			List<Person> students = People.Where(p => p.IsStudent).ToList();
			if (students.Count == 0) return null;

			return students.OrderByDescending(p => p.Age).First();
	}

		public bool IsAnyOneFailing()
		{
			if (People.Count == 0) return false;
			return People.Any(p => p.Score < 40);
		}
	}
}
