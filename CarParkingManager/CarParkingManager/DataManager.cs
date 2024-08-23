using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingManager
{
    public class DataManager
    {
        public List<ParkingCar> parkingAreas = new List<ParkingCar>();
        private DBHelper myDB = DBHelperOracle.getInstance; //Oracle이라면 이 부분만 바꾸면 됨
        private static DataManager instance;
        public static DataManager Instance
        {
            get
            {
                if(instance == null)
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
            try
            {
                myDB.selectQuery();//매개변수 없으므로 전체 조회
                parkingAreas.Clear();
                //var 말고 DataRow 써야지 잘 됨
                foreach (DataRow item in myDB.dt.Rows)
                {
                    ParkingCar c = new ParkingCar();
                    c.parkingSpot = int.Parse(item["parkingspot"].ToString());
                    c.carNumber = item["carnumber"].ToString();
                    c.driverName = item["driverName"].ToString();
                    c.phoneNumber = item["phoneNumber"].ToString();
                    c.parkingTime = item["parkingTime"].ToString() == "" ? new DateTime()
                        : DateTime.Parse(item["parkingTime"].ToString());
                    parkingAreas.Add(c);
                }

            }
            catch (Exception ex)
            {
            }
        }
        public static void printLog(string v) //기록을 남기는 용도
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
            try
            {
                myDB.updateQuery(parkingArea, isRemove);
            }
            catch (Exception ex)
            {
                printLog("Save" + isRemove + ex.StackTrace);
            }
        }
        //주차공간을 추가/삭제하는 Save
        public bool Save(string cmd, int parkingSpot, out string contents)
        {
            myDB.selectQuery(parkingSpot); //해당 공간이 이미 있는 지 여부 조회
            contents = "";
            if (cmd.Equals("insert"))
                return DBInsert(parkingSpot, ref contents);
            else
                return DBDelete(parkingSpot, ref contents);
        }
        private bool DBDelete(int parkingSpot, ref string contents)
        {
            if (myDB.dt.Rows.Count != 0) //공간이 있는 경우
            {
                myDB.deleteQuery(parkingSpot);
                contents = $"주차 공간 {parkingSpot} 삭제됨";
                return true;
            }
            else
            {
                contents = "해당 공간은 아직 없습니다.";
                return false;
            }
        }

        private bool DBInsert(int parkingSpot, ref string contents)
        {
            if (myDB.dt.Rows.Count == 0) //공간이 아직 없는 경우
            {
                myDB.insertQuery(parkingSpot);
                contents = $"주차 공간 {parkingSpot} 추가됨";
                return true;
            }
            else
            {
                contents = "해당 공간이 이미 존재하여서 추가할 수 없습니다.";
                return false;
            }
        }
    }
}
