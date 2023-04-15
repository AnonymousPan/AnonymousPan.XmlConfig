using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryEnum<T> : ConfigEntryBase<T> where T : Enum
    {
        public ConfigEntryEnum(XmlConfigFile config, string storCategoryName, string storName,
        T defaultVal, ApplyValueDelegate<T> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = (T)Enum.Parse(typeof(T), OriginalValue);
        }

        public override T GetValue()
        {
            return valueCache;
        }

        public override void SetValue(T value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
