using Eddy.Core.Validation;
using Eddy.Edifact.Models.D21A.Composites;
using Xunit.Abstractions;
using static System.String;

namespace Eddy.Edifact.Tests;

public class Investigator
{
    private readonly ITestOutputHelper _outputHelper;

    public Investigator(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void GetS001BaseType()
    {
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D21A.Composites.S001_SyntaxIdentifier)).FullName);
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D99A.Composites.S001_SyntaxIdentifier)).FullName);
        
    }

    [Fact]
    public void GetS002BaseType()
    {
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D21A.Composites.S002_InterchangeSender)).FullName);
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D99A.Composites.S002_InterchangeSender)).FullName);

    }

    [Fact]
    public void GetS003BaseType()
    {
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D21A.Composites.S003_InterchangeRecipient)).FullName);
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D99A.Composites.S003_InterchangeRecipient)).FullName);

    }


    [Fact]
    public void GetS004BaseType()
    {
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D21A.Composites.S004_DateAndTimeOfPreparation)).FullName);
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D99A.Composites.S004_DateTimeOfPreparation)).FullName);

    }

    [Fact]
    public void GetS005BaseType()
    {
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D21A.Composites.S005_RecipientReferencePasswordDetails)).FullName);
        _outputHelper.WriteLine(GetRootBaseType(typeof(Eddy.Edifact.Models.D99A.Composites.S005_RecipientsReferencePassword)).FullName);

    }


    public Type GetRootBaseType(Type type)
    {
        Type baseType = type.BaseType;

        while (baseType != null && baseType != typeof(object) && baseType != typeof(EdifactSegment) && baseType!=typeof(EdifactComponent))
        {
            type = baseType;
            baseType = type.BaseType;
        }

        return type;
    }
}
public static class TestHelper
{
    public static void CheckValidationResults(EdifactSegment subject, bool isValidExpected, ErrorCodes expectedErrorCode)
    {
        var validationResult = subject.Validate();
        if (isValidExpected)
        {
            Assert.True(validationResult.IsValid, validationResult.ToString());
        }
        else
        {
            Assert.False(validationResult.IsValid, validationResult.ToString());
            // if (validationResult.Errors.Count > 1)
            // {
            //     Assert.Fail(validationResult.ToString());
            //     return;
            // }

            foreach (var error in validationResult.Errors)
            {
                if (error.ErrorCode != expectedErrorCode) //the first non match will fail
                {
                    Assert.Fail("Expected " + expectedErrorCode.Message + " but actual error was: " + Format(error.ErrorCode.Message, error.Data));
                    //Assert.Equal(expectedErrorCode, error.ErrorCode);
                }
            }

            //Assert.Equal(expectedErrorCode, validationResult.Errors[0].ErrorCode);
        }
    }
}
