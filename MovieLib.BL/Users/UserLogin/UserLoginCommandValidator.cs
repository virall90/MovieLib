using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace MovieLib.BL.Users.UserLogin
{
    /// <summary> Валидатор для команды логина пользователя </summary>
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public const string PasswordEmptyMessage = "Пароль обязателен";
        public const string EmailEmptyMessage = "Email обязателен";
        public const string EmailIncorrectMessage = "Некорректно указан Email";
        public UserLoginCommandValidator()
        {
            RuleFor(x => x.Password).NotNull()
                .WithMessage(PasswordEmptyMessage);

            RuleFor(x => x.Email).NotNull().NotEmpty()
                .WithMessage(EmailEmptyMessage);

            RuleFor(x => x.Email).Must(x => new EmailAddressAttribute().IsValid(x))
                .WithMessage(EmailIncorrectMessage);
        }
    }
}