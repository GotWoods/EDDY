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
    IfOneIsFilledThenAtLeastOne
}

public class TestTheoryRules
{
    public TestTheoryFieldAction AllFilled { get; set; }
    public TestTheoryFieldAction AllEmpty { get; set; }
    public TestTheoryFieldAction FirstFilled_RemainingEmpty { get; set; }
    public TestTheoryFieldAction FirstEmpty_AnyOtherFilled { get; set; }
}

public enum TestTheoryFieldAction
{
    Pass,
    Fail,
    Ignore
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
                var requiredTestModel = new TestModel();
                requiredTestModel.PrimaryItem = model;
                requiredTestModel.Theories.Add($"\t[InlineData({GenerateInlineDataValue(model, true)}, false)]");
                requiredTestModel.Theories.Add($"\t[InlineData({GenerateInlineDataValue(model, false)}, true)]");
                requiredTestModel.TestName = $"Validation_Required{model.Name}";
                requiredTestModel.SubjectName = parsed.ClassName;
                sbTest.AppendLine(requiredTestModel.Generate());
            }


            if (model.IfOneIsFilledAllAreRequiredValidations.Any())
            {
                //var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledAllAreRequiredValidations, parsed.Items);
                // var theories = new List<string>
                // {
                //     
                //
                //
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]", //all filled
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]", //all empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]", //first filled, remainint empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]" //first empty, any other filled
                // };
                sbTest.AppendLine(GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, model, parsed.Items, parsed.ClassName, nameof(ErrorCodes.IfOneIsFilledAllAreRequired)));
            }

            if (model.ARequiresBValidation.Any())
            {
              //  var orderedFields = OrderFieldsForTestSignature(model.ARequiresBValidation, parsed.Items);
                // var theories = new List<string>
                // {
                //     // sbTest.AppendLine("\t[Theory]");
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]", //all filled
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]", //all empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]" //first empty, any other filled
                // };
                sbTest.AppendLine(GenerateTestBody(TestType.ARequiresBValidation, model, parsed.Items, parsed.ClassName, nameof(ErrorCodes.ARequiresB)));
            }

            if (model.AtLeastOneValidations.Any())
            {
              //  var orderedFields = OrderFieldsForTestSignature(model.AtLeastOneValidations, parsed.Items);
                // var theories = new List<string>
                // {
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, false)]", //all filled
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]", //all empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]", //first filled, remaining empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]" //first empty, any other filled
                // };

                sbTest.AppendLine(GenerateTestBody(TestType.AtLeastOneValidations, model, parsed.Items, parsed.ClassName, nameof(ErrorCodes.AtLeastOneIsRequired)));
            }

            if (model.OnlyOneOfValidations.Any())
            {
               // var orderedFields = OrderFieldsForTestSignature(model.OnlyOneOfValidations, parsed.Items);
                // var theories = new List<string>
                // {
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]", //all filled
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]", //all empty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]", //first filled, remainingEmpty
                //     $"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]" //first empty, any other filled
                // };

                sbTest.AppendLine(GenerateTestBody(TestType.OnlyOneOfValidations, model, parsed.Items, parsed.ClassName, nameof(ErrorCodes.OnlyOneOf)));
            }

            if (model.IfOneIsFilledThenAtLeastOne.Any())
            {
               // var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledThenAtLeastOne, parsed.Items);
                // sbTest.AppendLine("\t[Theory]");
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //all filled
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //all empty
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]"); //first filled, remaining empty
                // sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]"); //first is empty, remaining are true
                //var theories = GenerateTheoriesFromRules(orderedFields, rules);
                sbTest.AppendLine(GenerateTestBody(TestType.IfOneIsFilledThenAtLeastOne, model, parsed.Items, parsed.ClassName, nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired)));
            }
        }

        sbTest.AppendLine("}");
        return sbTest.ToString();
    }


    // private string FirstCharToLowerCase(string str)
    // {
    //     if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
    //         return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
    //     return str;
    // }

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

    private List<string> GenerateTheoriesFromRules(List<Model> orderedFields, TestTheoryRules rules)
    {
        var theories = new List<string>();

        var result = new StringBuilder();

        if (rules.AllFilled != TestTheoryFieldAction.Ignore)
        {
            result.Append("\t[InlineData(");
            for (var i = 0; i < orderedFields.Count; i++)
            {
                result.Append(GenerateInlineDataValue(orderedFields[i], true));
                result.Append(", ");
            }

            if (rules.AllFilled == TestTheoryFieldAction.Pass)
                result.Append("true)]");
            else
                result.Append("false)]");

            theories.Add(result.ToString());
        }

        if (rules.AllEmpty != TestTheoryFieldAction.Ignore)
        {
            result = new StringBuilder();
            result.Append("\t[InlineData(");
            for (var i = 0; i < orderedFields.Count; i++)
            {
                result.Append(GenerateInlineDataValue(orderedFields[i], false));
                result.Append(", ");
            }
            
            if (rules.AllEmpty == TestTheoryFieldAction.Pass)
                result.Append("true)]");
            else
                result.Append("false)]");

            theories.Add(result.ToString());
        }


        if (rules.FirstFilled_RemainingEmpty != TestTheoryFieldAction.Ignore)
        {
            result = new StringBuilder();
            result.Append("\t[InlineData(");
            result.Append(GenerateInlineDataValue(orderedFields[0], false));
            result.Append(", ");
            for (var i = 1; i < orderedFields.Count; i++) //start at 1 instead of zero this time
            {
                result.Append(GenerateInlineDataValue(orderedFields[i], true));
                result.Append(", ");
            }

            if (rules.FirstFilled_RemainingEmpty == TestTheoryFieldAction.Pass)
                result.Append("true)]");
            else
                result.Append("false)]");

            theories.Add(result.ToString());
        }

        if (rules.FirstEmpty_AnyOtherFilled != TestTheoryFieldAction.Ignore)
        {
            result = new StringBuilder();
            //first is empty, remaining are filled is a pass
            result.Append("\t[InlineData(");
            result.Append(GenerateInlineDataValue(orderedFields[0], true));
            result.Append(", ");
            for (var i = 1; i < orderedFields.Count; i++) //start at 1 instead of zero this time
            {
                result.Append(GenerateInlineDataValue(orderedFields[i], false));
                result.Append(", ");
            }
        }

        if (rules.FirstEmpty_AnyOtherFilled == TestTheoryFieldAction.Pass)
            result.Append("true)]");
        else
            result.Append("false)]");

        theories.Add(result.ToString());

        return theories;
    }

    public string GenerateTestBody(TestType testType, Model model, List<Model> items, string classToTest, string expectedErrorCode)
    {
        var tm = new TestModel();
        tm.PrimaryItem = model;
        tm.SubjectName = classToTest;
        tm.ExpectedErrorCode = expectedErrorCode;

        // foreach (var theory in theories)
        // {
        //     tm.Theories.Add(theory);
        // }

        List<ValidationData> validations = null;
        var rules = new TestTheoryRules();
        switch (testType)
        {
            case TestType.ARequiresBValidation:
                tm.TestName = $"Validation_ARequiresB{model.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                tm.Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(model.ARequiresBValidation, items), rules);
                validations = model.ARequiresBValidation;
                break;
            case TestType.AtLeastOneValidations:
                tm.TestName = $"Validation_AtLeastOne{model.Name}";
                rules.AllFilled = TestTheoryFieldAction.Fail;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Pass;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                tm.Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(model.AtLeastOneValidations, items), rules);
                validations = model.AtLeastOneValidations;
                break;
            case TestType.IfOneIsFilledAllAreRequiredValidations:
                tm.TestName = $"Validation_AllAreRequired{model.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Fail;

                tm.Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(model.IfOneIsFilledAllAreRequiredValidations, items), rules);
                validations = model.IfOneIsFilledAllAreRequiredValidations;
            
                break;
            case TestType.IfOneIsFilledThenAtLeastOne:
                tm.TestName = $"Validation_IfOneSpecifiedThenOneMoreRequired_{model.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                tm.Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(model.IfOneIsFilledThenAtLeastOne, items), rules);
                validations = model.IfOneIsFilledThenAtLeastOne;
            break;
            case TestType.OnlyOneOfValidations:
                tm.TestName = $"Validation_OnlyOneOf{model.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Fail;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Pass;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                tm.Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(model.OnlyOneOfValidations, items), rules);
                validations = model.OnlyOneOfValidations;
        
                break;
            default:
                throw new NotSupportedException("Test type is not supported " + testType);
        }
        
        foreach (var validationData in validations)
        foreach (var field in validationData.GetAllFieldDataOrdered())
        {
            var foundField = FindFieldByPosition(field, items);
            tm.TestParameter.Add(foundField);
        }

        foreach (var requiredItem in items.Where(x => x.IsRequired))
        {
            tm.RequiredTestItems.Add(requiredItem);
        }
        
        return tm.Generate();
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