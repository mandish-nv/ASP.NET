using Microsoft.EntityFrameworkCore;

namespace EFCoreNCCSB.Models
{
    //this class is responsible for creating object of server
    //and setting the column the table by using properties
    //model Student class
    public class StudentContext :DbContext
    {
        //creating object of server by using constructor
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        //creating table and setting column of table
        public DbSet <Student> Students {  get; set; }
                                //table name
    }
}
