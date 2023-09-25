using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W28*g*3*S*2*8*N*3*V";

		var expected = new W28_ConsolidationInformation()
		{
			ConsolidationCode = "g",
			Weight = 3,
			WeightQualifier = "S",
			WeightUnitCode = "2",
			TotalStopoffs = 8,
			LocationIdentifier = "N",
			LocationQualifier = "3",
			MasterBillOfLadingNumber = "V",
		};

		var actual = Map.MapObject<W28_ConsolidationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredConsolidationCode(string consolidationCode, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "N";
			subject.LocationQualifier = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "3", true)]
	[InlineData("N", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		subject.ConsolidationCode = "g";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
