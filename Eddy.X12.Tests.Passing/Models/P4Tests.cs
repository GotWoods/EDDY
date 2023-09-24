using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*H*8LSKn5nj*3*Z*I0TY*ywMf7QEp*EaVN";

		var expected = new P4_PortInformation()
		{
			LocationIdentifier = "H",
			Date = "8LSKn5nj",
			Quantity = 3,
			LocationIdentifier2 = "Z",
			Time = "I0TY",
			Date2 = "ywMf7QEp",
			Time2 = "EaVN",
		};

		var actual = Map.MapObject<P4_PortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_PortInformation();
		subject.Date = "8LSKn5nj";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8LSKn5nj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new P4_PortInformation();
		subject.LocationIdentifier = "H";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
