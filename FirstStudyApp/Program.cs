using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>() {
                new People("Иван", 31, PeopleSex.Male, 400),
                new People("Женя", 24, PeopleSex.Male, 21000),
                new People("Даша", 22, PeopleSex.Female, 570),
                new People("Леша", 25, PeopleSex.Male, 14758),
                new People("Соня", 27, PeopleSex.Female, 4792),
            };

            var maxAge = people.OrderByDescending(x => x.Age).FirstOrDefault();
            Console.WriteLine($"Max age - {maxAge}");

            var reachestPeople = people.OrderByDescending(x => x.Balance).FirstOrDefault();
            Console.WriteLine($"Reachest people - {reachestPeople}");

            var oldReachPeople = people.FirstOrDefault(x => x.Balance == (people.Where(p => p.Age == people.Max(y => y.Age)).Max(b => b.Balance)));
            Console.WriteLine($"Самый богатый из старших - {oldReachPeople}");

            Console.WriteLine();

            var balanceMoreThan4000 = people.Where(x => x.Balance > 4000);
            Console.WriteLine("More than 4000:");
            foreach (People person in balanceMoreThan4000)
            {
                Console.WriteLine($"{person}");
            }

            Console.WriteLine();

            var orderedByAge = people.OrderBy(x => x.Age);
            Console.WriteLine("Ordered by age:");
            foreach (People person in orderedByAge)
            {
                Console.WriteLine($"{person}");
            }

            Console.WriteLine();

            var orderedBySex = people.OrderBy(x => x.Sex);
            Console.WriteLine("Ordered by sex:");
            foreach (People person in orderedBySex)
            {
                Console.WriteLine($"{person}");
            }

            Console.WriteLine();

            var orderedByBalance = people.OrderBy(x => x.Balance);
            Console.WriteLine("Ordered by balance:");
            foreach (People person in orderedByBalance)
            {
                Console.WriteLine($"{person}");
            }

            Console.ReadLine();
        }
    }

    enum PeopleSex { Male, Female }
    class People
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public PeopleSex Sex { get; set; }
        public long Balance { get; set; }

        public People(string name, uint age, PeopleSex sex, long balance)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Человек({Name}, {Age}, {Sex}, {Balance})";
        }
    }
}
