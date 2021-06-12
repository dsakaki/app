using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class dbConnection
    {
        static Boolean _Status;


        public static Boolean Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        string _strCon;
        SqlConnection _con;
        DataSet _dset;
       

        public string StrCon
        {
            get { return _strCon; }
            set { _strCon = value; }
        }

        public SqlConnection Con
        {
            get { return _con; }
            set { _con = value; }
        }

        public DataSet Dset
        {
            get { return _dset; }
            set { _dset = value; }
        }

        public dbConnection()
        {

            StrCon = @"Data Source=DESKTOP-0PULT84\SQLEXPRESS;Initial Catalog=db_qlcf;Persist Security Info=True;User ID=sa;Password=sa2012";
            Con = new SqlConnection(StrCon);
        }

        public dbConnection(string dataSetName)
        {
            StrCon = @"Data Source=DESKTOP-0PULT84\SQLEXPRESS;Initial Catalog=db_qlcf;Persist Security Info=True;User ID=sa;Password=sa2012";
            Con = new SqlConnection(StrCon);
            Dset = new DataSet(dataSetName);

        }

        public dbConnection(string str, string dataSetName)
        {
            StrCon = str;
            Con = new SqlConnection(StrCon);
            Dset = new DataSet(dataSetName);
        }


        public void openConnection()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            else
                return;
        }

        public void closeConnection()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }

        public void disPose()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            Con.Dispose();
        }

        public void sqlExcuteNonQuery(string command)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(command, Con);
            cmd.ExecuteNonQuery();
            closeConnection();
        }



        public Decimal sqlExecuteScalar(string command)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(command, Con);
            var i = cmd.ExecuteScalar();
            closeConnection();
            if( i.ToString().Length > 0)
                return Decimal.Parse(i.ToString());
            return 0;
        }

  
        public void login(string tk, string mk)
        {
            string command = @"SELECT username FROM login WHERE username='" + tk + "' and psswd='" + mk + "'";


            openConnection();
            SqlDataAdapter ada = new SqlDataAdapter(command, Con);
            ada.Fill(Dset, "login");
            closeConnection();


        }



    }
}
