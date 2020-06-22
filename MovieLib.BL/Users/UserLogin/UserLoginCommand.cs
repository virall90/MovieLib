#nullable enable
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Users.UserLogin
{
    /// <summary> Команда для логина пользователя </summary>
    public class UserLoginCommand : ICommand<UserLoginResponse>
    {
        /// <summary> Почта пользователя </summary>
        public string? Email { get; set; }

        /// <summary> Почта пользователя </summary>
        public string? Password { get; set; }

        /// <summary> Оставаться ли в системе </summary>
        public bool RememberMe { get; set; }
    }
}