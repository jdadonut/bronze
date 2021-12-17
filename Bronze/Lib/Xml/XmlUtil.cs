using System.Xml;

namespace Bronze.Lib.Xml
{
    public static class XmlUtil
    {
        public static List<string> GetAttrsOfTypeNode(this XmlReader reader, string nodeType, string attrName)
        {
            var list = new List<string>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == nodeType)
                {
                    list.Add(reader.GetAttribute(attrName) ?? "");
                }
            }
            return list;
        }
    }
}