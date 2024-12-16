using PeopleProject;

namespace TestPeopleProject
{
	[TestFixture]
	[TestOf(typeof(Person))]
	[Category("Person Class Tesztek")]
	public class PersonTests
	{
		[Test]
		[Category("Konstruktor Inicializálás")]
		[TestCase(1, "John Doe", 0, true, 0)]
		[TestCase(2, "Jane Doe", 50, false, 100)]
		[TestCase(3, "Jack Doe", 100, true, 50)]
		[TestCase(4, "Jill Doe", 25, false, 75)]
		public void Letrehozas_HelyesenMukodik(int id, string name, int age, bool isStudent, int score)
		{
			Person person = new Person(id, name, age, isStudent, score);

			Assert.That(person.Id, Is.EqualTo(id));
			Assert.That(person.Name, Is.EqualTo(name));
			Assert.That(person.Age, Is.EqualTo(age));
			Assert.That(person.IsStudent, Is.EqualTo(isStudent));
			Assert.That(person.Score, Is.EqualTo(score));
		}

		[Test]
		[Category("Id Invalid input")]
		[TestCase(-1)]
		[TestCase(0)]
		public void InvalidId_ArgumentExceptiontDob(int id)
		{
			Assert.Throws<ArgumentException>(() => new Person(id, "John Doe", 0, true, 0));
		}

		[Test]
		[Category("Score Invalid input")]
		[TestCase(-1)]
		[TestCase(101)]
		public void InvalidScore_ArgumentExceptiontDob(int score)
		{
			Assert.Throws<ArgumentException>(() => new Person(1, "John Doe", 0, true, score));
		}

		[Test]
		[Category("Age Invalid input")]
		[TestCase(-1)]
		public void InvalidAge_ArgumentExceptiontDob(int age)
		{
			Assert.Throws<ArgumentException>(() => new Person(1, "John Doe", age, true, 0));
		}

		[Test]
		[Category("Name Invalid input")]
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void InvalidName_ArgumentExceptiontDob(string name)
		{
			Assert.Throws<ArgumentException>(() => new Person(1, name, 0, true, 0));
		}
	}

}
