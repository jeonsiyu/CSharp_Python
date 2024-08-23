using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DBHelper
    {
        const string ORADB = "Data Source=(DESCRIPTION=(ADDRESS_LIST=" +
                  "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));" +
                  "User Id=test;Password=1234;";
        public static OracleConnection OraConn = new OracleConnection(ORADB); //오라클 연결 정보 생성


        const string TABLE = "simple_manager";

        static void ConnectDB()  //참고로 앞에 아무것도 안 붙이면 private이 붙은 거랑 똑같다.
        {
            try
            {
                OraConn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("DB 연결 에러 " + ex.Message + "에러 위치 " + Environment.NewLine + ex.StackTrace);
            }
        }

        //select문으로 테이블 조회하기
        public static bool selectQuery(string managerCode, string managerId, string managerPw, ref string managerName)
        {
            ConnectDB();
            try
            {

                string sql;
                //sql = $"select * from {TABLE} where manager_code={managerCode}";
                sql = $"select * from {TABLE} where manager_code=:manager_code and manager_id=:manager_id and manager_pw=:manager_pw";// :뒤에가 매개변수

                OracleDataAdapter oda = new OracleDataAdapter(); // DB에서 데이터를 가져오고, 데이터 작업을 관리하는데 사용
                oda.SelectCommand = new OracleCommand(); // oda.SelectCommand는 데이터베이스에서 데이터를 선택하는 데 사용되는 OracleCommand 객체를 나타냄
                oda.SelectCommand.Connection = OraConn; // 데이터베이스 연결 설정
                oda.SelectCommand.CommandText = sql; //select문을 날린 거
                oda.SelectCommand.Parameters.Add(":manager_code", managerCode);
                oda.SelectCommand.Parameters.Add(":manager_id", managerId);
                oda.SelectCommand.Parameters.Add(":manager_pw", managerPw);


                DataSet ds = new DataSet(); // DB에서 가져온 데이터 테이블의 컬렉션을 담을 수 있는 메모리상의 데이터 저장소
                oda.Fill(ds, TABLE);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    managerName = ds.Tables[0].Rows[0]["manager_name"].ToString();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                OraConn.Close();
            }
        }

        // 스케줄 저장 메서드
        public void SaveSchedule(Schedule schedule)
        {
            using (OracleConnection connection = new OracleConnection(ORADB))
            {
                connection.Open();

                string query = $"INSERT INTO Schedules (SCHEDULENUM, SCHEDULETITLE, SCHEDULEDATE, StartTime, EndTime, Color, Description) VALUES (scheduleCount.nextval,:Title, TO_DATE('{schedule.Date.ToString("yyyy-MM-dd HH:mm:ss")}','YYYY-MM-DD HH24:MI:SS'), :StartTime, :EndTime, :Color, :Description)";
                if (schedule.Number > 0)
                {
                    query = $"update Schedules set SCHEDULETITLE=:Title,  StartTime=:StartTime, EndTime=:EndTime, Color=:Color, Description=:Description, scheduledate=TO_DATE('{schedule.Date.ToString("yyyy-MM-dd HH:mm:ss")}','YYYY-MM-DD HH24:MI:SS') where SCHEDULENUM={schedule.Number}";
                }


                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new OracleParameter("Title", schedule.Title));
                    //command.Parameters.Add(new OracleParameter("Date", schedule.Date));
                    command.Parameters.Add(new OracleParameter("StartTime", schedule.StartTime));
                    command.Parameters.Add(new OracleParameter("EndTime", schedule.EndTime));
                    command.Parameters.Add(new OracleParameter("Color", ColorTranslator.ToHtml(schedule.Color)));
                    command.Parameters.Add(new OracleParameter("Description", schedule.Description));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 스케줄 로드 메서드
        public List<Schedule> LoadSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();

            using (OracleConnection connection = new OracleConnection(ORADB))
            {
                connection.Open();
                string query = $"SELECT SCHEDULENUM, SCHEDULETITLE, SCHEDULEDATE, StartTime, EndTime, Color, Description FROM Schedules ORDER BY SCHEDULEDATE DESC, StartTime ASC";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var schedule = new Schedule(
                                reader["SCHEDULETITLE"].ToString(),
                                DateTime.Parse(reader["SCHEDULEDATE"].ToString()),
                                reader["StartTime"].ToString(),
                                reader["EndTime"].ToString(),
                                ColorTranslator.FromHtml(reader["Color"].ToString()),
                                reader["Description"].ToString()
                            );
                            schedule.Number = int.Parse(reader["SCHEDULENUM"].ToString());

                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return schedules;
        }
        // 데이터 삭제 메서드
        public void DeleteSchedule(int scheduleNumber)
        {
            using (OracleConnection connection = new OracleConnection(ORADB))
            {
                connection.Open();
                string query = $"DELETE FROM Schedules WHERE SCHEDULENUM = :ScheduleNumber";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("ScheduleNumber", scheduleNumber));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

