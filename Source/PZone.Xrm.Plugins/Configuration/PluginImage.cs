namespace PZone.Xrm.Plugins.Configuration
{
    /// <summary>
    /// Plug-in Step Image.
    /// </summary>
    public class PluginImage
    {
        /// <summary>
        /// Image Type.
        /// </summary>
        public ImageType Type { get; set; }

        /// <summary>
        /// Image Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Entity Attributes.
        /// </summary>
        public string[] Attributes { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="type">Image Type.</param>
        /// <param name="name">Image Name.</param>
        /// <param name="attributes">Entity Attributes.</param>
        public PluginImage(ImageType type, string name, string[] attributes)
        {
            Type = type;
            Name = name;
            Attributes = attributes;
        }


        /// <summary>
        /// Constructor with default Image name.
        /// </summary>
        /// <param name="type">Image Type.</param>
        /// <param name="attributes">Entity Attributes.</param>
        public PluginImage(ImageType type, params string[] attributes)
        {
            Type = type;
            Name = IPluginExecutionContextExtensions.DefaultImageName;
            Attributes = attributes;
        }
    }
}