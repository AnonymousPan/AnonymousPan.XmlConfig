using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryString : ConfigEntryBase<string>
    {
        public ConfigEntryString(XmlConfigFile config, string storCategoryName, string storName,
        string defaultVal, ApplyValueDelegate<string> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal, applyValueDeleg)
        {

        }

        public override string GetValue()
        {
            return OriginalValue;
        }

        public override void SetValue(string value)
        {
            OriginalValue = value;
        }
    }
}
