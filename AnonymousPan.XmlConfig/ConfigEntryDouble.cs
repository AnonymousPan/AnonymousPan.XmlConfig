using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class ConfigEntryDouble : ConfigEntryBase<double>
    {
        public ConfigEntryDouble(XmlConfigFile config, string storCategoryName, string storName,
        double defaultVal, ApplyValueDelegate<double> applyValueDeleg)
        : base(config, storCategoryName, storName, defaultVal, defaultVal.ToString(), applyValueDeleg)
        {
            valueCache = double.Parse(OriginalValue);
        }

        public override double GetValue()
        {
            return valueCache;
        }

        public override void SetValue(double value)
        {
            OriginalValue = value.ToString();
            valueCache = value;
        }
    }
}
