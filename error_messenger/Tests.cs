using System;
using System.IO;


class Tests
{
    public static void Main()
    {
        MemoryStream MemStr = new MemoryStream();
        StreamWriter StrWr = new StreamWriter(MemStr);
        Error_messenger Err = new Error_messenger();

        if (Err.Get_error_count() != 0)
            Console.WriteLine("Error of constructor!");

        Err.Report_error("First error report");

        if (Err.Get_error_count() != 1)
            Console.WriteLine("Error of Report_error() method!");

        for(int i = 2; i <= 20; i++)
        {
            Err.Report_error("This is error number " + i);
            if (Err.Get_error_count() != i)
                Console.WriteLine("Error in Report_error method in test nubmer" + i);
        }

        Err.Print_current_state(ref MemStr);
        using (MemoryStream Mstr = new MemoryStream())
        {
            Mstr = MemStr;
            using (var StrRd = new StreamReader(Mstr))        
            
            Mstr.Seek(0, SeekOrigin.Begin);
            string line;
            while ((line = StrRd.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

            for (int i = 21; i <= 40; i++)
            {
                Err.Report_error("This is error number " + i);
                if (Err.Get_error_count() != i)
                    Console.WriteLine("Error in Report_error method in test nubmer" + i);
            }

        //Err.Print_current_state(ref MemStr);

        //Err.Save_report_to_file("report.txt");

        Console.ReadLine();
    }
}

