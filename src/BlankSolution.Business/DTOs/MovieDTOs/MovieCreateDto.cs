using BlankSolution.Core.Entities;
using FluentValidation;
using System.Globalization;

namespace BlankSolution.Business.DTOs.MovieDTOs;

public class MovieCreateDto
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostPrice { get; set; }
    public double SalePrice { get; set; }
    
}

public class MovieCreateDtoValidator: AbstractValidator<MovieCreateDto>
{
    public MovieCreateDtoValidator() 
    {
        RuleFor(x => x.Name)
            .MaximumLength(75).WithMessage("Maksimum 75 ola biler")
            .MinimumLength(1).WithMessage("Minimum 1 ola biler");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Bosh ola bilmez")
            .NotNull().WithMessage("Null ola bilmez")
            .MaximumLength(575).WithMessage("Maksimum 575 ola biler")
            .MinimumLength(20).WithMessage("Minimum 20 ola biler");

        RuleFor(x => x.CostPrice)
            .NotEmpty().WithMessage("Bosh ola bilmez")
            .NotNull().WithMessage("Null ola bilez");

        RuleFor(x => x.SalePrice)
            .NotEmpty().WithMessage("Bosh ola bilmez")
            .NotNull().WithMessage("Null ola bilmez");

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.SalePrice < x.CostPrice)
            {
                context.AddFailure(nameof(x.SalePrice), "SalePrice CostPrice-dan boyuk olmalidir");
            }
        });
            
            
    }
}
