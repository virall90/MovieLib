namespace MovieLib.BL.Common.Interfaces
{
    /// <summary> Интерфейс описывающий содержащий сообщения для пользоователя класс </summary>
    public interface IHasUserMessage
    {
        /// <summary> Сообщение для пользователя </summary>
        public string UserMessage { get; }
    }
}
