using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class XmlConfigCategory
    {
        private XmlNode node;

        /// <summary>
        /// Create XmlConfigCategory object from category node
        /// </summary>
        /// <param name="n">Category node</param>
        public XmlConfigCategory(XmlNode n)
        {
            node = n;
        }

        /// <summary>
        /// Get value with specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="defaultValue">Default value<br/>Will be returned if key not exists</param>
        /// <returns>Value</returns>
        public string GetValue(string key, string defaultValue = null)
        {
            XmlNode valueNode = node.SelectSingleNode(key);
            if (valueNode != null)
            {
                return valueNode.InnerText;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Set value with specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="createNode">Create a new key-value node if not exists?</param>
        public void SetValue(string key, string value, bool createNode = true)
        {
            XmlNode valueNode = node.SelectSingleNode(key);
            if (valueNode == null)
            {
                if (createNode)
                {
                    valueNode = node.OwnerDocument.CreateElement(key);
                    node.AppendChild(valueNode);
                }
                else
                {
                    throw new XmlConfigException(string.Format("Key with name {0} not found", key), key);
                }
            }
            valueNode.InnerText = value;
        }
    }
}
