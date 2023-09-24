using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU1*u*3*5*a*l*j*H2*Tw";

		var expected = new FU1_BracketInformation()
		{
			PriceBracketIdentifier = "u",
			RangeMinimum = 3,
			RangeMaximum = 5,
			AssignedIdentification = "a",
			FreeFormDescription = "l",
			WeightQualifier = "j",
			UnitOrBasisForMeasurementCode = "H2",
			ConditionIndicatorCode = "Tw",
		};

		var actual = Map.MapObject<FU1_BracketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		subject.RangeMinimum = 3;
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredRangeMinimum(decimal rangeMinimum, bool isValidExpected)
	{
		var subject = new FU1_BracketInformation();
		subject.PriceBracketIdentifier = "u";
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
