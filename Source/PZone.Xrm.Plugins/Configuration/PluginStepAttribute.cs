using System;


namespace PZone.Xrm.Plugins.Configuration
{
    /// <summary>
    /// Plug-in Step.
    /// </summary>
    public class PluginStepAttribute : Attribute
    {
        /// <summary>
        /// Event Message.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Primary Entity.
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// Secondary Entity.
        /// </summary>
        public string SecondaryEntity { get; set; }

        /// <summary>
        /// Filtering Attributes.
        /// </summary>
        public string[] FilteringAttributes { get; set; }

        /// <summary>
        /// Step Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Execution Order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Eventing Pipeline Stage of Execution.
        /// </summary>
        public Stage Stage { get; set; }

        /// <summary>
        /// Execution Mode.
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        /// Step Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Unsecure Configuration.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Secure Configuration.
        /// </summary>
        public string SecureConfiguration { get; set; }

        /// <summary>
        /// Step Images.
        /// </summary>
        public PluginImage[] Images { get; set; }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public PluginStepAttribute()
        {
            Stage = Stage.PostOperation;
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Event Message.</param>
        /// <param name="entity">Primary Entity.</param>
        public PluginStepAttribute(Message message, string entity) : this()
        {
            Message = message;
            Entity = entity;
        }
    }
}