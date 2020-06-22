namespace MovieLib.Data.Models
{
    /// <summary> Модель информации о фильме </summary>
    public class Movie
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }
        /// <summary> Название </summary>
        public string Name { get; set; }
        /// <summary> Описание </summary>
        public string Description { get; set; }
        /// <summary> Год выпуска </summary>
        public int ReleaseYear { get; set; }
        /// <summary> Режиссёр </summary>
        public string Director { get; set; }
        /// <summary> Идентификатор пользователя создавшего информацию о фильме </summary>
        public string CreatedByUserId { get; set; }
        /// <summary> Название файла постера фильма </summary>
        public bool HavePoster { get; set; }
        
        /// <summary> Идентификатор </summary>
        public virtual User CreatedByUser { get; set; }
    }
}