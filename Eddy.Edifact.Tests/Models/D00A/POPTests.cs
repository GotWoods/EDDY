using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class POPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "POP++b+m";

		var expected = new POP_PeriodOfOperation()
		{
			DateAndTimeInformation = null,
			DaysOfWeekSetIdentifier = "b",
			StatusDescriptionCode = "m",
		};

		var actual = Map.MapObject<POP_PeriodOfOperation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateAndTimeInformation(string dateAndTimeInformation, bool isValidExpected)
	{
		var subject = new POP_PeriodOfOperation();
		//Required fields
		//Test Parameters
		if (dateAndTimeInformation != "") 
			subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
