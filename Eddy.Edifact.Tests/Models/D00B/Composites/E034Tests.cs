using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E034Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:X";

		var expected = new E034_TimeZone()
		{
			TimeZoneIdentifier = "J",
			TimeZoneDifferenceValue = "X",
		};

		var actual = Map.MapComposite<E034_TimeZone>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredTimeZoneIdentifier(string timeZoneIdentifier, bool isValidExpected)
	{
		var subject = new E034_TimeZone();
		//Required fields
		//Test Parameters
		subject.TimeZoneIdentifier = timeZoneIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
