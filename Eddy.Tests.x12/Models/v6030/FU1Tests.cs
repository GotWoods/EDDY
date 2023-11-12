using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class FU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU1*o*6*1*Q*Z*G*Z1*6J";

		var expected = new FU1_BracketInformation()
		{
			PriceBracketIdentifier = "o",
			RangeMinimum = 6,
			RangeMaximum = 1,
			AssignedIdentification = "Q",
			FreeFormDescription = "Z",
			WeightQualifier = "G",
			UnitOrBasisForMeasurementCode = "Z1",
			ConditionIndicatorCode = "6J",
		};

		var actual = Map.MapObject<FU1_BracketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		//Required fields
		subject.RangeMinimum = 6;
		//Test Parameters
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRangeMinimum(decimal rangeMinimum, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		//Required fields
		subject.PriceBracketIdentifier = "o";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
