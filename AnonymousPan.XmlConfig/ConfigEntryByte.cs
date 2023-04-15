using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryByte : ConfigEntryBase<byte>
    {
        public ConfigEntryByte(XmlConfigFile config, string storCategoryName, string storName,
        byte defaultVal, ApplyValueDelegate<byte> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = byte.Parse(OriginalValue);
        }

        public override byte GetValue()
        {
            return valueCache;
        }

        public override void SetValue(byte value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
