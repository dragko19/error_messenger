using System;
using System.IO;
using System.Collections.Generic;


class Error_messenger
{

    private List<string> _Messages  = new List<string>();
    private uint _Errors_count;
    
    public Error_messenger()
    {
        _Errors_count = 0;
    }

    public uint Get_error_count()
    {
        return _Errors_count;
    }

    public void Report_error(string msg)
    {
        _Messages.Add(msg);
        _Errors_count++;
    }

    public void Print_current_state(ref MemoryStream MemStr)
    {
        MemStr.Seek(0, SeekOrigin.Begin);
        using (StreamWriter sw = new StreamWriter(MemStr))
        {
            sw.WriteLine("Number of errors: {0}", _Errors_count);
            foreach (string lines in _Messages)
                sw.WriteLine(lines);
            sw.Flush();
        }
    }

    public void Save_report_to_file(string path)
    {
        MemoryStream MemStr = new MemoryStream();
        Print_current_state(ref MemStr);
        MemStr.Seek(0, SeekOrigin.Begin);
        try
        {
            FileStream fS = new FileStream(path, FileMode.OpenOrCreate);
            MemStr.CopyTo(fS);
            fS.Flush();                
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

