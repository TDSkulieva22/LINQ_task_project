using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

int[] numbers = { 8, 3, 12, 5, 2, 9, 4, 7 };
    Student[] students =
    {
        new Student(1, "Ana", 17, "Burgas"),
        new Student(2, "Boris", 18, "Sofia"),
        new Student(3, "Clara", 20, "Burgas"),
        new Student(4, "Deyan", 19, "Varna"),
        new Student(5, "Elena", 18, "Sofia"),
        new Student(6, "Filip", 21, "Burgas")
    };

    Course[] courses =
    {
        new Course(101, "C# Basics"),
        new Course(102, "Web Development"),
        new Course(103, "Databases"),
        new Course(104, "Algorithms")
    };
    Enrollment[] enrollments =
    {
        new Enrollment(1, 1, 101, 5),
        new Enrollment(2, 2, 101, 6),
        new Enrollment(3, 3, 102, 6),
        new Enrollment(4, 4, 102, 4),
        new Enrollment(5, 5, 103, 5),
        new Enrollment(6, 6, 103, 6),
        new Enrollment(7, 2, 103, 4),
        new Enrollment(8, 3, 101, 3),
        new Enrollment(9, 6, 102, 5)
    };

    Console.WriteLine("--- Task 1 ---");

    int[] square = numbers.Select(x => x * x).ToArray();

    foreach (var num in square)
    {
        Console.Write(num + " ");
    }
    
    Console.WriteLine();
    Console.WriteLine("--- Task 2 ---");

    var results = students.Select(x => new { x.Name, x.City });

    foreach (var result in results)
    {
        Console.Write(result.Name + " / " + result.City + "   ");
    }

    Console.WriteLine("--- Task 3 ---");
    
    int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();

    foreach (var num in evenNumbers)
    {
        Console.Write(num + " ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 4 ---");

    var res = students.Where(s => s.City == "Burgas" && s.Age >= 18).ToArray();

    foreach (var result in res)
    {
        Console.Write(result.Name + "(Id " + result.Id + ")   ");
    }







    public record Student(int Id, string Name,
        int Age, string City);
    public record Course(int Id, string Title);
    public record Enrollment(int Id, int StudentId,
        int CourseId, int Grade);

