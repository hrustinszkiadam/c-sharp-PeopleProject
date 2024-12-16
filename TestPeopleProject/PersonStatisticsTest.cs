using PeopleProject;

namespace TestPeopleProject
{
	[TestFixture]
	[TestOf(typeof(PersonStatistics))]
	[Category("PersonStatistics Class Tesztek")]
	public class PersonStatisticsTests
	{
		PersonStatistics stats;

		[SetUp]
		public void Setup()
		{
			stats = new PersonStatistics(new List<Person>());
		}

		[Test]
		[Category("Konstruktor Invalid Adat")]
		[TestCase(null)]
		public void Constructor_InvalidInput_ArgumentNullExceptiontDob(List<Person> list)
		{
			Assert.Throws<ArgumentNullException>(() => stats.People = list);
		}

		[Test]
		[Category("Lista adat invalid")]
		//invalid id 0
		[TestCase(
			new int[] { 0, 1, 2, 3 },
			new string[] { "John Doe", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		)]
		//invalid id negatív
		[TestCase(
			new int[] { -1, 1, 2, 3 },
			new string[] { "John Doe", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		)]
		//invalid name üres
		[TestCase(
			new int[] { 1, 2, 3, 4 },
			new string[] { "", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		)]
		//invalid name csak szóköz
		[TestCase(
			new int[] { 1, 2, 3, 4 },
			new string[] { " ", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		)]
		//invalid age
		[TestCase(
			new int[] { 1, 2, 3, 4 },
			new string[] { "John Doe", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { -1, -10, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		)]
		//invalid score kisebb mint 0
		[TestCase(
			new int[] { 1, 2, 3, 4 },
			new string[] { "John Doe", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { -1, -10, 0, 0 }
		)]
		//invalid nagyobb mint 100
		[TestCase(
			new int[] { 1, 2, 3, 4 },
			new string[] { "John Doe", "Jane Doe", "Jack Doe", "Jill Doe" },
			new int[] { 0, 0, 0, 0 },
			new int[] { 101, 110, 0, 0 }
		)]
		public void SetPeople_InvalidInput_ArgumentExceptiontDob(int[] ids, string[] names, int[] ages, int[] scores)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				stats.People = new List<Person>
				{
					new Person(ids[0], names[0], ages[0], true, scores[0]),
					new Person(ids[1], names[1], ages[1], false, scores[1]),
					new Person(ids[2], names[2], ages[2], true, scores[2]),
					new Person(ids[3], names[3], ages[3], false, scores[3])
				};
			});
		}

		[Test]
		[Category("GetAverageAge")]
		[TestCase(16, 18, 20, 15, ExpectedResult = 17.25)]
		[TestCase(20, 20, 20, 20, ExpectedResult = 20)]
		[TestCase(0, 0, 0, 0, ExpectedResult = 0)]
		[TestCase(1, 2, 3, 4, ExpectedResult = 2.5)]
		public double GetAverageAge_HelyesenMukodik(int age1, int age2, int age3, int age4)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", age1, true, 0),
				new Person(2, "Jane Doe", age2, false, 100),
				new Person(3, "Jack Doe", age3, true, 50),
				new Person(4, "Jill Doe", age4, false, 75)
			};

			return stats.GetAverageAge();
		}

		[Test]
		[Category("GetNumberOfStudents")]
		[TestCase(true, false, true, false, ExpectedResult = 2)]
		[TestCase(false, false, false, false, ExpectedResult = 0)]
		[TestCase(true, true, true, true, ExpectedResult = 4)]
		[TestCase(false, true, false, true, ExpectedResult = 2)]
		public int GetNumberOfStudents_HelyesenMukodik(bool isStudent1, bool isStudent2, bool isStudent3, bool isStudent4)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", 0, isStudent1, 0),
				new Person(2, "Jane Doe", 0, isStudent2, 100),
				new Person(3, "Jack Doe", 0, isStudent3, 50),
				new Person(4, "Jill Doe", 0, isStudent4, 75)
			};

			return stats.GetNumberOfStudents();
		}

