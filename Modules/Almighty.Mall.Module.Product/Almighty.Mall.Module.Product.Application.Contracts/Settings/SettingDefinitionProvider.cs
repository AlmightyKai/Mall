using Volo.Abp.Settings;

namespace Almighty.Mall.Module.Product.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class SettingDefinitionProvider : Volo.Abp.Settings.SettingDefinitionProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(Settings.Attributes.MaxPageSize, "100", isVisibleToClients: true));
        }
    }
}
