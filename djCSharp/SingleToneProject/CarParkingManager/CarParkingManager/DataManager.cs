using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingManager
{
    public class DataManager
    {
        public List<ParkingCar> parkingAreas = new List<ParkingCar>();
        private static DataManager instance;
        public static DataManager Instance 
        { 
            get 
            { 
                if (instance == null)
                    instance = new DataManager();
                return instance; 
            } 
        }

        private DataManager()
        {
            Load();
        }
        public void Load()
        {

        }
        public void printLog(string v) //기록을 남기는 용도
        {
            DirectoryInfo di = new DirectoryInfo("parkingHistory");
            if (di.Exists == false)
                di.Create(); //해당 경로 없으면 새로 만듦
            //@"parkingHistory\parkingHistory.txt"
            //"parkingHistory\\parkingHistory.txt"
            //끝에 true가 붙어서 새로운 내용이 parkingHistory.txt에 계속 append(이어붙여짐)
            using (StreamWriter w = new StreamWriter(@"parkingHistory\parkingHistory.txt", true))
            {
                w.WriteLine(v);
            }

        }
        //주차 출차용 Save
        //Save(new ParkingCar(), true) -> isRemove 값은 true
        //Save(new ParkingCar()) -> isRemove 값은 기본 값으로 지정해 둔 false
        public void Save(ParkingCar parkingArea, bool isRemove=false)
        {

        }
        //주차공간을 추가/삭제하는 Save
        public bool Save(string cmd, int parkingSpot, out string contents)
        {
            contents = "";
            return true;
        }
    }
}
