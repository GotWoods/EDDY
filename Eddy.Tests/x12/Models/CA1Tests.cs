using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CA1*6*4";

		var expected = new CA1_RateRequestIdentifier()
		{
			RateRequestID = 6,
			RateResponseSuffix = 4,
		};

		var actual = Map.MapObject<CA1_RateRequestIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredRateRequestID(int rateRequestID, bool isValidExpected)
	{
		var subject = new CA1_RateRequestIdentifier();
		if (rateRequestID > 0)
		subject.RateRequestID = rateRequestID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
