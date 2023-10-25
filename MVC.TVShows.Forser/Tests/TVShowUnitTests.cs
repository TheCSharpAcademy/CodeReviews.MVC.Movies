using MVC.TVShows.Forser.Models;
using MVC.TVShows.Forser.Repositories;
using Telerik.JustMock;

namespace MVC.TVShows.Forser.Tests
{
    public class TVShowUnitTests
    {
        [Fact]
        public void GetAllGenres_ShouldReturnIEnumerable()
        {
            // Arrange
            var _unitOfWork = Mock.Create<IUnitOfWork>();

            // Act
            var actualResult = _unitOfWork.Genres.GetAll();

            // Assert
            Assert.IsAssignableFrom<Task<IEnumerable<Genre>>>(actualResult);
        }

        [Fact]
        public void GetOneGenre_ShouldReturnTaskGenre()
        {
            // Arrange
            var _unitOfWork = Mock.Create<IUnitOfWork>();

            // Act
            var result = _unitOfWork.Genres.GetById(1);

            // Assert
            Assert.IsAssignableFrom<Task<Genre>>(result);
        }
    }
}