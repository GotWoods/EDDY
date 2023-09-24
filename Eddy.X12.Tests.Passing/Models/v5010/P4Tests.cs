using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*o*rIG3AFJN*8*y*BwFl*jhfWXDGc*ORbH";

		var expected = new P4_PortInformation()
		{
			LocationIdentifier = "o",
			Date = "rIG3AFJN",
			Quantity = 8,
			LocationIdentifier2 = "y",
			Time = "BwFl",
			Date2 = "jhfWXDGc",
			Time2 = "ORbH",
		};

		var actual = Map.MapObject<P4_PortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_PortInformation();
		subject.Date = "rIG3AFJN";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rIG3AFJN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new P4_PortInformation();
		subject.LocationIdentifier = "o";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
