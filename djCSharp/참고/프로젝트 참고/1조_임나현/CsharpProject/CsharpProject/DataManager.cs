using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpProject
{
    public class DataManager
    {
        public string getFileNameByFolder(int[] ymd, string folderName, out bool isokay)
        {
            isokay = false;
            string dir = folderName + "\\";
            string zero1 = ".";
            string zero2 = ".";
            if (ymd[1] < 10)
                zero1 = ".0";
            if (ymd[2] < 10)
                zero2 = ".0";
            dir += "kemp-abh-sensor-" + ymd[0] + zero1 + ymd[1] + zero2 +  ymd[2] + ".csv";
            FileInfo fi = new FileInfo(dir);
            if (fi.Exists)
            {
                isokay = true;
            }
            else
                isokay = false;
            return dir;
        }

        public string getFolderNameByFile(string filename)
        {
            string ret = filename.Substring(0, filename.LastIndexOf("\\"));
            return ret;
        }

        public string getFileName(string fileName, out bool isokay)
        {
            string dir = fileName;
            FileInfo fi = new FileInfo(dir);
            if (fi.Exists)
            {
                isokay = true;
            }
            else
                isokay = false;
            return dir;
        }

        public double[] timeSplit(string time) // list[0] = hour ,list[1] = minute ,list[2] = second
        {
            string[] list = time.Split(':');
            if (list[0].Contains("오전"))
            {
                list[0] = list[0].Substring(list[0].LastIndexOf(' ') + 1);
            }
            else if (list[0].Contains("오후"))
            {
                list[0] = (int.Parse(list[0].Substring(list[0].LastIndexOf(' ') + 1)) + 12).ToString();
            }
            double[] ret = new double[list.Length];
            for(int i = 0; i<list.Length; i++)
            {
                ret[i] = double.Parse(list[i]);
            }
            return ret;
        }
        public string getDateFromFileName(string fileName)
        {
            string ret = fileName.Substring(fileName.LastIndexOf("-")+1);
            string[] ymd = ret.Split('.');
            ret = $"{ymd[0]}년 {ymd[1]}월 {ymd[2]}일";
            return ret;
        }
        public int[] getDateFromFileName2(string fileName)
        {
            string ret = fileName.Substring(fileName.LastIndexOf("-") + 1);
            int[] ymd = new int[3];
            ymd[0] = int.Parse(ret.Split('.')[0]);
            ymd[1] = int.Parse(ret.Split('.')[1]);
            ymd[2] = int.Parse(ret.Split('.')[2]);
            return ymd;
        }

        public List<Data> getData(string dir)
        {
            List<Data> datalist = new List<Data>();
            DataReader reader = new DataReader();
            datalist = reader.readDataFile(dir);
            foreach( Data d in datalist ) 
            {
                d.date = getDateFromFileName(dir);
            }
            return datalist;          
        }


    }
}
