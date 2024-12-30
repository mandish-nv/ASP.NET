using System;
using System.Data;
using System.Data.SqlClient;    //to connect with SQL server and for SQL language
//to connect with external database like sql server, cml file, SQLclient
//package should be imported
//Steps to connect with database:
//1. crete connection string that have all the parameters required to
//connect with database
//2. create object of SQLConnection class that accepts connection string 
//as parameter. This class is used to conect with server and database
//3. Write appropriate query
//4. create object of SQLCommand class that accepts query and connection
//object as parameter. This class is using method SQLCommand class
//5. Execute query by using method SQLCommand clas
//6. Close the connection

namespace DatabaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDoperation co = new CRUDoperation();
            //co.createTable();
            //co.insertData();
            //co.updateData();
            //co.displayData();
            co.deleteData();

            Console.ReadKey();
        }
    }
}
