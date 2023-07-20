using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.AccessControl;


//public class Program
//{
//    public static void Main()
//    {
//        // Student collection
//        IList<Student> studentList = new List<Student>() {
//                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
//                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
//                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
//                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
//                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
//            };

//        // LINQ Query Syntax to find out teenager students
//        var teenAgerStudent = from s in studentList
//                              where s.Age > 12 && s.Age < 20
//                              select s;
//        Console.WriteLine("Teen age Students:");

//        foreach (Student std in teenAgerStudent)
//        {
//            Console.WriteLine(std.StudentName);
//        }
//        Console.ReadKey();
//    }
//}
//public class Program
//{
//    public static void Main()
//    {
//        // Student collection
//        IList<Student> studentList = new List<Student>() {
//                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
//                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
//                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
//                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
//                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
//            };

//        //Func<Student, bool> isTeenAger = delegate (Student s) {
//        //    return s.Age > 12 && s.Age < 20;
//        //};

//        //var filteredResult = from s in studentList
//        //                     where isTeenAger(s)
//        //                     select s;

//        var filteredResult = studentList.Where(s => s.Age > 12 && s.Age < 20);

//        foreach (var std in filteredResult)
//            Console.WriteLine(std.StudentName);
//        Console.ReadLine();
//    }
//}


public class Program
{
    public static void Main()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

        var filteredResult = studentList.Where((s, i) => {
            Console.WriteLine(i);
            if (i % 2 == 0) // if it is even element
                return true;

            return false;
        });

        foreach (var std in filteredResult)
            Console.WriteLine(std.StudentName);
        Console.ReadKey();
    }
}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

}
