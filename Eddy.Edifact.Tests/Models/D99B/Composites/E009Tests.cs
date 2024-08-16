using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:j";

		var expected = new E009_DailyAvailabilityInformation()
		{
			DateValue = "q",
			RequestedInformationDescription = "j",
		};

		var actual = Map.MapComposite<E009_DailyAvailabilityInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredDateValue(string dateValue, bool isValidExpected)
	{
		var subject = new E009_DailyAvailabilityInformation();
		//Required fields
		//Test Parameters
		subject.DateValue = dateValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
