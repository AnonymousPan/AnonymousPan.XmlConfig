using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    /// <summary>
    /// Base of config value entry
    /// </summary>
    /// <typeparam name="T">Type of config value</typeparam>
    public abstract class ConfigEntryBase<T>
    {
        /// <summary>
        /// Apply value delegate
        /// <br/>
        /// Called when value is applied
        /// </summary>
        /// <typeparam name="TValue">Type of config value</typeparam>
        /// <param name="value">New value</param>
        public delegate void ApplyValueDelegate<TValue>(TValue value);

        private XmlConfigFile configFile;
        private string storageCategoryName, storageName;
        private T defaultValue;
        private string defaultValueString;
        private ApplyValueDelegate<T> applyValueDelegate;

        /// <summary>
        /// Use this field to reduce the value conversion between T and string
        /// </summary>
        protected T valueCache;

        /// <summary>
        /// Default constructor of ConfigEntryBase
        /// </summary>
        /// <param name="config">XmlConfigFile object for saving this value entry</param>
        /// <param name="storCategoryName">Category name in XmlConfigFile</param>
        /// <param name="storName">Key name in XmlConfigFile</param>
        /// <param name="defaultVal">Default value</param>
        /// <param name="defaultValueStr">Default value in string</param>
        /// <param name="applyValueDeleg">Apply value delegate<br/>Called when value is applied</param>
        public ConfigEntryBase(XmlConfigFile config, string storCategoryName, string storName,
            T defaultVal, string defaultValueStr, ApplyValueDelegate<T> applyValueDeleg)
        {
            configFile = config;
            storageCategoryName = storCategoryName;
            storageName = storName;
            defaultValue = defaultVal;
            defaultValueString = defaultValueStr;
            applyValueDelegate = applyValueDeleg;
        }

        /// <summary>
        /// Category name in XmlConfigFile
        /// </summary>
        public string StorageCategoryName { get => storageCategoryName; }

        /// <summary>
        /// Key name in XmlConfigFile
        /// </summary>
        public string StorageName { get => storageName; }

        /// <summary>
        /// Default value
        /// </summary>
        public T DefaultValue { get => defaultValue; }

        /// <summary>
        /// Value of this entry
        /// </summary>
        public T Value { get => GetValue(); set => SetValueAndApply(value); }

        /// <summary>
        /// Value in string
        /// </summary>
        public string OriginalValue { get => GetOriginalValue(); set => SetOriginalValue(value); }

        /// <summary>
        /// Get the value of this entry
        /// </summary>
        /// <returns>Value</returns>
        public abstract T GetValue();

        /// <summary>
        /// Set the value of this entry without applying
        /// </summary>
        /// <param name="value">Value</param>
        public abstract void SetValue(T value);

        /// <summary>
        /// Apply the value of this entry
        /// </summary>
        public void Apply()
        {
            applyValueDelegate?.Invoke(Value);
        }

        /// <summary>
        /// Set and apply the value of this entry
        /// </summary>
        /// <param name="value"></param>
        public void SetValueAndApply(T value)
        {
            SetValue(value);
            Apply();
        }

        /// <summary>
        /// Get the original value (value in string) of this entry
        /// </summary>
        /// <returns>Original value</returns>
        public string GetOriginalValue()
        {
            return configFile.GetCategory(storageCategoryName).GetValue(storageName, defaultValueString);
        }

        /// <summary>
        /// Set the original value (value in string) of this entry
        /// </summary>
        /// <param name="val">Original value</param>
        public void SetOriginalValue(string val)
        {
            configFile.GetCategory(storageCategoryName).SetValue(storageName, val);
        }
    }
}
