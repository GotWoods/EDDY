using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C028Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "5Y*7*Kq*h*JW*n*3k*z*zZ*Z*7c*q*QC*L*CF*z*YV*l*rK*t";

        var expected = new C028_AssuranceTokenParameters()
        {
            AssuranceTokenParameterCode = "5Y",
            AssuranceTokenParameterValue = "7",
            AssuranceTokenParameterCode2 = "Kq",
            AssuranceTokenParameterValue2 = "h",
            AssuranceTokenParameterCode3 = "JW",
            AssuranceTokenParameterValue3 = "n",
            AssuranceTokenParameterCode4 = "3k",
            AssuranceTokenParameterValue4 = "z",
            AssuranceTokenParameterCode5 = "zZ",
            AssuranceTokenParameterValue5 = "Z",
            AssuranceTokenParameterCode6 = "7c",
            AssuranceTokenParameterValue6 = "q",
            AssuranceTokenParameterCode7 = "QC",
            AssuranceTokenParameterValue7 = "L",
            AssuranceTokenParameterCode8 = "CF",
            AssuranceTokenParameterValue8 = "z",
            AssuranceTokenParameterCode9 = "YV",
            AssuranceTokenParameterValue9 = "l",
            AssuranceTokenParameterCode10 = "rK",
            AssuranceTokenParameterValue10 = "t",
        };

        var actual = Map.MapObject<C028_AssuranceTokenParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5Y", true)]
    public void Validatation_RequiredAssuranceTokenParameterCode(string assuranceTokenParameterCode, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterCode = assuranceTokenParameterCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("7", true)]
    public void Validatation_RequiredAssuranceTokenParameterValue(string assuranceTokenParameterValue, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = assuranceTokenParameterValue;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "Kq", true)]
    [InlineData("h", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue2(string assuranceTokenParameterValue2, string assuranceTokenParameterCode2, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue2 = assuranceTokenParameterValue2;
        subject.AssuranceTokenParameterCode2 = assuranceTokenParameterCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "JW", true)]
    [InlineData("n", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue3(string assuranceTokenParameterValue3, string assuranceTokenParameterCode3, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue3 = assuranceTokenParameterValue3;
        subject.AssuranceTokenParameterCode3 = assuranceTokenParameterCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "3k", true)]
    [InlineData("z", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue4(string assuranceTokenParameterValue4, string assuranceTokenParameterCode4, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue4 = assuranceTokenParameterValue4;
        subject.AssuranceTokenParameterCode4 = assuranceTokenParameterCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "zZ", true)]
    [InlineData("Z", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue5(string assuranceTokenParameterValue5, string assuranceTokenParameterCode5, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue5 = assuranceTokenParameterValue5;
        subject.AssuranceTokenParameterCode5 = assuranceTokenParameterCode5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "7c", true)]
    [InlineData("q", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue6(string assuranceTokenParameterValue6, string assuranceTokenParameterCode6, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue6 = assuranceTokenParameterValue6;
        subject.AssuranceTokenParameterCode6 = assuranceTokenParameterCode6;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "QC", true)]
    [InlineData("L", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue7(string assuranceTokenParameterValue7, string assuranceTokenParameterCode7, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue7 = assuranceTokenParameterValue7;
        subject.AssuranceTokenParameterCode7 = assuranceTokenParameterCode7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "CF", true)]
    [InlineData("z", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue8(string assuranceTokenParameterValue8, string assuranceTokenParameterCode8, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue8 = assuranceTokenParameterValue8;
        subject.AssuranceTokenParameterCode8 = assuranceTokenParameterCode8;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "YV", true)]
    [InlineData("l", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue9(string assuranceTokenParameterValue9, string assuranceTokenParameterCode9, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue9 = assuranceTokenParameterValue9;
        subject.AssuranceTokenParameterCode9 = assuranceTokenParameterCode9;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "rK", true)]
    [InlineData("t", "", false)]
    public void Validation_ARequiresBAssuranceTokenParameterValue10(string assuranceTokenParameterValue10, string assuranceTokenParameterCode10, bool isValidExpected)
    {
        var subject = new C028_AssuranceTokenParameters();
        subject.AssuranceTokenParameterCode = "5Y";
        subject.AssuranceTokenParameterValue = "7";
        subject.AssuranceTokenParameterValue10 = assuranceTokenParameterValue10;
        subject.AssuranceTokenParameterCode10 = assuranceTokenParameterCode10;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}