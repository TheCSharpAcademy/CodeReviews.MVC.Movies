using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public interface ITVShowRepository
    {
        IEnumerable<TVShow> GetAllShows();
        TVShow GetShowById(int showId);
        void AddShow(TVShow show);
        void RemoveShowById(int showId);
        void UpdateShow(TVShow show);
        void Save();
    }
}