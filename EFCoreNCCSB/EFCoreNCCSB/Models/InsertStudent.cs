namespace EFCoreNCCSB.Models
{
    //comes from form and returns data
    public class InsertStudent
    {
        public Guid Id { get; set; } //creates auto id
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Faculty { get; set; }
        public string Fee { get; set; }
    }
}
