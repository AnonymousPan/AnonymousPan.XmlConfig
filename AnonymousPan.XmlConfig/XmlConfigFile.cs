using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace AnonymousPan.XmlConfig
{
    public class XmlConfigFile
    {
        private XmlDocument doc;
        private XmlNode rootNode;
        private Dictionary<string, XmlConfigCategory> categories;

        /// <summary>
        /// A string for marking the version of the config XML document
        /// <br/>
        /// Stored as an attribute named Version in root node of config XML document
        /// </summary>
        public string VersionString
        {
            get
            {
                XmlAttribute attr = rootNode.Attributes["Version"];
                if (attr == null)
                {
                    return null;
                }
                else
                {
                    return attr.Value;
                }
            }
            set
            {
                XmlAttribute attr = rootNode.Attributes["Version"];
                if (attr == null)
                {
                    attr = doc.CreateAttribute("Version");
                    rootNode.Attributes.Append(attr);
                }
                attr.Value = value;
            }
        }

        /// <summary>
        /// Create an empty XMLConfigFile object
        /// </summary>
        public XmlConfigFile()
        {
            doc = new XmlDocument();
            categories = new Dictionary<string, XmlConfigCategory>();
            InitializeXml();
        }

        /// <summary>
        /// Create an XMLConfigFile object with XML content string
        /// </summary>
        /// <param name="xmlContent">XML content string</param>
        public XmlConfigFile(string xmlContent)
        {
            doc = new XmlDocument();
            categories = new Dictionary<string, XmlConfigCategory>();
            doc.LoadXml(xmlContent);
            InitializeXml();
        }

        /// <summary>
        /// Create root element and XML declaration if not exists
        /// </summary>
        private void InitializeXml()
        {
            XmlNode root;
            if (doc.DocumentElement == null)
            {
                doc.InsertBefore(doc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), doc.DocumentElement);
                root = doc.CreateElement("XmlConfig");
                doc.AppendChild(root);
            }
            else
            {
                root = doc.DocumentElement;
            }
            rootNode = root;
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <returns>XmlConfigCategory object</returns>
        public XmlConfigCategory CreateCategory(string name)
        {
            if (categories.ContainsKey(name))
            {
                throw new XmlConfigException(string.Format("Category with name {0} already exists", name), name);
            }
            XmlNode categoryNode = rootNode.SelectSingleNode(name);
            if (categoryNode == null)
            {
                categoryNode = doc.CreateElement(name);
                rootNode.AppendChild(categoryNode);
            }
            XmlConfigCategory cat = new XmlConfigCategory(categoryNode);
            categories.Add(name, cat);
            return cat;
        }

        /// <summary>
        /// Get category with specified name
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <param name="createCategory">Create a new category if not exists?</param>
        /// <returns>XmlConfigCategory object</returns>
        public XmlConfigCategory GetCategory(string name, bool createCategory = true)
        {
            XmlConfigCategory cat;
            if (categories.TryGetValue(name, out cat))
            {
                return cat;
            }
            else
            {
                if (createCategory)
                {
                    return CreateCategory(name);
                }
                else
                {
                    throw new XmlConfigException(string.Format("Category with name {0} not found", name), name);
                }
            }
        }

        /// <summary>
        /// Get the content string of XML document
        /// </summary>
        /// <returns>XML content string</returns>
        public string GetXmlContent()
        {
            return doc.InnerXml;
        }

        /// <summary>
        /// Save the XML config file
        /// </summary>
        /// <param name="path">Location of the XML config file</param>
        public void Save(string path)
        {
            doc.Save(path);
        }

        
    }
}
