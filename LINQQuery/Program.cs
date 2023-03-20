using System;
using System.Collections.Generic;
using System.Linq;

class FamousPeople
{
    public string Name { get; set; }
    public int? BirthYear { get; set; } = null;
    public int? DeathYear { get; set; } = null;
}

class Program
{
    static void Main()
    {
        IList<FamousPeople> stemPeople = new List<FamousPeople>()
        {
            // ...
        };

        // a) Retrieve people with birthdates after 1900
        var query1 = from person in stemPeople
                     where person.BirthYear > 1900
                     select person;

        Console.WriteLine("People with birthdates after 1900:");
        foreach (var person in query1)
        {
            Console.WriteLine(person.Name);
        }
        Console.WriteLine();

        // b) Retrieve people who have two lowercase L's in their name
        var query2 = from person in stemPeople
                     where person.Name.ToLower().Split('l').Length - 1 >= 2
                     select person;

        Console.WriteLine("People who have two lowercase L's in their name:");
        foreach (var person in query2)
        {
            Console.WriteLine(person.Name);
        }
        Console.WriteLine();

        // c) Count the number of people with birthdays after 1950
        var query3 = (from person in stemPeople
                      where person.BirthYear > 1950
                      select person).Count();

        Console.WriteLine($"Number of people with birthdays after 1950: {query3}");
        Console.WriteLine();

        // d) Retrieve people with birth years between 1920 and 2000. Display their names and count the number of people in the list, then display the count.
        var query4 = from person in stemPeople
                     where person.BirthYear >= 1920 && person.BirthYear <= 2000
                     select person;

        Console.WriteLine("People with birth years between 1920 and 2000:");
        foreach (var person in query4)
        {
            Console.WriteLine(person.Name);
        }

        var birthCount = query4.Count();
        Console.WriteLine($"Number of people with birth years between 1920 and 2000: {birthCount}");
        Console.WriteLine();

        // e) Sort the list by BirthYear
        var query5 = from person in stemPeople
                     orderby person.BirthYear
                     select person;

        Console.WriteLine("List sorted by BirthYear:");
        foreach (var person in query5)
        {
            Console.WriteLine($"{person.Name} - {person.BirthYear}");
        }
        Console.WriteLine();

        // f) Retrieve people with a death year after 1960 and before 2015, sort the list by name in ascending order.
        var query6 = from person in stemPeople
                     where person.DeathYear > 1960 && person.DeathYear < 2015
                     orderby person.Name
                     select person;

        Console.WriteLine("People with a death year after 1960 and before 2015, sorted by name in ascending order:");
        foreach (var person in query6)
        {
            Console.WriteLine($"{person.Name} - {person.DeathYear}");
        }
    }
}
