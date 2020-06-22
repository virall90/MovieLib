using System;
using MovieLib.Data.Common.Specification.Core;

namespace MovieLib.Data.Models
{
    /// <summary> Токен для доступа к API пользователя </summary>
    public class UserApiToken
    {
        /// <summary> Идентификатор пользователя </summary>
        public string UserId { get; set; }

        /// <summary> Строка токена </summary>
        public string ApiToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary> Время и дата истечения токена </summary>
        public DateTime? ExpirationDateTime { get; set; }

        /// <summary> Пользователь </summary>
        public virtual User User { get; set; }

        /// <summary> Спецификация: Токен истек </summary>
        public static readonly Spec<UserApiToken> IsExpired = new Spec<UserApiToken>(token =>
            token.ExpirationDateTime != null && token.ExpirationDateTime <= DateTime.Now);
    }
}