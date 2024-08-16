using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class TIZTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TIZ+";

		var expected = new TIZ_TimeZoneInformation()
		{
			TimeZone = null,
		};

		var actual = Map.MapObject<TIZ_TimeZoneInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTimeZone(string timeZone, bool isValidExpected)
	{
		var subject = new TIZ_TimeZoneInformation();
		//Required fields
		//Test Parameters
		if (timeZone != "") 
			subject.TimeZone = new E034_TimeZone();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
