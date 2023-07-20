using System;
using System.Linq;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        // Student collection
        List<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

        //var groupedResult = from s in studentList
        //                    group s by s.Age;
        //var groupedResult = studentList.GroupBy(s => s.Age);
        var lookupResult = studentList.ToLookup(s => s.Age);
        //iterate each group        
        foreach (var ageGroup in /*groupedResult*/ lookupResult)
        {
            Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

            foreach (Student s in ageGroup) // Each group has inner collection
                Console.WriteLine("Student Name: {0}", s.StudentName);
        }
        Console.ReadKey();

    }

}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

}