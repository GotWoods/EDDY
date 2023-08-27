using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eddy.Core.Validation;

namespace Eddy.ClassGenerator.Lib;

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

public class TestModel
{
    private string TestName { get; set; }
    private List<string> Theories { get; set; } = new();
    private string SubjectName { get; set; }
    private List<Model> RequiredTestItems { get; } = new();
    private Model PrimaryItem { get; set; }
    private List<Model> TestParameters { get; } = new();
    private string ExpectedErrorCode { get; set; }
    private List<Model> AllParameters { get; set; }
    public TestType TestType { get; set; }

    public TestModel(Model primaryItem, string subjectName, List<Model> allParameters, TestType testType)
    {
        PrimaryItem = primaryItem;
        SubjectName = subjectName;
        AllParameters = allParameters;
        TestType = testType;
    }

    public string Generate()
    {
        var sbTest = new StringBuilder();

        var rules = new TestTheoryRules();
        List<ValidationData> validations = null;
        switch (TestType)
        {
            case TestType.Required:
                TestName = $"Validation_Required{PrimaryItem.Name}";
                Theories.Add($"\t[InlineData({GenerateInlineDataValue(PrimaryItem, true)}, false)]");
                Theories.Add($"\t[InlineData({GenerateInlineDataValue(PrimaryItem, false)}, true)]");
                TestParameters.Add(PrimaryItem);
                ExpectedErrorCode = nameof(ErrorCodes.Required);
                break;
            case TestType.ARequiresBValidation:
                TestName = $"Validation_ARequiresB{PrimaryItem.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(PrimaryItem.ARequiresBValidation, AllParameters), rules);
                validations = PrimaryItem.ARequiresBValidation;
                ExpectedErrorCode = nameof(ErrorCodes.ARequiresB);
                break;
            case TestType.AtLeastOneValidations:
                TestName = $"Validation_AtLeastOne{PrimaryItem.Name}";
                rules.AllFilled = TestTheoryFieldAction.Fail;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Pass;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(PrimaryItem.AtLeastOneValidations, AllParameters), rules);
                validations = PrimaryItem.AtLeastOneValidations;
                ExpectedErrorCode = nameof(ErrorCodes.AtLeastOneIsRequired);
                break;
            case TestType.IfOneIsFilledAllAreRequiredValidations:
                TestName = $"Validation_AllAreRequired{PrimaryItem.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Fail;

                Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(PrimaryItem.IfOneIsFilledAllAreRequiredValidations, AllParameters), rules);
                validations = PrimaryItem.IfOneIsFilledAllAreRequiredValidations;
                ExpectedErrorCode = nameof(ErrorCodes.IfOneIsFilledAllAreRequired);
                break;
            case TestType.IfOneIsFilledThenAtLeastOne:
                TestName = $"Validation_IfOneSpecifiedThenOneMoreRequired_{PrimaryItem.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Pass;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Fail;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(PrimaryItem.IfOneIsFilledThenAtLeastOne, AllParameters), rules);
                validations = PrimaryItem.IfOneIsFilledThenAtLeastOne;
                ExpectedErrorCode = nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
                break;
            case TestType.OnlyOneOfValidations:
                TestName = $"Validation_OnlyOneOf{PrimaryItem.Name}";
                rules.AllFilled = TestTheoryFieldAction.Pass;
                rules.AllEmpty = TestTheoryFieldAction.Fail;
                rules.FirstFilled_RemainingEmpty = TestTheoryFieldAction.Pass;
                rules.FirstEmpty_AnyOtherFilled = TestTheoryFieldAction.Pass;
                Theories = GenerateTheoriesFromRules(OrderFieldsForTestSignature(PrimaryItem.OnlyOneOfValidations, AllParameters), rules);
                validations = PrimaryItem.OnlyOneOfValidations;
                ExpectedErrorCode = nameof(ErrorCodes.OnlyOneOf);
                break;
            default:
                throw new NotSupportedException("Test type is not supported " + TestType);
        }

        if (validations != null)
        {
            foreach (var validationData in validations)
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var foundField = FindFieldByPosition(field, AllParameters);
                TestParameters.Add(foundField);
            }
        }

        foreach (var requiredItem in AllParameters.Where(x => x.IsRequired && x.Position != PrimaryItem.Position)) 
            RequiredTestItems.Add(requiredItem);


        sbTest.AppendLine("\t[Theory]");
        foreach (var theory in Theories) sbTest.AppendLine(theory);
        sbTest.Append($"\tpublic void {TestName}(");
        foreach (var testParameter in TestParameters)
            sbTest.Append($"{testParameter.DataType.Replace("?", "")} {FirstCharToLowerCase(testParameter.Name)}, "); //can not pass in a nullable with inline data

        sbTest.AppendLine("bool isValidExpected)");
        sbTest.AppendLine("\t{");
        sbTest.AppendLine($"\t\tvar subject = new {SubjectName}();");
        foreach (var requiredItem in RequiredTestItems)
            if (requiredItem.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
            else
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");

        foreach (var testParameter in TestParameters)
        {
            var indent = "\t\t";
            if (testParameter.IsDataTypeNumeric)
            {
                sbTest.AppendLine($"{indent}if ({FirstCharToLowerCase(testParameter.Name)} > 0)");
                indent = "\t\t\t";
            }

            sbTest.AppendLine($"{indent}subject.{testParameter.Name} = {FirstCharToLowerCase(testParameter.Name)};");
        }

        // if (PrimaryItem.IsDataTypeNumeric) 
        //     sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(PrimaryItem.Name)} > 0)");
        // sbTest.AppendLine($"\t\tsubject.{PrimaryItem.Name} = {FirstCharToLowerCase(PrimaryItem.Name)};");

      
            var dependentRules = GetARequiresBRules();

            foreach (var dependentRule in dependentRules)
            {
                sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(dependentRule.Key.Name)} != \"\")");
                if (dependentRule.Value.Count > 1)
                {
                    sbTest.AppendLine("\t\t{");
                    sbTest.AppendLine($"\t\t\t{dependentRule.Value[0]} == {dependentRule.Value[0]}");
                    sbTest.AppendLine("\t\t}");
                }
                else
                {
                    var field = FindFieldByPosition(dependentRule.Value[0], AllParameters);
                    sbTest.AppendLine($"\t\t\tsubject.{field.Name} == \"{field.TestValue}\"");
                }
            }

            var atleastOneOfRules = GetAtLeastOneRules();

            foreach (var dependentRule in atleastOneOfRules)
            {
               var field = FindFieldByPosition(dependentRule, AllParameters);
               sbTest.AppendLine($"\t\tsubject.{field.Name} == \"{field.TestValue}\"");
            }


        sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{ExpectedErrorCode});");
        sbTest.AppendLine("\t}");
        return sbTest.ToString();
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

    private Model FindFieldByPosition(string position, List<Model> fields)
    {
        foreach (var field in fields)
            if (position == field.Position)
                return field;
        return new Model(position, position, "string", 0, 0);
    }

    public Dictionary<Model, List<string>> GetARequiresBRules()
    {
        var result = new Dictionary<Model, List<string>>();
        foreach (var testParameter in AllParameters.Where(x=>x.Position != PrimaryItem.Position)) //make sure we do not include the property under test
        {
            if (TestType != TestType.ARequiresBValidation)
            {
                if (testParameter.ARequiresBValidation.Any())
                {
                    foreach (var validationData in testParameter.ARequiresBValidation)
                        if (validationData.FirstFieldPosition == testParameter.Position) //One of tte test parameters has an ARequiresB rule on it as well
                        {
                            if (!result.ContainsKey(testParameter))
                                result.Add(testParameter, new List<string>());
                            result[testParameter].AddRange(validationData.OtherFields);
                        }
                }
            }
            
            // if (testParameter.AtLeastOneValidations.Any()) //this is similar to required in that one them needs to be there
            // {
            //     foreach (var validationData in testParameter.AtLeastOneValidations) //we should look to see which of the parameters is not part of the TestParameters and use that. For this one, we can just do FieldName=TestValue
            //         result.Add(testParameter, new List<string>() { validationData.FirstFieldPosition }); //just add the first field which would satisfy the AtLeastOne rule
            // }
        }
        return result;
    }

    public List<string> GetAtLeastOneRules()
    {
        var result = new List<string>();
        foreach (var testParameter in AllParameters.Where(x => x.Position != PrimaryItem.Position)) //make sure we do not include the property under test
        {
            if (testParameter.AtLeastOneValidations.Any()) //this is similar to required in that one them needs to be there
            {
                foreach (var validationData in testParameter.AtLeastOneValidations) //we should look to see which of the parameters is not part of the TestParameters and use that. For this one, we can just do FieldName=TestValue
                    result.Add(validationData.FirstFieldPosition); //just add the first field which would satisfy the AtLeastOne rule
            }
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

    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
        return str;
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