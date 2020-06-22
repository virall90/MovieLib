#nullable enable
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Users.UserGetInfo
{
    /// <summary> Команда для получения информации о клиенте </summary>
    public class UserGetInfoQuery : IQuery<UserGetInfoResponse>
    {
        /// <summary> Токен </summary>
        public string? Token { get; set; }
    }
}