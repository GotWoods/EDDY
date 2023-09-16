using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class P4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P4*X*43gcuF*6";

		var expected = new P4_PortOfDischargeInformation()
		{
			LocationIdentifier = "X",
			ETADate = "43gcuF",
			Quantity = 6,
		};

		var actual = Map.MapObject<P4_PortOfDischargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P4_PortOfDischargeInformation();
		subject.ETADate = "43gcuF";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("43gcuF", true)]
	public void Validation_RequiredETADate(string eTADate, bool isValidExpected)
	{
		var subject = new P4_PortOfDischargeInformation();
		subject.LocationIdentifier = "X";
		subject.ETADate = eTADate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
