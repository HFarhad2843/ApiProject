using BlankSolution.Business.Services.Interfaces;
using BlankSolution.Core.Entities;
using BlankSolution.Core.Repositories;

namespace BlankSolution.Business.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await genreRepository.GetAllAsync();
        }
        public async Task <Genre> CreateAsync (Genre Genre)
        {
            await genreRepository.InsertAsync(Genre);
            await genreRepository.CommitAsync();
            return Genre;
        }

        Task<IEnumerable<Genre>> IGenreService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task IGenreService.CreateAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
