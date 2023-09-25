using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W28*t*2*U*i*7*u*h*K";

		var expected = new W28_ConsolidationInformation()
		{
			ConsolidationCode = "t",
			Weight = 2,
			WeightQualifier = "U",
			WeightUnitCode = "i",
			TotalStopoffs = 7,
			LocationIdentifier = "u",
			LocationQualifier = "h",
			MasterBillOfLadingNumber = "K",
		};

		var actual = Map.MapObject<W28_ConsolidationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredConsolidationCode(string consolidationCode, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "u";
			subject.LocationQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "h", true)]
	[InlineData("u", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		subject.ConsolidationCode = "t";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
