using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace CarParkingManager
{
    public class DBHelperOracle : DBHelper
    {

        //NUGET에서 ORACLE 검색해서 추가함
        const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
            "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
            "User Id=c##scott;Password=tiger;";
        private DBHelperOracle()
        {
            conn = new OracleConnection();
        }
        private static DBHelperOracle instance;
        public static DBHelperOracle getInstance
        {
            get
            {
                if (instance == null)
                    instance = new DBHelperOracle();
                return instance;
            }
        }
        protected override string TABLENAME => " parkingCar ";
        protected override void connectDB()
        {
            try
            {
                conn = new OracleConnection(ORADB);
                conn.Open();
            }
            catch (Exception e)
            {
            }

        }
        public override void selectQuery(int parkingSpot = -1)
        {
            try
            {
                connectDB();
                OracleCommand cmd = getSqlCommand() as OracleCommand;
                if (parkingSpot == -1) //전체조회
                    cmd.CommandText = "select * from " + TABLENAME;
                else //부분조회, 해당 구역에 이미 차가 있는 지 여부 등 체크
                    cmd.CommandText = "select * from " + TABLENAME + " where parkingSpot=" + parkingSpot;
                da = new OracleDataAdapter(cmd);
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
                OracleCommand cmd = getSqlCommand() as OracleCommand;
                string sqlcommand = "";
                if (isRemove) //출차
                {
                    sqlcommand =
                        "update " + TABLENAME + " set carnumber=''," +
                        "drivername='',phonenumber='',parkingtime=null where " +
                        "parkingspot=:p1";
                    //java의 preparestatement방식처럼 sql injection 방지하는 방식
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p1", parkingCar.parkingSpot);
                }
                else //주차
                {
                    sqlcommand =
                        "update " + TABLENAME + " set carnumber=:p1," +
                        "drivername=:p2,phonenumber=:p3, " +
                        $"parkingtime=TO_DATE('{parkingCar.parkingTime.ToString("yyyy-MM-dd HH:mm:ss")}', 'YYYY-MM-DD HH24:MI:SS') " +
                        " where parkingspot=:p5";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p1", parkingCar.carNumber);
                    cmd.Parameters.Add("p2", parkingCar.driverName);
                    cmd.Parameters.Add("p3", parkingCar.phoneNumber);
                    cmd.Parameters.Add("p5", parkingCar.parkingSpot);

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
                sqlcmd = "insert into " + TABLENAME + "(parkingspot) values (:parkingSpot)";
            else
                sqlcmd = "delete from " + TABLENAME + " where parkingspot=:parkingSpot";
            try
            {
                connectDB();
                OracleCommand command = getSqlCommand() as OracleCommand;
                //command.Connection = conn;
                command.Parameters.Add(new OracleParameter("parkingSpot", parkingSpot));
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
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            return cmd;
        }
    }
}
