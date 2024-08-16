using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class ASDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ASD+++d";

		var expected = new ASD_ServiceDetails()
		{
			AdditionalServiceDetails = null,
			DateAndTimeInformation = null,
			DaysOfWeekSetIdentifier = "d",
		};

		var actual = Map.MapObject<ASD_ServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAdditionalServiceDetails(string additionalServiceDetails, bool isValidExpected)
	{
		var subject = new ASD_ServiceDetails();
		//Required fields
		//Test Parameters
		if (additionalServiceDetails != "") 
			subject.AdditionalServiceDetails = new E959_AdditionalServiceDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
