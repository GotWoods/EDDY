using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C055Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "h*K*N*B*Q*9*v*b";

		var expected = new C055_TaxServiceNonPaymentExceptionCode()
		{
			TaxServiceNonPaymentCode = "h",
			TaxServiceNonPaymentCode2 = "K",
			TaxServiceNonPaymentCode3 = "N",
			TaxServiceNonPaymentCode4 = "B",
			TaxServiceNonPaymentCode5 = "Q",
			TaxServiceNonPaymentCode6 = "9",
			TaxServiceNonPaymentCode7 = "v",
			TaxServiceNonPaymentCode8 = "b",
		};

		var actual = Map.MapObject<C055_TaxServiceNonPaymentExceptionCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredTaxServiceNonPaymentCode(string taxServiceNonPaymentCode, bool isValidExpected)
	{
		var subject = new C055_TaxServiceNonPaymentExceptionCode();
		//Required fields
		//Test Parameters
		subject.TaxServiceNonPaymentCode = taxServiceNonPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
