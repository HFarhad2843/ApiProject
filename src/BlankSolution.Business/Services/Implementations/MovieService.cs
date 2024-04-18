using BlankSolution.Business.CustomExceptions.CommonExceptions;
using BlankSolution.Business.DTOs.MovieDTOs;
using BlankSolution.Business.Services.Interfaces;
using BlankSolution.Core.Entities;
using BlankSolution.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlankSolution.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IGenreRepository genreRepository;
        public MovieService(
               IMovieRepository movieRepository, 
               IGenreRepository genreRepository)
        {
            movieRepository = movieRepository;
            genreRepository = genreRepository;

        }
        public async Task CreateAsync(MovieCreateDto dto)
        {
            if (!await genreRepository.Table.AnyAsync(x => x.id == dto.GenreId))
             throw new NotFoundException ("Genre not found");

            Movie movie = new Movie()
            {
                Name = dto.Name,
                Description = dto.Description,
                CostPrice = dto.CostPrice,
                SalePrice = dto.SalePrice,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                GenreId = dto.GenreId,
            };
            await movieRepository.InsertAsync(movie);
            await movieRepository.CommitAsync();    
           
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
