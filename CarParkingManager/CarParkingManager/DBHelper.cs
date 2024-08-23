using MySql.Data.MySqlClient;
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
    public abstract class DBHelper
    {
        protected DbConnection conn;
        protected DbDataAdapter da;
        protected DataSet ds;
        public DataTable dt;
        protected abstract DbCommand getSqlCommand();
        protected abstract string TABLENAME { get; }
        protected abstract void connectDB(); //DBHelper 안에서만 사용할 메서드
        public abstract void selectQuery(int parkingSpot = -1);
        public abstract void updateQuery(ParkingCar parkingCar, bool isRemove);
        protected abstract void executeQuery(int parkingSpot, string cmd);
        public abstract void deleteQuery(int parkingSpot);
        public abstract void insertQuery(int parkingSpot);

    }
}
