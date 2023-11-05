using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;

namespace LibTSQL
{
    class Node
    {
        public static List<Node> members = new List<Node>();
        public string value;
        public string token_display_name, token_literal_name, token_symbolic_name;
        public int? token_code = null;
        public string rule_name;

        public List<Node> children = new List<Node>();


        public Node()
        {
            members.Add(this);
        }

        public static void DebugOut(Node node,int depth=0)
        {
            Console.WriteLine("{0}{1}\t{2}\t{3}", new String(' ', depth * 2),node.rule_name,node.token_display_name, node.value);
            foreach(var child in node.children)
            {
                DebugOut(child, depth + 1);
            }
        }
        
        public Hashtable ToHashTable()
        {
            var hash = new Hashtable
            {
                { "token_display_name", token_display_name },
                { "token_literal_name", token_literal_name },
                { "token_symbolic_name", token_symbolic_name },
                { "rule", rule_name },
                { "value", value }
            };

            var ary = new ArrayList();
            foreach(var child in children)
            {
                ary.Add(child.ToHashTable());
            }

            hash.Add("children", ary);
            return hash;
        }
        public XmlDocument ToXml()
        {
            var doc = new XmlDocument();
            doc.AppendChild(ToXmlElement(doc));
            return doc;
        }
        public XmlElement ToXmlElement(XmlDocument doc)
        {
            var element = doc.CreateElement("node");
            element.SetAttribute("token_display_name", token_display_name);
            element.SetAttribute("token_literal_name", token_literal_name);
            element.SetAttribute("token_symbolic_name", token_symbolic_name);
            element.SetAttribute("rule", rule_name);
            element.SetAttribute("value", value);
            
            foreach (var child in children)
            {
                element.AppendChild(child.ToXmlElement(doc));
            }
            return element;
        }

    }
}
