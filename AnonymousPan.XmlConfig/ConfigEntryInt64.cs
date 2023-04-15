using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryInt64 : ConfigEntryBase<long>
    {
        public ConfigEntryInt64(XmlConfigFile config, string storCategoryName, string storName,
        long defaultVal, ApplyValueDelegate<long> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = long.Parse(OriginalValue);
        }

        public override long GetValue()
        {
            return valueCache;
        }

        public override void SetValue(long value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
