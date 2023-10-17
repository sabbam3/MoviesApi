using MoviesApi.Requests;
using System.Runtime.InteropServices;

namespace MoviesApi
{
    public class ValidateRequests
    {
        public void ValidateCreateRequest(CreateMovieRequest? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            if (string.IsNullOrEmpty(request.Description))
            {
                throw new ArgumentNullException(nameof(request.Description));
            }
            if (request.ReleaseYear < 1895)
            {
                throw new ArgumentException("Release year must be at least 1895");
            }
            if (string.IsNullOrEmpty(request.Director))
            {
                throw new ArgumentNullException(nameof(request.Director));
            }
        }
        public void ValidateUpdateRequest(UpdateMovieRequest? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            if (string.IsNullOrEmpty(request.Description))
            {
                throw new ArgumentNullException(nameof(request.Description));
            }
            if (request.ReleaseYear < 1895)
            {
                throw new ArgumentException("Release year must be at least 1895");
            }
            if (string.IsNullOrEmpty(request.Director))
            {
                throw new ArgumentNullException(nameof(request.Director));
            }
        }
        public void ValidateSearchMovieRequest(SearchMovieRequest request)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request));
            }
            if(string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Director))
            {
                throw new ArgumentNullException("Name or Director should be filled");
            }
        }
    }
}
