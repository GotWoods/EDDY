using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eddy.Core.Validation;

namespace Eddy.ClassGenerator.Lib;

public enum TestType
{
    IfOneIsFilledAllAreRequiredValidations,
    ARequiresBValidation,
    AtLeastOneValidations,
    OnlyOneOfValidations,
    IfOneIsFilledThenAtLeastOne
}

public class TestTheoryRules
{
    // ; //all filled
    //     ]"); //all empty
    //     ]"); //first filled, remainint empty
    //     ]"); //first empty, any other filled
}

public class TestGenerator
{
    public string GenerateTests(ParsedSegment parsed, ParseType parseType, string namespaceVersion)
    {
        var sbTest = new StringBuilder();
        sbTest.AppendLine("using Eddy.Core.Validation;");
        sbTest.AppendLine("using Eddy.Tests.x12;");
        sbTest.AppendLine("using Eddy.x12.Mapping;");
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
            if (model.IsRequired)
            {
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, true)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, false)}, true)]");
                sbTest.Append($"\tpublic void Validation_Required{model.Name}(");
                sbTest.Append($"{model.DataType.Replace("?", "")} {FirstCharToLowerCase(model.Name)}, "); //can not pass in a nullable with inline data
                sbTest.AppendLine("bool isValidExpected)");
                sbTest.AppendLine("\t{");
                sbTest.AppendLine($"\t\tvar subject = new {parsed.ClassName}();");
                foreach (var requiredItem in parsed.Items.Where(x => x.IsRequired && x.Name != model.Name))
                    if (requiredItem.IsDataTypeNumeric)
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
                    else
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");

                if (model.IsDataTypeNumeric) sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(model.Name)} > 0)");
                sbTest.AppendLine($"\t\tsubject.{model.Name} = {FirstCharToLowerCase(model.Name)};");
                sbTest.AppendLine("\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }


            if (model.IfOneIsFilledAllAreRequiredValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledAllAreRequiredValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //all filled
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //all empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]"); //first filled, remainint empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]"); //first empty, any other filled
                sbTest.AppendLine(GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, model, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledAllAreRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.ARequiresBValidation.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.ARequiresBValidation, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //all filled
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //all empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]"); //first empty, any other filled
                sbTest.AppendLine(GenerateTestBody(TestType.ARequiresBValidation, model, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.ARequiresB)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.AtLeastOneValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.AtLeastOneValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, false)]"); //all filled
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //all empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //first filled, remaining empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //first empty, any other filled
                sbTest.AppendLine(GenerateTestBody(TestType.AtLeastOneValidations, model, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.AtLeastOneIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.OnlyOneOfValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.OnlyOneOfValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //all filled
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]"); //all empty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //first filled, remainingEmpty
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //first empty, any other filled
                sbTest.AppendLine(GenerateTestBody(TestType.OnlyOneOfValidations, model, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.OnlyOneOf)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.IfOneIsFilledThenAtLeastOne.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledThenAtLeastOne, parsed.Items);
                // sbTest.AppendLine("\t[Theory]");
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //all filled
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //all empty
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //first filled, remaining empty
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //first is empty, remaining are true
                sbTest.Append(GenerateIfOneFilled(orderedFields));
                sbTest.AppendLine(GenerateTestBody(TestType.IfOneIsFilledThenAtLeastOne, model, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }
        }

        sbTest.AppendLine("}");
        return sbTest.ToString();
    }


    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
        return str;
    }

    private List<Model> OrderFieldsForTestSignature(List<ValidationData> validations, List<Model> items)
    {
        var result = new List<Model>();
        foreach (var validationData in validations)
        foreach (var field in validationData.GetAllFieldDataOrdered())
        {
            var foundField = FindFieldByPosition(field, items);
            result.Add(foundField);
        }

        return result;
    }

    private string GenerateIfOneFilled(List<Model> orderedFields)
    {
        var result = new StringBuilder();
        result.AppendLine("\t[Theory]");
        //all filled is a pass
        result.Append("\t[InlineData(");
        for (var i = 0; i < orderedFields.Count; i++)
        {
            result.Append(GenerateInlineDataValue(orderedFields[i], true));
            result.Append(", ");
        }

        result.AppendLine("true)]");

        //all empty is a  pass
        result.Append("\t[InlineData(");
        for (var i = 0; i < orderedFields.Count; i++)
        {
            result.Append(GenerateInlineDataValue(orderedFields[i], false));
            result.Append(", ");
        }

        result.AppendLine("true)]");

        //first is filled but remaining are blank is a fail
        result.Append("\t[InlineData(");
        result.Append(GenerateInlineDataValue(orderedFields[0], false));
        result.Append(", ");
        for (var i = 1; i < orderedFields.Count; i++) //start at 1 instead of zero this time
        {
            result.Append(GenerateInlineDataValue(orderedFields[i], true));
            result.Append(", ");
        }

        result.AppendLine("false)]");

        //first is empty, remaining are filled is a pass
        result.Append("\t[InlineData(");
        result.Append(GenerateInlineDataValue(orderedFields[0], true));
        result.Append(", ");
        for (var i = 1; i < orderedFields.Count; i++) //start at 1 instead of zero this time
        {
            result.Append(GenerateInlineDataValue(orderedFields[i], false));
            result.Append(", ");
        }

        result.AppendLine("true)]");


        return result.ToString();
    }

    private string GenerateTestBody(TestType testType, Model model, List<Model> items, string className)
    {
        var sbTest = new StringBuilder();
        List<ValidationData> validations = null;
        switch (testType)
        {
            case TestType.ARequiresBValidation:
                validations = model.ARequiresBValidation;
                sbTest.Append($"\tpublic void Validation_ARequiresB{model.Name}(");
                break;
            case TestType.AtLeastOneValidations:
                validations = model.AtLeastOneValidations;
                sbTest.Append($"\tpublic void Validation_AtLeastOne{model.Name}(");
                break;
            case TestType.IfOneIsFilledAllAreRequiredValidations:
                validations = model.IfOneIsFilledAllAreRequiredValidations;
                sbTest.Append($"\tpublic void Validation_AllAreRequired{model.Name}(");
                break;
            case TestType.IfOneIsFilledThenAtLeastOne:
                validations = model.IfOneIsFilledThenAtLeastOne;
                sbTest.Append($"\tpublic void Validation_IfOneSpecifiedThenOneMoreRequired_{model.Name}(");
                break;
            case TestType.OnlyOneOfValidations:
                validations = model.OnlyOneOfValidations;
                sbTest.Append($"\tpublic void Validation_OnlyOneOf{model.Name}(");
                break;
            default:
                throw new NotSupportedException("Test type is not supported " + testType);
        }


        foreach (var validationData in validations)
        foreach (var field in validationData.GetAllFieldDataOrdered())
        {
            var foundField = FindFieldByPosition(field, items);
            sbTest.Append($"{foundField.DataType.Replace("?", "")} {FirstCharToLowerCase(foundField.Name)}, ");
        }

        sbTest.AppendLine("bool isValidExpected)");
        sbTest.AppendLine("\t{");
        sbTest.AppendLine($"\t\tvar subject = new {className}();");

        //may impact the test if the variable is used in a validation
        foreach (var requiredItem in items.Where(x => x.IsRequired))
            if (requiredItem.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
            else
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");


        foreach (var validationData in validations)
        foreach (var field in validationData.GetAllFieldDataOrdered())
        {
            var otherField = FindFieldByPosition(field, items);

            if (otherField.IsDataTypeNumeric) sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(otherField.Name)} > 0)");
            sbTest.AppendLine($"\t\tsubject.{otherField.Name} = {FirstCharToLowerCase(otherField.Name)};");
        }

        //do if ARequriesB?

        return sbTest.ToString();
    }

    private Model FindFieldByPosition(string position, List<Model> fields)
    {
        foreach (var field in fields)
            if (position == field.Position)
                return field;
        return new Model(position, position, "string", 0, 0);
    }

    private string GenerateInlineDataValue(Model item, bool generateBlankDefault)
    {
        if (generateBlankDefault)
        {
            if (item.IsDataTypeNumeric)
                return "0";
            return "\"\"";
        }

        if (item.IsDataTypeNumeric)
            return item.TestValue;
        return $"\"{item.TestValue}\"";
    }
}