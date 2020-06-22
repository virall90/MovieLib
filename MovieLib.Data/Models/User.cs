using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MovieLib.Data.Models
{
    /// <summary> Пользователь </summary>
    public class User : IdentityUser
    {
        /// <summary> Список информации о фильмах созданных пользователем </summary>
        public virtual List<Movie> Movies { get; set; }
        /// <summary> Список токенов пользователя для доступа к API </summary>
        public virtual List<UserApiToken> ApiTokens { get; set; }
    }
}