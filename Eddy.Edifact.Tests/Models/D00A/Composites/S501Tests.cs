using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S501Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "m:a:s:mgVn";

		var expected = new S501_SecurityDateAndTime()
		{
			DateAndTimeQualifier = "m",
			EventDate = "a",
			EventTime = "s",
			TimeOffset = "mgVn",
		};

		var actual = Map.MapComposite<S501_SecurityDateAndTime>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDateAndTimeQualifier(string dateAndTimeQualifier, bool isValidExpected)
	{
		var subject = new S501_SecurityDateAndTime();
		//Required fields
		//Test Parameters
		subject.DateAndTimeQualifier = dateAndTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
