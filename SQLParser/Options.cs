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
        [Option('f',"filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option('s',"string", Required = false, HelpText = "Input string.")]
        public string str { get; set; }

        [Option('e',"encode",Required =false,HelpText = "Encoding of input file")]
        public string encoding { get; set; }

        [Option('o',"format", Required = true, HelpText = "Output format.json or xml.")]
        public string format { get; set; }

        [Option('r', "rule", Required = false, HelpText = "Rule name.Default is tsql_file")]
        public string rulename { get; set; }


    }
}
