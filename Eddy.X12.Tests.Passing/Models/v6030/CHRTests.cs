using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHR*t*vB*8";

		var expected = new CHR_CarHireRates()
		{
			RateSourceCode = "t",
			BilledRatedAsQualifier = "vB",
			Multiplier = 8,
		};

		var actual = Map.MapObject<CHR_CarHireRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredRateSourceCode(string rateSourceCode, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		//Required fields
		subject.BilledRatedAsQualifier = "vB";
		//Test Parameters
		subject.RateSourceCode = rateSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vB", true)]
	public void Validation_RequiredBilledRatedAsQualifier(string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		//Required fields
		subject.RateSourceCode = "t";
		//Test Parameters
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
