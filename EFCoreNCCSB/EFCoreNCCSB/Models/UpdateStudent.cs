namespace EFCoreNCCSB.Models
{
    public class UpdateStudent
    {
        public Guid Id { get; set; } //creates auto id
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Faculty { get; set; }
        public string Fee { get; set; }
    }
}
