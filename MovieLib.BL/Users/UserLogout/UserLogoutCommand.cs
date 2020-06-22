#nullable enable
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Users.UserLogout
{
    /// <summary> Команда для логаута пользователя </summary>
    public class UserLogoutCommand : ICommand<UserLogoutResponse>
    {
        /// <summary> Токен </summary>
        public string? Token { get; set; }
    }
}