using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G95Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G95*uL*UK*6*9*om*C";

		var expected = new G95_PerformanceRequirements()
		{
			PromotionConditionQualifier = "uL",
			PromotionConditionCode = "UK",
			AssignedNumber = 6,
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "om",
			FreeFormMessage = "C",
		};

		var actual = Map.MapObject<G95_PerformanceRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uL", true)]
	public void Validation_RequiredPromotionConditionQualifier(string promotionConditionQualifier, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		subject.PromotionConditionCode = "UK";
		//Test Parameters
		subject.PromotionConditionQualifier = promotionConditionQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 9;
			subject.UnitOrBasisForMeasurementCode = "om";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UK", true)]
	public void Validation_RequiredPromotionConditionCode(string promotionConditionCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		subject.PromotionConditionQualifier = "uL";
		//Test Parameters
		subject.PromotionConditionCode = promotionConditionCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 9;
			subject.UnitOrBasisForMeasurementCode = "om";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "om", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "om", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		subject.PromotionConditionQualifier = "uL";
		subject.PromotionConditionCode = "UK";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
