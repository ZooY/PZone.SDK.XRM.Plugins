// ReSharper disable UnusedMember.Global


using System;
using Microsoft.Xrm.Sdk;


namespace PZone.Xrm.Plugins
{
    /// <summary>
    /// Расширение стандартного функционала классов, реализующих интерфейс <see cref="IServiceProvider"/>.
    /// </summary>
    // ReSharper disable once CheckNamespace
    // ReSharper disable once InconsistentNaming
    public static class IServiceProviderExtensions
    {
        /// <summary>
        /// Получение контекста плагина.
        /// </summary>
        /// <param name="serviceProvider">Экземпляр класса <see cref="IServiceProvider"/>.</param>
        /// <returns>
        /// Метод возвращает объект, представляющий собой контекст выполнени¤ плагина.
        /// </returns>
        /// <example>
        /// <code>
        /// public void Execute(IServiceProvider serviceProvider)
        /// {
        ///     ...
        ///     var context = serviceProvider.GetContext();
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static IPluginExecutionContext GetContext(this IServiceProvider serviceProvider)
        {
            return (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        }


        /// <summary>
        /// Получение экземпляра CRM-сервиса.
        /// </summary>
        /// <param name="serviceProvider">Экземпляр класса <see cref="IServiceProvider"/>.</param>
        /// <param name="userId">
        /// <para>Идентификатор пользователя, от имени которого будет выполняться сервис.</para>
        /// <para>Идентификатор можно взять из контекста плагина (см. <see cref="IPluginExecutionContext"/>).
        /// Свойство <see cref="IExecutionContext.InitiatingUserId"/> контекста позволяет получить идентификатор
        /// пользователя, инициировавщего запуск плагина, а свойство <see cref="IExecutionContext.UserId"/> -
        /// идентификатор пользователя, указанный в настройках плагина при регистрации.</para>
        /// </param>
        /// <para>
        /// Если значение параметра навно <c>null</c> - будет использован системный пользователь (SYSTEM).
        /// </para>
        /// <para>
        /// Если значение параметра навно <see cref="Guid.Empty"/> - будет использован пользователь из
        /// свойства <see cref="IExecutionContext.UserId"/>.
        /// </para>
        /// <returns>
        /// Метод возвращает ссылку на экземпляр CRM-сервиса, который будет работать от имени указанного пользователя.
        /// </returns>
        /// <example>
        /// <code>
        /// public void Execute(IServiceProvider serviceProvider)
        /// {
        ///     ...
        ///     var context = serviceProvider.GetContext();
        ///     var service = serviceProvider.GetService(context.UserId);
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static IOrganizationService GetOrganizationService(this IServiceProvider serviceProvider, Guid? userId)
        {
            var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            return factory.CreateOrganizationService(userId);
        }


        /// <summary>
        /// Получение экземпляра сервиса трассировки.
        /// </summary>
        /// <param name="serviceProvider">Экземпляр класса <see cref="IServiceProvider"/>.</param>
        /// <returns>
        /// Метод возвращает ссылку на экземпляр сервиса трассировки.
        /// </returns>
        /// <example>
        /// <code>
        /// public void Execute(IServiceProvider serviceProvider)
        /// {
        ///     ...
        ///     var tracingService = serviceProvider.GetTracingService();
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static ITracingService GetTracingService(this IServiceProvider serviceProvider)
        {
            return (ITracingService)serviceProvider.GetService(typeof(ITracingService));
        }
    }
}
