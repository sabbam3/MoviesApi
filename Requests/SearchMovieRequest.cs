namespace MoviesApi.Requests
{
    public class SearchMovieRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}
