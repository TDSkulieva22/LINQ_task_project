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

    var square = numbers.Select(x => x * x);

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
    
    var evenNumbers = numbers.Where(x => x % 2 == 0);

    foreach (var num in evenNumbers)
    {
        Console.Write(num + " ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 4 ---");

    var res = students.Where(s => s.City == "Burgas" && s.Age >= 18);

    foreach (var result in res)
    {
        Console.Write(result.Name + "(Id " + result.Id + ")   ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 5 ---");

    var aged = students.Where(s => s.Age >= 18).Select(s => s.Name);

    foreach (var stud in aged)
    {
        Console.Write(stud + "  ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 6 ---");

    var n = numbers.OrderBy(x => x);
    foreach (var num in n)
    {
        Console.Write(num + " ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 7 ---");

    var all = students.Where(s => s.Age >= 18).OrderBy(x => x.Age).Select(x => x.Name);

    foreach (var stu in all)
    {
        Console.Write(stu + "  ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 8 ---");

    var sorted = numbers.OrderBy(x => -x);

    foreach (var num in sorted)
    {
        Console.Write(num + " ");
    }
    
    Console.WriteLine();
    Console.WriteLine("--- Task 9 ---");

    var person = students.First(x => x.City == "Sofia");

    Console.Write(person.Name + " (Id " + person.Id + ")");

    Console.WriteLine();
    Console.WriteLine("--- Task 10 ---");

    try
    {
        var per = students.First(x => x.City == "Plovdiv");
    }
    catch(InvalidOperationException ex)
    {
        Console.WriteLine($"Exception: {ex.GetType().Name}");
        Console.WriteLine($"Message: {ex.Message}");
    }

    Console.WriteLine("--- Task 11 ---");
    
    var p = students.Single(x => x.Id == 4);

    Console.Write(p.Name + " (Id " + p.Id + ")");

    Console.WriteLine();
    Console.WriteLine("--- Task 12 ---");

    try
    {
        var many = students.Single(s => s.Age == 18);
    }
    catch(InvalidOperationException ex)
    {
        Console.WriteLine($"Query 1 error: {ex.Message}");
    }

    try
    {
        var zero = students.Single(s => s.Age == 99);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Query 2 error: {ex.Message}");
    }

    Console.WriteLine("--- Task 13 ---");

    var n1 = numbers.First(n => n > 7);

    Console.WriteLine("Query 1 error: " + n1);

    try
    {
        var n2 = numbers.Single(n => n > 7);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Query 2 error: {ex.Message}");
    }

    var n3 = numbers.Single(n => n > 10);

    Console.WriteLine("Query 3 error: " + n3);

    try
    {
        var n4 = numbers.First(n => n < 0);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Query 4 error: {ex.Message}");
    }

    Console.WriteLine("--- Task 14 ---");

    var group = students.GroupBy(x => x.City);

    foreach (var g in group)
    {
        Console.Write(g.Key + ": ");
        
        var names =  g.Select(x => x.Name);
        
        Console.Write(string.Join(", ", names));
        Console.WriteLine();
    }

    Console.WriteLine("--- Task 15 ---");

    var groupAge = students.GroupBy(x => x.Age >= 18);

    foreach (var g in groupAge)
    {
        string l = g.Key ? "Adults" : "Minors";
        var names = g.Select(x => x.Name);
        Console.WriteLine(l + ": " +  string.Join(", ", names));
    }

    Console.WriteLine("--- Task 16 ---");

    var enr = enrollments.Where(x => x.Grade >= 5).GroupBy(x => x.CourseId);

    foreach (var g in enr)
    {
        var enrId = g.Select(x => x.Id);
        Console.WriteLine(g.Key + ": " + string.Join(", ", enrId));
    }

    Console.WriteLine("--- Task 17 ---");

    var enDetail = enrollments.Join(students,
        en => en.StudentId,
        stu => stu.Id,
        (en, stu) => new
        {
            EnId = en.Id,
            StudName = stu.Name,
            Grade = en.Grade
        });

    foreach (var en in enDetail)
    {
        Console.Write(en.EnId + "/" + en.StudName + "/" + en.Grade + "   ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 18 ---");

    var courseDetails = courses.Join(enrollments,
        c => c.Id,
        en => en.CourseId,
        (c, en) => new
        {
            cTitle = c.Title,
            StudId = en.StudentId,
            enGrade = en.Grade
        })
        .Where(g => g.enGrade >= 5)
        .GroupBy(g => g.cTitle);

    foreach (var g in courseDetails)
    {
        var det = g.Select(i => i.StudId + "/" + i.enGrade);
        Console.Write(g.Key + ": " + string.Join(", ", det) + "   ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 19 ---");

    var report = enrollments.Join(students,
            en => en.StudentId,
            s => s.Id,
            (en, s) => new
            {
                StName = s.Name,
                EId = en.Id,
                EGrades = en.Grade,
                ECourseId = en.CourseId
            })
        .Join(courses,
            com => com.ECourseId,
            c => c.Id,
            (com, c) => new
            {
                com.EId,
                com.StName,
                cTitle = c.Title,
                Grade = com.EGrades
            })
        .Where(g => g.Grade >= 5)
        .OrderBy(en => en.EId);

    foreach (var x in report)
    {
        Console.Write(x.StName + "/" + x.cTitle + "/" + x.Grade + "   ");
    }

    Console.WriteLine();
    Console.WriteLine("--- Task 20 ---");

    var allDetails = enrollments.Join(students,
        en => en.StudentId,
        s => s.Id,
        (en, s) => new
        {
            EId = en.Id,
            SName = s.Name,
            EGrade = en.Grade,
            ECourseId = en.CourseId
        })
        .Join(courses,
            comb => comb.ECourseId,
            c => c.Id,
            (comb, c) => new
            {
                comb.EId,
                comb.SName,
                Grade = comb.EGrade,
                CourseId = c.Id,
                cTitle = c.Title
            })
        .GroupBy(g => new
        {
            g.CourseId,
            g.cTitle
        })
        .OrderBy(x => x.Key.CourseId)
        .Select(g =>
        {
            var highE = g.OrderBy(x => -x.Grade).First();

            return new
            {
                CTitle = g.Key.cTitle,
                StudentN = highE.SName,
                Grade = highE.Grade
            };
        });

    foreach (var x in allDetails)
    {
        Console.Write(x.CTitle + "/" + x.StudentN + "/" + x.Grade + "   ");
    }

    public record Student(int Id, string Name,
        int Age, string City);
    public record Course(int Id, string Title);
    public record Enrollment(int Id, int StudentId,
        int CourseId, int Grade);

