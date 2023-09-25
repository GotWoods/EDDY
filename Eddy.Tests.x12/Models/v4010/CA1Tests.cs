using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CA1*3*4";

		var expected = new CA1_RateRequestIdentifier()
		{
			RateRequestID = 3,
			RateResponseSuffix = 4,
		};

		var actual = Map.MapObject<CA1_RateRequestIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredRateRequestID(int rateRequestID, bool isValidExpected)
	{
		var subject = new CA1_RateRequestIdentifier();
		//Required fields
		//Test Parameters
		if (rateRequestID > 0) 
			subject.RateRequestID = rateRequestID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
