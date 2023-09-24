using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*u*xoL4eLnF*7*2*do0u";

		var expected = new P4_USPortInformation()
		{
			LocationIdentifier = "u",
			Date = "xoL4eLnF",
			Quantity = 7,
			LocationIdentifier2 = "2",
			Time = "do0u",
		};

		var actual = Map.MapObject<P4_USPortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_USPortInformation();
		subject.Date = "xoL4eLnF";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xoL4eLnF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new P4_USPortInformation();
		subject.LocationIdentifier = "u";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
