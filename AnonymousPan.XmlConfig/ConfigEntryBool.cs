using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryBool : ConfigEntryBase<bool>
    {
        /// <summary>
        /// Create a ConfigEntryBool object
        /// </summary>
        /// <param name="config">XmlConfigFile object for saving this value entry</param>
        /// <param name="storCategoryName">Category name in XmlConfigFile</param>
        /// <param name="storName">Key name in XmlConfigFile</param>
        /// <param name="defaultVal">Default value</param>
        /// <param name="applyValueDeleg">Apply value delegate<br/>Called when value is applied</param>
        public ConfigEntryBool(XmlConfigFile config, string storCategoryName, string storName,
        bool defaultVal, ApplyValueDelegate<bool> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = bool.Parse(GetOriginalValue());
        }

        public override bool GetValue()
        {
            return valueCache;
        }

        public override void SetValue(bool value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
