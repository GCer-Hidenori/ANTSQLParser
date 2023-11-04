using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
//using CommandLine.Text;

namespace SQLParser
{
    class Options
    {
        [Option('f', "Filename", Required = false, HelpText = "Input filename.")]
        public string Filename { get; set; }

        [Option('s',"string", Required = false, HelpText = "Input string.")]
        public string Str { get; set; }

        [Option('e',"encode",Required =false,HelpText = "Encoding of input file")]
        public string Encoding { get; set; }

        [Option('o',"format", Required = true, HelpText = "Output format.json or xml.")]
        public string Format { get; set; }

        [Option('r', "rule", Required = false, HelpText = "Rule name.Default is tsql_file")]
        public string Rulename { get; set; }

        [Option('i', "indentxml", Required = false, HelpText = "Indent xml.")]
        public bool Indentxml { get; set; }

        [Option("noerrorlistener",Required =false,HelpText ="No use error listener")]
        public bool NoErrorListener { get; set; }

        [Option('u', "OutputFilename", Required = false, HelpText = "Output filename.")]
        public string OutputFilename { get; set; }
    }
}