		[Test]
		[Category("GetPersonWithHighestScore")]
		[TestCase(0, 0, 0, 0, ExpectedResult = 1)]
		[TestCase(100, 0, 0, 0, ExpectedResult = 1)]
		[TestCase(0, 75, 0, 0, ExpectedResult = 2)]
		[TestCase(0, 0, 50, 0, ExpectedResult = 3)]
		[TestCase(0, 0, 0, 25, ExpectedResult = 4)]
		[TestCase(69, 42, 96, 9, ExpectedResult = 3)]
		public int GetPersonWithHighestScore_HelyesenMukodik(int score1, int score2, int score3, int score4)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", 0, true, score1),
				new Person(2, "Jane Doe", 0, false, score2),
				new Person(3, "Jack Doe", 0, true, score3),
				new Person(4, "Jill Doe", 0, false, score4)
			};

			return stats.GetPersonWithHighestScore().Id;
		}

		[Test]
		[Category("GetAverageScoreOfStudents")]
		[TestCase(new int[] { 10, 10, 10, 10}, new bool[] { false, false, false, false}, ExpectedResult = 0)]
		[TestCase(new int[] { 69, 42, 96, 9 }, new bool[] { true, true, true, true }, ExpectedResult = 54)]
		[TestCase(new int[] { 0, 0, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 0)]
		[TestCase(new int[] { 100, 0, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 50)]
		[TestCase(new int[] { 0, 75, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 0)]
		[TestCase(new int[] { 0, 75, 50, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 25)]
		public double GetAverageScoreOfStudents_HelyesenMukodik(int[] scores, bool[] areStudents)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", 0, areStudents[0], scores[0]),
				new Person(2, "Jane Doe", 0, areStudents[1], scores[1]),
				new Person(3, "Jack Doe", 0, areStudents[2], scores[2]),
				new Person(4, "Jill Doe", 0, areStudents[3], scores[3])
			};

			return stats.GetAverageScoreOfStudents();
		}

		[Test]
		[Category("GetOldestStudent")]
		[TestCase(new int[] { 10, 10, 10, 10 }, new bool[] { false, false, false, false }, ExpectedResult = null)]
		[TestCase(new int[] { 0, 0, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 1)]
		[TestCase(new int[] { 100, 0, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 1)]
		[TestCase(new int[] { 0, 75, 0, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 1)]
		[TestCase(new int[] { 0, 75, 50, 0 }, new bool[] { true, false, true, false }, ExpectedResult = 3)]
		[TestCase(new int[] { 69, 42, 96, 9 }, new bool[] { true, true, true, true }, ExpectedResult = 3)]
		public int? GetOldestStudent_HelyesenMukodik(int[] ages, bool[] areStudents)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", ages[0], areStudents[0], 0),
				new Person(2, "Jane Doe", ages[1], areStudents[1], 100),
				new Person(3, "Jack Doe", ages[2], areStudents[2], 50),
				new Person(4, "Jill Doe", ages[3], areStudents[3], 75)
			};

			return stats.GetOldestStudent()?.Id;
		}

		[Test]
		[Category("IsAnyOneFailing")]
		[TestCase(0, 0, 0, 0, ExpectedResult = true)]
		[TestCase(39, 40, 41, 42, ExpectedResult = true)]
		[TestCase(14, 42, 69, 9, ExpectedResult = true)]
		[TestCase(40, 40, 40, 40, ExpectedResult = false)]
		[TestCase(100, 40, 50, 60, ExpectedResult = false)]
		public bool IsAnyOneFailing_HelyesenMukodik(int score1, int score2, int score3, int score4)
		{
			stats.People = new List<Person>
			{
				new Person(1, "John Doe", 0, true, score1),
				new Person(2, "Jane Doe", 0, false, score2),
				new Person(3, "Jack Doe", 0, true, score3),
				new Person(4, "Jill Doe", 0, false, score4)
			};

			return stats.IsAnyOneFailing();
		}

	}
}