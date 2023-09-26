using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class G95Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G95*t2*sL*6*7*MJ*l*7";

		var expected = new G95_PerformanceRequirements()
		{
			PromotionConditionQualifier = "t2",
			PromotionConditionCode = "sL",
			AssignedNumber = 6,
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "MJ",
			Description = "l",
			Number = 7,
		};

		var actual = Map.MapObject<G95_PerformanceRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sL", true)]
	public void Validation_RequiredPromotionConditionCode(string promotionConditionCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		//Test Parameters
		subject.PromotionConditionCode = promotionConditionCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 7;
			subject.UnitOrBasisForMeasurementCode = "MJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "MJ", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "MJ", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G95_PerformanceRequirements();
		//Required fields
		subject.PromotionConditionCode = "sL";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
