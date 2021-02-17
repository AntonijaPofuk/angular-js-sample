using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.Genres;
using AngularJsSample.Services.Messaging.Views;

namespace AngularJsSample.Services
{
    public interface IGenreService
    {
        GetGenreResponse GetGenre(GetGenreRequest request);
        GetGenresResponse GetGenres(GetGenresRequest request);
    

    }
}