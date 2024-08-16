using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCD++y";

		var expected = new PCD_PercentageDetails()
		{
			PercentageDetails = null,
			StatusDescriptionCode = "y",
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
