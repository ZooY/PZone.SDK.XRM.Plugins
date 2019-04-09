using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


namespace PZone.Xrm.Plugins
{
    //public abstract class ConfigurablePlugin<TConfig> : PluginBase where TConfig : IPluginConfig
    //{
    //    /// <summary>
    //    /// Префикс кастомных сущностей и полей.
    //    /// </summary>
    //    public const string PREFIX = "xxx_";


    //    /// <summary>
    //    /// Конфигурация плагина.
    //    /// </summary>
    //    public TConfig Config { get; set; }


    //    protected ConfigurablePlugin(string unsecureConfig) : base(unsecureConfig)
    //    {
    //    }


    //    protected override void InternalPreConfiguring(Context context)
    //    {
    //        LoadSettings(context);
    //    }


    //    private void LoadSettings(Context context)
    //    {
    //        try
    //        {
    //            var settings = context.SystemService.RetrieveMultiple(new QueryByAttribute(PREFIX + "setting")
    //            {
    //                ColumnSet = new ColumnSet(PREFIX + "value"),
    //                TopCount = 1,
    //                Attributes = { PREFIX + "key" },
    //                Values = { "Sample.MySetting" }
    //            }).Entities.FirstOrDefault();

    //            Config.MySetting = settings?.GetAttributeValue<string>(PREFIX + "value");

    //            FirstExecute = false;
    //        }
    //        catch (Exception ex)
    //        {
    //            context.TracingService.Trace(ex);
    //            throw new InvalidPluginExecutionException("System component configuration error. \nFailed to load component settings. \nPlease contact support.");
    //        }
    //    }
    //}
}