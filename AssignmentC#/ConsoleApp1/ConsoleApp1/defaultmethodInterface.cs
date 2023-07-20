using System;

public class Program
{
    public static void Main()
    {
        IFile file1 = new FileInfo();
        file1.ReadFile();
        file1.WriteFile("content");
        file1.DisplayName();
        FileInfo file2 = new FileInfo();
        //file2.DisplayName(); //compile-time error 
    }
}

interface IFile
{
    void ReadFile();
    void WriteFile(string text);

    void DisplayName()
    {
        Console.WriteLine("IFile");
    }
}

class FileInfo : IFile
{
    public void ReadFile()
    {
        Console.WriteLine("Reading File");
    }

    public void WriteFile(string text)
    {
        Console.WriteLine("Writing to file");
    }
}