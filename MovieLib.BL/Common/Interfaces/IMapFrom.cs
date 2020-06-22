using AutoMapper;

namespace MovieLib.BL.Common.Interfaces
{
    /// <summary>
    /// Интерфейс для маппинга, описывает, что класс маппится с <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">Класс модели</typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Метод маппинга. Реализация по умолчанию создает стандартную карту
        /// </summary>
        /// <param name="profile">Профиль Mapperа</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}