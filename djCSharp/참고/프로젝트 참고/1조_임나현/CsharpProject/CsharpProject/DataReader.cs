using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class DataReader
    {
        public List<Data> readDataFile(string dir) // function that reads csv data file and return as List<Data>. use a string parameter of the file directory.
        {
            string ext = dir.Substring(dir.LastIndexOf('.'));
            List<Data> ret = new List<Data>();
            if (ext == ".csv")
            {
                StreamReader sr = new StreamReader(dir);
                int linecount = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    if(linecount != 0)
                    {
                        Data buf = new Data();
                        buf.Index = int.Parse(data[0]);
                        buf.Lot = int.Parse(data[1]);
                        buf.Time = data[2];
                        buf.pH = double.Parse(data[3]);
                        buf.Temp = double.Parse(data[4]);
                        buf.Current = double.Parse(data[5]);
                        buf.Voltage = double.Parse(data[6]);
                        ret.Add(buf);
                    }
                    linecount++;
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("This file extension is not supported!");
                Console.WriteLine("You must use the file with these extensions below:");
                Console.WriteLine(".csv");
            }
            return ret;
        }


    }
}
