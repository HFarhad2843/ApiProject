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
            return (IEnumerable<Genre>)await genreRepository.GetAllAsync();
        }
     

        public async Task <Genre> CreateAsync(Genre genre)
        {
            if (genreRepository.Table.Any(x=>x.Name==genre.Name))
            {
                throw new Exception("Name already exist!");
            }

            await genreRepository.InsertAsync(genre);
            await genreRepository.CommitAsync();
            return genre;
        }

        Task IGenreService.CreateAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
