using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU1*W*4*1*t*s*C*Dk*hZ";

		var expected = new FU1_BracketInformation()
		{
			PriceBracketIdentifier = "W",
			RangeMinimum = 4,
			RangeMaximum = 1,
			AssignedIdentification = "t",
			FreeFormDescription = "s",
			WeightQualifier = "C",
			UnitOrBasisForMeasurementCode = "Dk",
			ConditionIndicator = "hZ",
		};

		var actual = Map.MapObject<FU1_BracketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		//Required fields
		subject.RangeMinimum = 4;
		//Test Parameters
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredRangeMinimum(decimal rangeMinimum, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		//Required fields
		subject.PriceBracketIdentifier = "W";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
