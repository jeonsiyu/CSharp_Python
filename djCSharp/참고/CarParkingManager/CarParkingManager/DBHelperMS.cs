using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingManager
{
    public class DBHelperMS : DBHelper
    {
        private DBHelperMS()
        {
            conn = new SqlConnection();
        }
        private static DBHelperMS instance;
        public static DBHelperMS getInstance
        {
            get
            {
                if (instance == null)
                    instance = new DBHelperMS();
                return instance;
            }
        }
        protected override string TABLENAME => " parkingCar ";
        protected override void connectDB()
        {
            string dataSource = "local";
            string db = "ParkingDB";
            string security = "SSPI";

            conn.ConnectionString = $"Data Source=({dataSource}); " +
                $"initial Catalog={db}; " +
                $"integrated Security = {security};" +
                $"Timeout=3";
            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();

        }
        public override void selectQuery(int parkingSpot = -1)
        {
            try
            {
                connectDB();
                SqlCommand cmd = getSqlCommand() as SqlCommand;
                if (parkingSpot == -1) //전체조회
                    cmd.CommandText = "select * from " + TABLENAME;
                else //부분조회, 해당 구역에 이미 차가 있는 지 여부 등 체크
                    cmd.CommandText = "select * from " + TABLENAME + " where parkingSpot=" + parkingSpot;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, TABLENAME);
                dt = ds.Tables[0]; //select 결과물 저장된 테이블 하나를 가져올 것
            }
            catch (Exception ex)
            {
                DataManager.printLog("select" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        public override void updateQuery(ParkingCar parkingCar, bool isRemove)
        {
            try
            {
                connectDB();
                SqlCommand cmd = getSqlCommand() as SqlCommand;
                cmd.Connection = conn as SqlConnection;
                string sqlcommand = "";
                if (isRemove) //출차
                {
                    sqlcommand =
                        "update " + TABLENAME + " set carnumber=''," +
                        "drivername='',phonenumber='',parkingtime=null where " +
                        "parkingspot=@p1";
                    //java의 preparestatement방식처럼 sql injection 방지하는 방식
                    cmd.Parameters.AddWithValue("@p1", parkingCar.parkingSpot);
                }
                else //주차
                {
                    sqlcommand =
                        "update " + TABLENAME + " set carnumber=@p1," +
                        "drivername=@p2,phonenumber=@p3, parkingtime=@p4 where " +
                        "parkingspot=@p5";
                    cmd.Parameters.AddWithValue("@p1", parkingCar.carNumber);
                    cmd.Parameters.AddWithValue("@p2", parkingCar.driverName);
                    cmd.Parameters.AddWithValue("@p3", parkingCar.phoneNumber);
                    cmd.Parameters.AddWithValue("@p4", parkingCar.parkingTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    cmd.Parameters.AddWithValue("@p5", parkingCar.parkingSpot);
                    //cmd.Parameters.AddWithValue("@p4", DateTime.Now.ToString
                    //    ("yyyy-MM-dd HH:mm:ss.fff"));

                }

                cmd.CommandText = sqlcommand;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataManager.printLog("update" + ex.StackTrace);
            }
            finally
            {
                conn.Close();

            }


        }


        protected override void executeQuery(int parkingSpot, string cmd)
        {
            string sqlcmd = "";
            if (cmd.Equals("insert"))
                sqlcmd = "insert into " + TABLENAME + "(parkingspot) values (@p1)";
            else
                sqlcmd = "delete from " + TABLENAME + " where parkingspot=@p1";
            try
            {
                connectDB();
                SqlCommand command = getSqlCommand() as SqlCommand;
                //command.Connection = conn;
                command.Parameters.AddWithValue("@p1", parkingSpot);
                command.CommandText = sqlcmd;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataManager.printLog(cmd + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }


        public override void deleteQuery(int parkingSpot)
        {
            executeQuery(parkingSpot, "delete");

        }

        public override void insertQuery(int parkingSpot)
        {
            executeQuery(parkingSpot, "insert");
        }







        protected override DbCommand getSqlCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn as SqlConnection;
            return cmd;
        }
    }
}
