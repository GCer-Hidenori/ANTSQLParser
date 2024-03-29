using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CommandLine;

/*
 Install-Package CommandLineParser
*/
namespace SQLParser
{
    class Program
    {
        static int Main(string[] args)
        {
            //var option = new Options();
            var parseResult = Parser.Default.ParseArguments<Options>(args);
            string output;
            switch (parseResult.Tag)
            {
                case ParserResultType.Parsed:
                    var parsed = parseResult as Parsed<Options>;
                    var option = parsed.Value;
                    LibTSQL.LibTSQL lib = new LibTSQL.LibTSQL
                    {
                        noerrorlistener = option.NoErrorListener
                    };
                    try
                    {
                        if(option.Rulename != null)
                        {
                            lib.start_rulename = option.Rulename;
                        }

                        if (option.Str != null)
                        {
                            lib.LoadString(option.Str);
                        }
                        else if (option.Filename != null)
                        {
                            if (option.Encoding != null)
                            {
                                lib.LoadFile(option.Filename, option.Encoding);
                            }
                            else
                            {
                                lib.LoadFile(option.Filename);
                            }
                        }
                        else
                        {
                            Console.Error.WriteLine("Filename or string is required.");
                            return 1;
                        }
                    }catch(LibTSQL.ParserError e)
                    {
                        Console.Error.WriteLine(e);
                        return 1;
                    }

                    switch(option.Format.ToUpper())
                    {
                        case "JSON":
                            output = lib.ToJson();
                            break;
                        case "XML":
                            output = lib.ToXml().OuterXml;
                            if (option.Indentxml)
                            {
                                output = IndentXml(output);
                            }
                            break;
                        default:
                            Console.Error.WriteLine("Invalid format '{0}'.Please specify JSON or XML.");
                            return 1;
                    }
                    if (option.OutputFilename != null)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(option.OutputFilename))
                        {
                            sw.Write(output);
                        }
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    return 0;
                    
                case ParserResultType.NotParsed:
                    Console.Error.WriteLine("Commandline parse error.");
                    return 1;
                default:
                    return 1;
            }
        }
        static string IndentXml(string xmlstring)
        {
            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlstring);
            var ws = new System.Xml.XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = "  "
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, ws))
                {
                    doc.Save(writer);
                }
                return (new System.Text.UTF8Encoding(false)).GetString(stream.ToArray());
                
            }
        }
    }
}
