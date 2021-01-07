using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DH.Inspection.Localization
{
    public static class InspectionLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(InspectionConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(InspectionLocalizationConfigurer).GetAssembly(),
                        "DH.Inspection.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
