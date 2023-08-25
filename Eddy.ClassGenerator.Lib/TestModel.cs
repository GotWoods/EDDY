using System.Collections.Generic;
using System.Text;

namespace Eddy.ClassGenerator.Lib;

public class TestModel
{
    public string TestName { get; set; }
    public List<string> Theories { get; set; } = new();
    public string SubjectName { get; set; }
    public List<Model> RequiredTestItems { get; set; } = new();
    public Model PrimaryItem { get; set; }
    public List<Model> TestParameter { get; set; } = new();
    public string ExpectedErrorCode { get; set; }
    public string Generate()
    {
        var sbTest = new StringBuilder();
        sbTest.AppendLine("\t[Theory]");
        foreach (var theory in Theories)
        {
            sbTest.AppendLine(theory);
        }
        sbTest.Append($"\tpublic void {TestName}(");
        foreach (var testParameter in TestParameter)
            sbTest.Append($"{testParameter.DataType.Replace("?", "")} {FirstCharToLowerCase(testParameter.Name)}, "); //can not pass in a nullable with inline data
        
        sbTest.AppendLine("bool isValidExpected)");
        sbTest.AppendLine("\t{");
        sbTest.AppendLine($"\t\tvar subject = new {SubjectName}();");
        foreach (var requiredItem in RequiredTestItems)
        {
            if (requiredItem.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
            else
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");
        }

        foreach (var testParameter in TestParameter)
        {
            // var otherField = FindFieldByPosition(field, items);
            //
            // if (otherField.IsDataTypeNumeric) sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(otherField.Name)} > 0)");
            // sbTest.AppendLine($"\t\tsubject.{otherField.Name} = {FirstCharToLowerCase(otherField.Name)};");
            if (testParameter.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(testParameter.Name)} > 0)");
            sbTest.AppendLine($"\t\tsubject.{testParameter.Name} = {FirstCharToLowerCase(testParameter.Name)};");
        }
        // if (PrimaryItem.IsDataTypeNumeric) 
        //     sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(PrimaryItem.Name)} > 0)");
        // sbTest.AppendLine($"\t\tsubject.{PrimaryItem.Name} = {FirstCharToLowerCase(PrimaryItem.Name)};");
        sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{ExpectedErrorCode});");
        sbTest.AppendLine("\t}");
        return sbTest.ToString();
    }

    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
        return str;
    }
}