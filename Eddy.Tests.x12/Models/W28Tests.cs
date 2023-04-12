using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W28*B*9*9*H*8*p*z*i";

		var expected = new W28_ConsolidationInformation()
		{
			ConsolidationCode = "B",
			Weight = 9,
			WeightQualifier = "9",
			WeightUnitCode = "H",
			TotalStopOffs = 8,
			LocationIdentifier = "p",
			LocationQualifier = "z",
			BillOfLadingWaybillNumber = "i",
		};

		var actual = Map.MapObject<W28_ConsolidationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredConsolidationCode(string consolidationCode, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		subject.ConsolidationCode = consolidationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		subject.ConsolidationCode = "B";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
