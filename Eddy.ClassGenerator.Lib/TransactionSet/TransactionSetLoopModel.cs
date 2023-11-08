#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.ClassGenerator.Lib;

public class TransactionSetLoopModel : ITransactionSetModel
{
    public int Position { get; set; } 
    public string Name { get; set; } = string.Empty;
    public List<ITransactionSetModel> Children { get; set; } = new();
    public bool Required { get; set; }
    public int Max { get; set; }
    public int Min { get; set; }


    public List<KeyValuePair<string, string>> GenerateFiles(string prefix, string modelNamespace, string @namespace, string version)
    {
        var results = new List<KeyValuePair<string, string>>();
        var sb = new StringBuilder();
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using Eddy.Core.Attributes;");
        sb.AppendLine("using Eddy.Core.Validation;");
        sb.AppendLine($"using {modelNamespace};");
        sb.AppendLine();
        sb.AppendLine($"namespace {@namespace};");
        sb.AppendLine();
        sb.AppendLine($"public class {prefix}{Name} {{");

        foreach (var item in Children)
        {
            if (item is TransactionSetLoopModel loop)
            {
                var newPrefix = "";
                if (prefix == "")
                {
                    newPrefix = Name + "_";
                }
                else
                {
                    newPrefix = prefix + "_" + Name + "_";
                }
                sb.AppendLine($"\t[SectionPosition({Position})] public List<{newPrefix}{loop.Name}> {loop.Name} {{get;set;}}");
                results.AddRange(loop.GenerateFiles(newPrefix, modelNamespace, @namespace, version));

            }
            else if (item is TransactionSetLineModel line)
            {
                sb.AppendLine(line.GenerateCode(version, prefix));
            }
        }
        sb.AppendLine("}");
        results.Add(new KeyValuePair<string, string>(prefix+Name, sb.ToString()));
        return results;
    }
}