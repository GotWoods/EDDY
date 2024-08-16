using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class RTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RTE+";

		var expected = new RTE_RateDetails()
		{
			RateDetails = null,
		};

		var actual = Map.MapObject<RTE_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredRateDetails(string rateDetails, bool isValidExpected)
	{
		var subject = new RTE_RateDetails();
		//Required fields
		//Test Parameters
		if (rateDetails != "") 
			subject.RateDetails = new C128_RateDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
