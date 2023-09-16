using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*5*y7HWgy*1";

		var expected = new P4_PortOfDischargeInformation()
		{
			LocationIdentifier = "5",
			ETADate = "y7HWgy",
			Quantity = 1,
		};

		var actual = Map.MapObject<P4_PortOfDischargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_PortOfDischargeInformation();
		subject.ETADate = "y7HWgy";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y7HWgy", true)]
	public void Validation_RequiredETADate(string eTADate, bool isValidExpected)
	{
		var subject = new P4_PortOfDischargeInformation();
		subject.LocationIdentifier = "5";
		subject.ETADate = eTADate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
