using System;
using System.IO;


class Tests
{
    public static void Main()
    {
        MemoryStream MemStr = new MemoryStream();
        StreamWriter StrWr = new StreamWriter(MemStr);
        Error_messenger Err = new Error_messenger(ref MemStr);

        if (Err.Get_error_count() != 0)
            Console.WriteLine("Error of constructor!");

        Err.Report_error("First error report");

        if (Err.Get_error_count() != 1)
            Console.WriteLine("Error of Report_error() method!");

        for (int i = 2; i <= 20; i++)
        {
            Err.Report_error("This is error number " + i);
            if (Err.Get_error_count() != i)
                Console.WriteLine("Error in Report_error method in test nubmer" + i);
        }

        Err.Print_current_state();

        for (int i = 21; i <= 40; i++)
        {
            Err.Report_error("This is error number " + i);
            if (Err.Get_error_count() != i)
                Console.WriteLine("Error in Report_error method in test nubmer" + i);
        }

        Err.Print_current_state();

        Err.Save_report("report.txt");

        Console.ReadLine();
    }
}