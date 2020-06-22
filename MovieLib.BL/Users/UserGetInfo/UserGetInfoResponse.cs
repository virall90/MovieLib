using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Users.UserGetInfo
{
    /// <summary> Ответ на команду получения информации о клиенте </summary>
    public class UserGetInfoResponse : IMapFrom<User>
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }

        /// <summary> Почта </summary>
        public string Email { get; set; }

        /// <summary> Имя пользователя </summary>
        public string UserName { get; set; }
    }
}