using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryFloat : ConfigEntryBase<float>
    {
        public ConfigEntryFloat(XmlConfigFile config, string storCategoryName, string storName,
        float defaultVal, ApplyValueDelegate<float> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = float.Parse(OriginalValue);
        }

        public override float GetValue()
        {
            return valueCache;
        }

        public override void SetValue(float value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
