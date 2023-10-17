namespace MoviesApi.Requests
{
    public class UpdateMovieRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}
