using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnonymousPan.XmlConfig
{
    /// <summary>
    /// A simple config manager template
    /// <br/>
    /// Please see ConfigManagerExample.cs for example
    /// </summary>
    public abstract class SimpleConfigManagerBase
    {
        /// <summary>
        /// Instance of the XmlConfigFile
        /// </summary>
        public XmlConfigFile ConfigFile { get; protected set; }

        /// <summary>
        /// Path of the XML file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Create an empty config manager
        /// </summary>
        public SimpleConfigManagerBase()
        {
            ConfigFile = new XmlConfigFile();
        }

        /// <summary>
        /// Create a config manager and load config from the given path
        /// </summary>
        /// <param name="filePath">Path of the XML file</param>
        public SimpleConfigManagerBase(string filePath)
        {
            FilePath = filePath;
            ConfigFile = new XmlConfigFile(File.ReadAllText(filePath));
        }

        /// <summary>
        /// Initialize the config manager
        /// <br/>
        /// Call constructors of ConfigEntry objects here
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Apply all of the entries
        /// </summary>
        public void ApplyAll()
        {
            Type configEntryBase = typeof(ConfigEntryBase<>);
            PropertyInfo[] entryProps = this.GetType().GetProperties();
            foreach(PropertyInfo prop in entryProps)
            {
                if(prop.PropertyType.BaseType.GetGenericTypeDefinition() == configEntryBase && prop.CanRead)
                {
                    object propObj = prop.GetValue(this, null);
                    MethodInfo applyMethod = propObj.GetType().GetMethod("Apply");
                    applyMethod.Invoke(propObj, null);
                }
            }
        }

        /// <summary>
        /// Save the config file to FilePath
        /// </summary>
        public void Save()
        {
            if(string.IsNullOrEmpty(FilePath))
            {
                throw new InvalidOperationException("FilePath is null or empty");
            }
            ConfigFile.Save(FilePath);
        }
    }
}
