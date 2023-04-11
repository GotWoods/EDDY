using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C055Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "z*m*I*3*b*b*B*F";

        var expected = new C055_TaxServiceNonPaymentExceptionCode()
        {
            TaxServiceNonPaymentCode = "z",
            TaxServiceNonPaymentCode2 = "m",
            TaxServiceNonPaymentCode3 = "I",
            TaxServiceNonPaymentCode4 = "3",
            TaxServiceNonPaymentCode5 = "b",
            TaxServiceNonPaymentCode6 = "b",
            TaxServiceNonPaymentCode7 = "B",
            TaxServiceNonPaymentCode8 = "F",
        };

        var actual = Map.MapObject<C055_TaxServiceNonPaymentExceptionCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("z", true)]
    public void Validation_RequiredTaxServiceNonPaymentCode(string taxServiceNonPaymentCode, bool isValidExpected)
    {
        var subject = new C055_TaxServiceNonPaymentExceptionCode();
        subject.TaxServiceNonPaymentCode = taxServiceNonPaymentCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}