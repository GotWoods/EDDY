using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCD+";

		var expected = new PCD_PercentageDetails()
		{
			PercentageDetails = null,
		};

		var actual = Map.MapObject<PCD_PercentageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPercentageDetails(string percentageDetails, bool isValidExpected)
	{
		var subject = new PCD_PercentageDetails();
		//Required fields
		//Test Parameters
		if (percentageDetails != "") 
			subject.PercentageDetails = new C501_PercentageDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
