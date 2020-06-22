using FluentValidation;

namespace MovieLib.BL.Movies.AddEditMovie
{
    
    /// <summary> Валидатор для команды добавления или редактирования фильма </summary>
    public class AddEditMovieCommandValidator : AbstractValidator<AddEditMovieCommand>
    {
        public const string NameEmptyMessage = "Название фильма обязательно";
        public const string ReleaseYearEmptyMessage = "Год выпуска обязателен";

        public AddEditMovieCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(NameEmptyMessage);
            RuleFor(x => x.ReleaseYear).NotNull().WithMessage(ReleaseYearEmptyMessage);
        }
    }
}