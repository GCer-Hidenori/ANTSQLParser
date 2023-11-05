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
        //static Hashtable members = new Hashtable();

        public string value;
        public string token_name;
        public string rule_name;
        //public Node parent;
        //public bool is_leaf;
        //public Node[] children;
        public List<Node> children = new List<Node>();

        /*
        public static Node GetNode(int v)
        {
            return (Node)members[v];
        }
        */
        public Node()
        {

        }
        /*
        public Node(string _value)
        {
            value = _value;
        }
        */
        public static void DebugOut(Node node,int depth=0)
        {
            Console.WriteLine("{0}{1}\t{2}\t{3}", new String(' ', depth * 2),node.rule_name,node.token_name, node.value);
            foreach(var child in node.children)
            {
                DebugOut(child, depth + 1);
            }
        }
        
        public Hashtable ToHashTable()
        {
            var hash = new Hashtable
            {
                { "token", token_name },
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
            element.SetAttribute("token", token_name);
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
