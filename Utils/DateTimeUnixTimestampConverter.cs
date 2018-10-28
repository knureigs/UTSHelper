using System;

namespace UTSHelper
{
    /// <summary>
    /// Класс для работы с датой и временем в формате UnixTimestamp.
    /// </summary>
    public static class DateTimeUnixTimestampConverter
    {
        /// <summary>
        /// Начало "эпохи Unix" - эта дата используется при преобразованиях с UnixTimestamp.
        /// </summary>
        /// <remarks>Для получения даты и времени в обычном формате эта дата прибавляется
        /// к числу секунд, составляющему дату в UnixTimestamp-формате
        /// Для получения даты и времени в UnixTimestamp-формате, из обычной даты вычитается 
        /// данное значение и берется количество секунд.</remarks>
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Сдвиг для Украины, для коррекции преобразования из-за часовых поясов (на 3 от нулевого).
        /// </summary>
        private static readonly TimeSpan Offset = new TimeSpan(3, 0, 0);

        /// <summary>
        /// Метод расширения для преобразования DateTime в UnixTimestamp.
        /// </summary>
        /// <param name="value">Преобразуемое значение даты и времени.</param>
        /// <returns>DateTime в UnixTimestamp-формате.</returns>
        public static int ToUnixTimestamp(this DateTime value)
        {
            return (int)Math.Truncate((value.ToUniversalTime().Subtract((new DateTime(1970, 1, 1)).Add(Offset))).TotalSeconds);
        }

        /*
        /// <summary>
        /// Метод расширения для преобразования UnixTimestamp в DateTime.
        /// </summary>
        /// <param name="seconds">Число секунд после 1970-го - дата и время в UnixTimestamp-формате.</param>
        /// <returns>DateTime в обычном формате.</returns>
        /// <remarks>Сильно сомневаюсь, что стоит расширять базовый тип.</remarks>
        public static DateTime FromUnixTimestamp(this long seconds)
        {
            return UnixEpoch.AddSeconds(seconds).Add(Offset);
        }
        */

        /// <summary>
        /// Преобразование UnixTimestamp в DateTime.
        /// </summary>
        /// <param name="seconds">Число секунд после 1970-го - дата и время в UnixTimestamp-формате.</param>
        /// <returns>DateTime в обычном формате.</returns>
        public static DateTime FromUnixTimestamp(this long seconds)
        {
            return UnixEpoch.AddSeconds(seconds).Add(Offset);
        }

        /// <summary>
        /// Преобразование UnixTimestamp в DateTime.
        /// </summary>
        /// <param name="seconds">Число секунд после 1970-го - дата и время в UnixTimestamp-формате.</param>
        /// <returns>DateTime в обычном формате.</returns>
        public static DateTime FromUnixTimestamp(int seconds)
        {
            return UnixEpoch.AddSeconds(seconds).Add(Offset);
        }
    }
}
