using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.IO;
using Newtonsoft.Json;
/*
Install-Package antlr4
Install-Package Newtonsoft.Json -Version 12.0.3
*/
namespace LibTSQL
{
    public class LibTSQL
    {
        Node root;
        public LibTSQL()
        {

        }
        public void load_string(string str)
        {
            var inputStream = new AntlrInputStream(str);
            var lexer = new TSqlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new TSqlParser(commonTokenStream);
            //parser.AddErrorListener(new MyErrorListener());


            ParserRuleContext graphContext = parser.tsql_file();
            var token_names = parser.TokenNames;
            var rule_names = parser.RuleNames;
            var tree_parser = new TreeParser(token_names, rule_names);
            root = tree_parser.parse(graphContext);
        }
        public void load_file(string filepath, string encoding_name = "Shift_JIS")
        {
            string text;
            var encoding = Encoding.GetEncoding(encoding_name);
            using (StreamReader sr = new StreamReader(filepath, encoding))
            {
                text = sr.ReadToEnd();
            }
            load_string(text);
        }
        public string to_json()
        {
            return JsonConvert.SerializeObject(root.to_Hashtable(), Newtonsoft.Json.Formatting.Indented);
        }
        public XmlDocument to_xml()
        {
            return root.to_xml();
        }
    }
}
