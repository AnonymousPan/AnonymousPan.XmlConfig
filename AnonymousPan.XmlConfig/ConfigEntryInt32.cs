using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryInt32 : ConfigEntryBase<int>
    {
        /// <summary>
        /// Create a ConfigEntryInt32 object
        /// </summary>
        /// <param name="config">XmlConfigFile object for saving this value entry</param>
        /// <param name="storCategoryName">Category name in XmlConfigFile</param>
        /// <param name="storName">Key name in XmlConfigFile</param>
        /// <param name="defaultVal">Default value</param>
        /// <param name="applyValueDeleg">Apply value delegate<br/>Called when value is applied</param>
        public ConfigEntryInt32(XmlConfigFile config, string storCategoryName, string storName,
        int defaultVal, ApplyValueDelegate<int> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = int.Parse(GetOriginalValue());
        }

        public override int GetValue()
        {
            return valueCache;
        }

        public override void SetValue(int value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
