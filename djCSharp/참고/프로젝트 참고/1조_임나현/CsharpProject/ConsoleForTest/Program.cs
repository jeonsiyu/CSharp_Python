
using System.Text.Json.Nodes;

public class Program
{
    public static void Main(string[] args)
    {
        string date = "오후 4:27:17.0";

        string[] list = date.Split(':');
         
        if (list[0].Contains("오전"))
        {
            list[0] = list[0].Substring(list[0].LastIndexOf(' ') + 1);
        }
        else if (list[0].Contains("오후"))
        {
            list[0] = (int.Parse(list[0].Substring(list[0].LastIndexOf(' ') + 1)) + 12).ToString();
        }

        foreach (string item in list) 
        {
            Console.WriteLine(item);
        }

        /*        string dir = "C:\\Users\\KB\\Documents\\data\\kemp-abh-sensor-2021.09.06.csv";
                string ext = dir.Substring(dir.LastIndexOf('.'));

                if(ext == ".csv")
                {
                    StreamReader sr = new StreamReader(dir);      
                    while(!sr.EndOfStream) 
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(",");
                        for(int i=0;i<data.Length;i++)
                        {
                            Console.Write(data[i]+" | ");
                        }
                        Console.WriteLine("");
                        //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                    }
                    sr.Close();
                }
                else if(ext == ".json")
                {
                    Console.WriteLine("sorry, this feature is not implemented yet.");
                }
                else if(ext == ".xml")
                {
                    Console.WriteLine("sorry, this feature is not implemented yet.");
                }
                else
                {
                    Console.WriteLine("This file extension is not supported!");
                    Console.WriteLine("You must use the file with these extensions below:");
                    Console.WriteLine(".csv //, .json, .xml");
                }*/
        /*
                string dirhead = "C:\\Users\\KB\\Documents\\data\\kemp-abh-sensor-2021.";
                string dirtail = ".csv";
                string month = "9";
                string day = "6";

                if (int.Parse(month) < 10)
                    month = "0" + month;
                if (int.Parse(day) < 10)
                    day = "0" + day;

                string dir = dirhead + month + "." + day + dirtail;
                Console.WriteLine(dir);*/


    }
}
