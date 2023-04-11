using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G95Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G95*IS*DV*8*5*kz*l*8";

		var expected = new G95_PerformanceRequirements()
		{
			PromotionConditionQualifier = "IS",
			PromotionConditionCode = "DV",
			AssignedNumber = 8,
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "kz",
			Description = "l",
			Number = 8,
		};

		var actual = Map.MapObject<G95_PerformanceRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DV", true)]
	public void Validation_RequiredPromotionConditionCode(string promotionConditionCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		subject.PromotionConditionCode = promotionConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "kz", true)]
	[InlineData(0, "kz", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		subject.PromotionConditionCode = "DV";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
