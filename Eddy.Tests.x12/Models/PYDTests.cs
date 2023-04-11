using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PYDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PYD*8*z*d*Y*Z";

		var expected = new PYD_PayrollDeduction()
		{
			MonetaryAmount = 8,
			FrequencyCode = "z",
			TaxTreatmentCode = "d",
			DeductionTypeCode = "Y",
			Description = "Z",
		};

		var actual = Map.MapObject<PYD_PayrollDeduction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PYD_PayrollDeduction();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
