using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G95Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G95*9c*Jb*6*3*3F*U*4";

		var expected = new G95_PerformanceRequirements()
		{
			PromotionConditionQualifier = "9c",
			PromotionConditionCode = "Jb",
			AssignedNumber = 6,
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "3F",
			Description = "U",
			Number = 4,
		};

		var actual = Map.MapObject<G95_PerformanceRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredPromotionConditionCode(string promotionConditionCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		//Test Parameters
		subject.PromotionConditionCode = promotionConditionCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 3;
			subject.UnitOrBasisForMeasurementCode = "3F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "3F", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "3F", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		subject.PromotionConditionCode = "Jb";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
