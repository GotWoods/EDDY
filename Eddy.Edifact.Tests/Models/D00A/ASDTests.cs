using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ASDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ASD+++I";

		var expected = new ASD_ServiceDetails()
		{
			ServiceDateTimeLocationInformation = null,
			DateAndTimeInformation = null,
			DaysOfWeekSetIdentifier = "I",
		};

		var actual = Map.MapObject<ASD_ServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredServiceDateTimeLocationInformation(string serviceDateTimeLocationInformation, bool isValidExpected)
	{
		var subject = new ASD_ServiceDetails();
		//Required fields
		//Test Parameters
		if (serviceDateTimeLocationInformation != "") 
			subject.ServiceDateTimeLocationInformation = new E959_ServiceDateTimeLocationInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
