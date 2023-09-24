using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*v*yYiHZf*8*n*TXzF*71";

		var expected = new P4_USPortInformation()
		{
			LocationIdentifier = "v",
			Date = "yYiHZf",
			Quantity = 8,
			LocationIdentifier2 = "n",
			Time = "TXzF",
			Century = 71,
		};

		var actual = Map.MapObject<P4_USPortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_USPortInformation();
		subject.Date = "yYiHZf";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yYiHZf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new P4_USPortInformation();
		subject.LocationIdentifier = "v";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
