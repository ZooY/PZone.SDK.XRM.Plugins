﻿// ReSharper disable UnusedMember.Global


namespace PZone.Xrm.Plugins
{
    /// <summary>
    /// Событие подключаемого модуля.
    /// </summary>
    public enum Message
    {
        /// <summary>
        /// Все остальные события кроме определнных явно в этом перечислении.
        /// </summary>
        Unknown,


        /// <summary>
        /// Создание записи.
        /// </summary>
        Create,


        /// <summary>
        /// Обновление записи.
        /// </summary>
        Update,


        /// <summary>
        /// Удаление записи.
        /// </summary>
        Delete,


        /// <summary>
        /// Получение одной записи.
        /// </summary>
        Retrieve,


        /// <summary>
        /// Получение набора записей.
        /// </summary>
        RetrieveMultiple,


        /// <summary>
        /// Установка статуса записи.
        /// </summary>
        SetState,


        /// <summary>
        /// Событие ассоциирования записей - установки связи М:М.
        /// </summary>
        Associate,


        /// <summary>
        /// Событие деассоциирования записей - удаление связи М:М.
        /// </summary>
        Disassociate,


        /// <summary>
        /// Выигрыш возможной сделки.
        /// </summary>
        Win,


        /// <summary>
        /// Потеря возможной сделки.
        /// </summary>
        Lose
    }
}