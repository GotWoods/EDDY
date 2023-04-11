using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHR*G*0u*4";

		var expected = new CHR_CarHireRates()
		{
			RateSourceCode = "G",
			BilledRatedAsQualifier = "0u",
			Multiplier = 4,
		};

		var actual = Map.MapObject<CHR_CarHireRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRateSourceCode(string rateSourceCode, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		subject.BilledRatedAsQualifier = "0u";
		subject.RateSourceCode = rateSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0u", true)]
	public void Validation_RequiredBilledRatedAsQualifier(string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		subject.RateSourceCode = "G";
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
