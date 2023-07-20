using System;

public class Program
{
    public static void Main()
    {
        StringDataStore strStore = new StringDataStore();

        strStore[0] = "One";
        strStore[1] = "Two";
        strStore[2] = "Three";
        strStore[3] = "Four";

        Console.WriteLine(strStore["one"]);
        Console.WriteLine(strStore["two"]);
        Console.WriteLine(strStore["Three"]);
        Console.WriteLine(strStore["FOUR"]);
    }
}

public class StringDataStore
{

    private string[] strArr = new string[10]; // internal data storage

    public StringDataStore()
    {

    }

    public string this[int index]
    {
        get
        {
            if (index < 0 && index >= strArr.Length)
                throw new IndexOutOfRangeException("Cannot store more than 10 objects");

            return strArr[index];
        }

        set
        {
            if (index < 0 && index >= strArr.Length)
                throw new IndexOutOfRangeException("Cannot store more than 10 objects");

            strArr[index] = value;
        }
    }

    public string this[string name]
    {
        get
        {
            foreach (string str in strArr)
            {
                if (str.ToLower() == name.ToLower())
                    return str +"1";
            }

            return "";
        }
    }
}