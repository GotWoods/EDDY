using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class RTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RTC+f";

		var expected = new RTC_RateTypes()
		{
			RateTypeIdentifier = "f",
		};

		var actual = Map.MapObject<RTC_RateTypes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredRateTypeIdentifier(string rateTypeIdentifier, bool isValidExpected)
	{
		var subject = new RTC_RateTypes();
		//Required fields
		//Test Parameters
		subject.RateTypeIdentifier = rateTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
