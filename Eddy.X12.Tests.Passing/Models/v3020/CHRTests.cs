using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHR*h*oV*3";

		var expected = new CHR_CarHireRates()
		{
			RateSource = "h",
			BilledRatedAsQualifier = "oV",
			Multiplier = 3,
		};

		var actual = Map.MapObject<CHR_CarHireRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRateSource(string rateSource, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		//Required fields
		subject.BilledRatedAsQualifier = "oV";
		//Test Parameters
		subject.RateSource = rateSource;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oV", true)]
	public void Validation_RequiredBilledRatedAsQualifier(string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new CHR_CarHireRates();
		//Required fields
		subject.RateSource = "h";
		//Test Parameters
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
