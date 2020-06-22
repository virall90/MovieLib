using System.Collections.Generic;

namespace MovieLib.BL.Common.Response
{
    /// <summary>
    /// Стандартный ответ при ошибке
    /// </summary>
    public class ErrorListResponse
    {
        public ErrorListResponse(List<string> errors)
        {
            Errors = errors;
        }
        public ErrorListResponse(string error)
        {
            Errors = new List<string> { error };
        }

        /// <summary> Список ошибок </summary>
        public List<string> Errors { get; }
    }
}