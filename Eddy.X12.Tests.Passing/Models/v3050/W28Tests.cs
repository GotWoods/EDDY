using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W28*L*1*n*J*1*i*B*m";

		var expected = new W28_ConsolidationInformation()
		{
			ConsolidationCode = "L",
			Weight = 1,
			WeightQualifier = "n",
			WeightUnitCode = "J",
			TotalStopoffs = 1,
			LocationIdentifier = "i",
			LocationQualifier = "B",
			BillOfLadingWaybillNumber = "m",
		};

		var actual = Map.MapObject<W28_ConsolidationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredConsolidationCode(string consolidationCode, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "i";
			subject.LocationQualifier = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "B", true)]
	[InlineData("i", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		subject.ConsolidationCode = "L";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
