namespace PeopleProject
{
	public class Person
	{
		private int id;
		private string name;
		private int age;
		private bool isStudent;
		private int score;

		public int Id
		{
			get => id;
			set {
				if (value <= 0) throw new ArgumentException("Az id számozása 1-től kezdődik", nameof(value));
				id = value;
			}
		}
		public string Name
		{
			get => name;
			set {
				if (string.IsNullOrEmpty(value)) throw new ArgumentException("A név nem lehet üres", nameof(value));
				if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A név nem lehet csak szóköz", nameof(value));
				name = value;
			}
		}
		public int Age
		{
			get => age;
			set
			{
				if (value < 0) throw new ArgumentException("Az életkor nem lehet negatív szám", nameof(value));
				age = value;
			}
		}
		public bool IsStudent
		{
			get => isStudent;
			set => isStudent = value;
		}
		public int Score
		{
			get => score;
			set
			{
				if (value < 0 || value > 100) throw new ArgumentException("A pontszám 0 és 100 közötti szám lehet", nameof(value));
				score = value;
			}
		}

		public Person(int id, string name, int age, bool isStudent, int score)
		{
			if (id <= 0) throw new ArgumentException("Az id számozása 1-től kezdődik", nameof(id));
            if (score < 0 || score > 100) throw new ArgumentException("A pontszám 0 és 100 közötti szám lehet", nameof(score));
			if (age < 0) throw new ArgumentException("Az életkor nem lehet negatív szám", nameof(age));
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("A név nem lehet üres", nameof(name));
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A név nem lehet csak szóköz", nameof(name));

			this.id = id;
			this.name = name;
			this.age = age;
			this.isStudent = isStudent;
			this.score = score;
		}
	}
}
