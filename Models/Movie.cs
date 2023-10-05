namespace MoviesApi.Models
{
    public enum Status
    {
        Active,
        Deleted
    }
    public class Movie
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }    
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }  
    }
}
