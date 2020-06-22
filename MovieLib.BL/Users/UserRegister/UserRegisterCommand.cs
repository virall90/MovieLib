#nullable enable
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Users.UserRegister
{
    /// <summary> Команда регистрации пользователя </summary>
    public class UserRegisterCommand : ICommand<UserRegisterResponse>, IMapTo<User>
    {
        /// <summary> Имя </summary>
        public string? UserName { get; set; }

        /// <summary> Почта </summary>
        public string? Email { get; set; }

        /// <summary> Пароль </summary>
        public string? Password { get; set; }
    }
}