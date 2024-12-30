namespace EFCoreNCCSB.Models
{
    //Entity framework is used to perform database operation in asp.net core.
    //it uses object relational mapper (ORM) means that all the database operation
    //like create, insert, update and delete are done by creating classes and
    //object. To use EF core two packages are required: EntityFrameworkCore.SqlServer
    //and Entitty.FrameworkCore.Tools

    ///Tools -> nuget -> manage (to download)

    public class Student
    {
        //this class is used to create necessary parameter for creating
        //table and its column i.e. properties of the class will be used
        //to create column of database table    
        public Guid Id {  get; set; } //creates auto id
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Faculty { get; set; }
        public string Fee { get; set; }
    }
}
