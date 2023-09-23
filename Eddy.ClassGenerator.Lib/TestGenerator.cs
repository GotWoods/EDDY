using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Eddy.Core.Validation;

namespace Eddy.ClassGenerator.Lib;

public enum TestType
{
    IfOneIsFilledAllAreRequiredValidations,
    ARequiresBValidation,
    AtLeastOneValidations,
    OnlyOneOfValidations,
    IfOneIsFilledThenAtLeastOne,
    Required
}


public class TestGenerator
{
    public string GenerateTests(ParsedSegment parsed, ParseType parseType, string namespaceVersion)
    {
        var sbTest = new StringBuilder();
        sbTest.AppendLine("using Eddy.Core.Validation;");
        sbTest.AppendLine("using Eddy.Tests.x12;");
        sbTest.AppendLine("using Eddy.x12.Mapping;");
        sbTest.AppendLine("using Eddy.x12.Models.Elements;");
        sbTest.AppendLine("using Eddy.x12.Models.v" + namespaceVersion + ";");
        sbTest.AppendLine();
        sbTest.AppendLine("namespace Eddy.x12.Tests.Models.v" + namespaceVersion + ";");
        sbTest.AppendLine();
        sbTest.AppendLine($"public class {parsed.SegmentType}Tests");
        sbTest.AppendLine("{");
        sbTest.AppendLine("\t[Fact]");


        sbTest.AppendLine("\tpublic void Parse_ShouldReturnCorrectObject()");
        sbTest.AppendLine("\t{");
        if (parseType == ParseType.x12Element)
            sbTest.Append("\t\tvar x12Line = \"");
        else
            sbTest.Append($"\t\tstring x12Line = \"{parsed.SegmentType}");
        foreach (var model in parsed.Items) sbTest.Append("*" + model.TestValue);
        sbTest.AppendLine("\";");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar expected = new {parsed.ClassName}()");
        sbTest.AppendLine("\t\t{");
        foreach (var model in parsed.Items)
            if (model.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\t\t{model.Name} = {model.TestValue},");
            else if(model.IsDataTypeComposite) 
                sbTest.AppendLine($"\t\t\t{model.Name} = null,");
            else
                sbTest.AppendLine($"\t\t\t{model.Name} = \"{model.TestValue}\",");
        sbTest.AppendLine("\t\t};");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar actual = Map.MapObject<{parsed.ClassName}>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);");
        sbTest.AppendLine("\t\tAssert.Equivalent(expected, actual);");
        sbTest.AppendLine("\t}");
        sbTest.AppendLine();

        foreach (var model in parsed.Items)
        {
            TestModel tm;
            
            if (model.IsRequired)
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items, TestType.Required);
                sbTest.AppendLine(tm.Generate());
            }
            
            if (model.IfOneIsFilledAllAreRequiredValidations.Any())
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items, TestType.IfOneIsFilledAllAreRequiredValidations);
                sbTest.AppendLine(tm.Generate());
            }

            if (model.ARequiresBValidation.Any())
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items,TestType.ARequiresBValidation);
                sbTest.AppendLine(tm.Generate());
            }

            if (model.AtLeastOneValidations.Any())
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items, TestType.AtLeastOneValidations);
                sbTest.AppendLine(tm.Generate());
            }

            if (model.OnlyOneOfValidations.Any())
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items, TestType.OnlyOneOfValidations);
                sbTest.AppendLine(tm.Generate());
            }

            if (model.IfOneIsFilledThenAtLeastOne.Any())
            {
                tm = new TestModel(model, parsed.ClassName, parsed.Items, TestType.IfOneIsFilledThenAtLeastOne);
                sbTest.AppendLine(tm.Generate());
            }
        }

        sbTest.AppendLine("}");
        return sbTest.ToString();
    }
}