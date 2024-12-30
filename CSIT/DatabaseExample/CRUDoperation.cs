using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

//software: sql server management studio

namespace DatabaseExample
{
    class CRUDoperation
    {
        public void createTable()
        {
            try
            {
                //1. create connection string
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                //server name                       database name               windows authentication
                //2. creating connection
                SqlConnection conn = new SqlConnection(cs);
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected with server");
                }
               
                conn.Open(); //connection opened
                Console.WriteLine("Connected");
                //writing sql query for creating table
                string tblQuery = "create table tbl_reg (id int primary key," +
                    "username varchar(50),password varchar(50),repassword varchar(50)," +
                    "gender varchar(50),faculty varchar(50))";
                //executing query
                SqlCommand sc = new SqlCommand(tblQuery, conn);
                sc.ExecuteNonQuery();//for create insert update and delete
                Console.WriteLine("table created");
                conn.Close();//closing connection

            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }
        }

        //inserting data into table
        public void insertData()
        {
            try
            {
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                //writing query for inserting data
                //string insQuery = "insert into tbl_reg values (1,'Mandish','abcd','abcd','Male','CSIT')";

                //inserting dynamic data (prepared statement, parameter)
                Console.WriteLine("Enter your id: ");
                string id = Console.ReadLine();
                Console.WriteLine("Enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Enter your repassword: ");
                string repassword = Console.ReadLine();
                Console.WriteLine("Enter your gender: ");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter your faculty: ");
                string faculty = Console.ReadLine();

                //writing insert query using prepared statement (parameter)
                string insQuery1 = "insert into tbl_reg values (@id, @username, @password, @repassword, @gender, @faculty)";

                SqlCommand sc = new SqlCommand(insQuery1, conn);

                //inserting values in parameter
                sc.Parameters.AddWithValue("id", id);
                sc.Parameters.AddWithValue("username", username);
                sc.Parameters.AddWithValue("password", password);
                sc.Parameters.AddWithValue("repassword", repassword);
                sc.Parameters.AddWithValue("gender", gender);
                sc.Parameters.AddWithValue("faculty", faculty);

                int res = sc.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine(res + " data inserted.");
                }
                conn.Close();

            }
            catch (Exception s)
            {
                Console.WriteLine(s);
            }
        }

        //update name to mandish, faculty to bim of person whose id is 1
        public void updateData()
        {
            try
            {
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                //query
                string upQuery = "update tbl_reg set username='mandish', faculty='bim' where id=1";

                SqlCommand sc = new SqlCommand(upQuery, conn);
                int res = sc.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine(res + " data updated.");
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //fetching data from database
        public void displayData()
        {
            try
            {
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                //fetch query
                string disQuery = "select * from tbl_reg";
                SqlCommand sc = new SqlCommand(disQuery, conn);
                //to fetch data executeReader() method is used, it returns object of
                //SqlDataReader that contains all the data of database table
                SqlDataReader row = sc.ExecuteReader();
                //it contains all the row of table. To fetch one row at a time read()
                //method is used
                Console.WriteLine("Data of database:");
                while(row.Read())
                {
                    Console.WriteLine("id is " + row["id"]);
                    Console.WriteLine("username is " + row["username"]);
                    Console.WriteLine("password is " + row["password"]);
                    Console.WriteLine("repassword is " + row["repassword"]);
                    Console.WriteLine("gender is " + row["gender"]);
                    Console.WriteLine("faculty is " + row["faculty"]);
                    Console.WriteLine("--------------------------");
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //deleting data from database
        public void deleteData()
        {
            try
            {
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                //query
                string delQuery = "delete from tbl_reg where id=@id";
                Console.WriteLine("Enter id of person of which you want to delete record: ");
                string delId = Console.ReadLine();
                SqlCommand sc = new SqlCommand(delQuery, conn);
                sc.Parameters.AddWithValue("id", delId);
                int res = sc.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine(res + " data deleted.");
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
