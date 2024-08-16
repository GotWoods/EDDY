using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E034Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:L";

		var expected = new E034_TimeZone()
		{
			TimeZoneIdentifier = "h",
			TimeZoneDifferenceQuantity = "L",
		};

		var actual = Map.MapComposite<E034_TimeZone>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredTimeZoneIdentifier(string timeZoneIdentifier, bool isValidExpected)
	{
		var subject = new E034_TimeZone();
		//Required fields
		//Test Parameters
		subject.TimeZoneIdentifier = timeZoneIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
