// ReSharper disable UnusedMember.Global


using Microsoft.Xrm.Sdk;


namespace PZone.Xrm.Plugins
{
    /// <summary>
    /// Расширение стандартного функционала класса <see cref="IPluginExecutionContext"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IPluginExecutionContextExtensions
    {
        /// <summary>
        /// Название снимка состояния по умолчанию.
        /// </summary>
        public const string DEFAULT_IMAGE_NAME = "Image";


        /// <summary> 
        /// Получение сущности из контекста подключаемого модуля.
        /// </summary>
        /// <param name="context">Контекст подключаемого модуля.</param>
        /// <exception cref="System.Exception">
        /// Сущность не доступна в контексте данного события.
        /// </exception>
        /// <returns>
        /// Метод возвращает сущность из контекста плагина (если событие предусматривает передачу сущности).
        /// </returns>
        /// <remarks>
        /// Сущность в контекст передается, например, при событиях <see cref="Microsoft.Xrm.Sdk.Messages.CreateRequest"/>,
        /// <see cref="Microsoft.Xrm.Sdk.Messages.UpdateRequest"/> и др.
        /// </remarks>
        /// <example>
        /// <code>
        /// public class MyPlugin : IPlugin
        /// {
        ///     public void Execute(IServiceProvider serviceProvider)
        ///     {
        ///         ...
        ///         var context = serviceProvider.GetContext();
        ///         var entity = context.GetContextEntity();
        ///         ...
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="IServiceProviderExtensions"/>
        public static Entity GetContextEntity(this IPluginExecutionContext context)
        {
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                return (Entity)context.InputParameters["Target"];
            var stageName = ((Stage)context.Stage).GetDisplayName();
            var message = $"Entity is not accessible in a context of {stageName} {context.MessageName} event.";
            throw new InvalidPluginExecutionException(message);
        }


        /// <summary>    
        /// Получение ссылки на сущность из контекста плагина.
        /// </summary>
        /// <param name="context">Контекст плагина.</param>
        /// <exception cref="System.Exception">
        /// Ссылка на сущность не доступна в контексте данного события.
        /// </exception>
        /// <returns>
        /// Метод возвращает ссылку на сущность из контекста плагина, если событие предусматривает передачу ссылки.
        /// </returns>
        /// <remarks>
        /// Ссылки передаются, например, при событиях <see cref="Microsoft.Xrm.Sdk.Messages.DeleteRequest"/>, 
        /// <see cref="Microsoft.Xrm.Sdk.Messages.AssociateRequest"/>, <see cref="Microsoft.Xrm.Sdk.Messages.DisassociateRequest"/> и др.
        /// </remarks>
        /// <example>
        /// <code>
        /// public class MyPlugin : IPlugin
        /// {
        ///     public void Execute(IServiceProvider serviceProvider)
        ///     {
        ///         ...
        ///         var context = serviceProvider.GetContext();
        ///         var entityRef = context.GetContextEntityReference();
        ///         ...
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="IServiceProviderExtensions"/>
        public static EntityReference GetContextEntityReference(this IPluginExecutionContext context)
        {
            // Delete message
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is EntityReference)
                return (EntityReference)context.InputParameters["Target"];
            // QualifyLead message
            if (context.InputParameters.Contains("LeadId") && context.InputParameters["LeadId"] is EntityReference)
                return (EntityReference)context.InputParameters["LeadId"];
            // SetStateDynamicEntity message
            if (context.InputParameters.Contains("EntityMoniker") && context.InputParameters["EntityMoniker"] is EntityReference)
                return (EntityReference)context.InputParameters["EntityMoniker"];
            // Opportunity Win message
            if (context.InputParameters.Contains("OpportunityClose") && context.InputParameters["OpportunityClose"] is Entity)
                return ((Entity)context.InputParameters["OpportunityClose"]).GetAttributeValue<EntityReference>("opportunityid");

            var stageName = ((Stage)context.Stage).GetDisplayName();
            var message = $"EntityReference is not accessible in a context of {stageName} {context.MessageName} event.";
            throw new InvalidPluginExecutionException(message);
        }
        

        /// <summary>
        /// Получение Pre Image сущности с именем по умолчанию.
        /// </summary>
        /// <param name="context">Контекст плагина.</param>
        /// <returns>Метод возвращает Pre Image сущности с именем по умолчанию. Имя по умолчанию - "Image".</returns>
        /// <exception cref="System.Exception">В шаге плагина не определен Image с именем по умолчанию.</exception>
        public static Entity GetDefaultPreEntityImage(this IPluginExecutionContext context)
        {
            if (context.PreEntityImages.ContainsKey(DEFAULT_IMAGE_NAME))
                return context.PreEntityImages[DEFAULT_IMAGE_NAME];
            throw ImageNotDefinedException(context);
        }


        /// <summary>
        /// Получение Post Image сущности с именем по умолчанию.
        /// </summary>
        /// <param name="context">Контекст плагина.</param>
        /// <returns>Метод возвращает Post Image сущности с именем по умолчанию. Имя по умолчанию - "Image".</returns>
        /// <exception cref="System.Exception">В шаге плагина не определен Image с именем по умолчанию.</exception>
        public static Entity GetDefaultPostEntityImage(this IPluginExecutionContext context)
        {
            if (context.PostEntityImages.ContainsKey(DEFAULT_IMAGE_NAME))
                return context.PostEntityImages[DEFAULT_IMAGE_NAME];
            throw ImageNotDefinedException(context);
        }


        private static InvalidPluginExecutionException ImageNotDefinedException(IPluginExecutionContext context)
        {
            var entityName = context.PrimaryEntityName;
            var stageName = ((Stage)context.Stage).GetDisplayName();
            var message = $@"For entity {entityName} on stage {stageName} is not defined Image named ""{DEFAULT_IMAGE_NAME}"".";
            return new InvalidPluginExecutionException(message);
        }
    }
}