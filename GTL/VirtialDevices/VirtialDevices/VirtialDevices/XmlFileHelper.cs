using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections; 

namespace VirtialDevices
{
    public class XmlFileHelper
    {
        public enum XmlFileType { DuoTongDaoFenXiYi, CloneSelect, LiquidProcess};

        public static String getTypeString(XmlFileType type)
        {
            switch (type)
            {
                case XmlFileType.DuoTongDaoFenXiYi:
                    return "DuoTongDaoFenXiYi";
                case XmlFileType.CloneSelect:
                    return "CloneSelect";
                case XmlFileType.LiquidProcess:
                    return "LiquidProcess";
            }
            return "";
        }

        public static XmlFileType getStringType(String s) 
        {
            if (s.Equals("DuoTongDaoFenXiYi")) return XmlFileType.DuoTongDaoFenXiYi;
            if (s.Equals("CloneSelect")) return XmlFileType.CloneSelect;
            if (s.Equals("LiquidProcess")) return XmlFileType.LiquidProcess;
            return XmlFileType.DuoTongDaoFenXiYi;
        }
    }

    

    public class XmlFileInterpretor 
    {
        Hashtable map;
        private XmlDocument doc;
        private XmlElement root;

        public XmlFileInterpretor(String fileName) 
        {
            doc = new XmlDocument();
            doc.Load(fileName);
            root = (XmlElement)doc.SelectSingleNode("Root");
            map = new Hashtable();
            String type = root.GetAttribute("type");
            map.Add("Type", XmlFileHelper.getStringType(type));
            foreach (XmlElement ele in root.ChildNodes) 
            {
                map.Add(ele.Name, ele.InnerText);
            }
        }

        public XmlFileHelper.XmlFileType getFileType() 
        {
            return (XmlFileHelper.XmlFileType)map["Type"];
        }

        public String getNodeMessage(String name) 
        {
            return (String)map[name];
        }

        public Hashtable getAllXmlMessage() 
        {
            return map;
        }

    }

    public class XmlFileCreator
    {

        private XmlDocument doc;
        private XmlElement root;
        private String FileName;

        public XmlFileCreator(XmlFileHelper.XmlFileType type,String fileName) 
        {
            FileName = fileName;
            doc = new XmlDocument();
            root = doc.CreateElement("Root");
            String typeStr = XmlFileHelper.getTypeString(type);
            root.SetAttribute("type",typeStr);
            doc.AppendChild(root);
        }

        public void addElement(String name, String value) 
        {
            XmlElement child = doc.CreateElement(name);
            child.InnerText = value;
            root.AppendChild(child);
        }

        public void save() 
        {
            doc.Save(FileName);
        }
    }
}
