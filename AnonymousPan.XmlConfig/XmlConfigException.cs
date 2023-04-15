using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class XmlConfigException : Exception
    {
        /// <summary>
        /// Name of the category or key which caused the exception
        /// <br/>
        /// <see langword="null"/> if name is unavailable
        /// </summary>
        public string Name { get; private set; }

        public XmlConfigException(string message) : base(message) { }
        public XmlConfigException(string message, string name) : base(message)
        {
            Name = name;
        }
    }
}
