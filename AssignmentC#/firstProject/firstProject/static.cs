using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class Program
{
    public static void Main()
    {
        //StopWatch.DisplayInfo(); // static constructor called here
        //StopWatch.DisplayInfo(); // none of the constructors called here

        StopWatch sw1 = new StopWatch(); // First static constructor and then instance constructor called 
        StopWatch sw2 = new StopWatch();// only instance constructor called 
        //StopWatch.DisplayInfo();
        sw1.Start();
    }
}
public class StopWatch
{
    // static constructor
    static StopWatch()
    {
        Console.WriteLine("Static constructor called");
    }

    // instance constructor
    public StopWatch()
    {
        Console.WriteLine("Instance constructor called");
    }

    // static method
    public static void DisplayInfo()
    {
        Console.WriteLine("DisplayInfo called");
    }

    // instance method
    public void Start() {
        Console.WriteLine("hii");
    }

    // instance method
    public void Stop() { }
}
