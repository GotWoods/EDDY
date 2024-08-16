using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class RTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RTC+X";

		var expected = new RTC_RateTypes()
		{
			RateTypeIdentification = "X",
		};

		var actual = Map.MapObject<RTC_RateTypes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRateTypeIdentification(string rateTypeIdentification, bool isValidExpected)
	{
		var subject = new RTC_RateTypes();
		//Required fields
		//Test Parameters
		subject.RateTypeIdentification = rateTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
