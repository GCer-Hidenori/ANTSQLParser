using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace LibTSQL
{
    class TreeParser
    {
        string[] token_names;
        string[] rule_names;
        public TreeParser(string[] _token_names,string[] _rule_names)
        {
            token_names = _token_names;
            rule_names = _rule_names;
        }

        public Node parse(ParserRuleContext context, Node parent_node = null)
        {
            Node node = new Node();
            node.rule_name = rule_names[context.RuleIndex];
                
            var terminal = context.GetChild<TerminalNodeImpl>(0);
            if(terminal != null){
                node.value = terminal.GetText();
                node.token_name = get_tokenname(terminal.Payload.Type);
            }
            if(parent_node != null)parent_node.children.Add(node);

            for(var i = 0;i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if(child.ChildCount > 0)
                {
                    parse(child, node);
                }
            }
            return node;
        }
        public Node parse(IParseTree tree, Node parent_node)
        {
            Node node = new Node();
            
            parent_node.children.Add(node);
            for (var i = 0; i < tree.ChildCount; i++)
            {
                var child = tree.GetChild(i);
                if(child.ChildCount == 0) //childはTerminal
                {
                    var child_payload = ((TerminalNodeImpl)child).Payload;
                    var d = child_payload.TokenSource;
                    ITokenSource ts = child_payload.TokenSource;
                    node.value = child.GetText();
                    node.token_name = get_tokenname(child_payload.Type);
                    break;
                }
            }
            for(var i = 0;i < tree.ChildCount; i++)
            {
                var child = tree.GetChild(i);
                if (child.ChildCount > 0)
                {
                    parse(child, node);
                }
            }
            return node;
        }
        private string get_tokenname(int type)
        {
            if(type >= 0)
            {
                return token_names[type];
            }
            else
            {
                return "";
            }
        }
    }
}
