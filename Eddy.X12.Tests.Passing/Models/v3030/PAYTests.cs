using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*m*4*8*8*6*4*gS*9*t9*2*5*1*1*z*6*4*7*I*3*7*3*r";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			PaymentAdjustmentCode = "m",
			MonetaryAmount = 4,
			Percent = 8,
			MonetaryAmount2 = 8,
			Percent2 = 6,
			MonetaryAmount3 = 4,
			UnitOrBasisForMeasurementCode = "gS",
			Quantity = 9,
			UnitOrBasisForMeasurementCode2 = "t9",
			Quantity2 = 2,
			Percent3 = 5,
			Percent4 = 1,
			MonetaryAmount4 = 1,
			YesNoConditionOrResponseCode = "z",
			Quantity3 = 6,
			Percent5 = 4,
			MonetaryAmount5 = 7,
			NegativeAmortizationQualifier = "I",
			Percent6 = 3,
			MonetaryAmount6 = 7,
			NegativeAmoritzationCapSourceCode = "3",
			YesNoConditionOrResponseCode2 = "r",
		};

		var actual = Map.MapObject<PAY_AdjustablePaymentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredPaymentAdjustmentCode(string paymentAdjustmentCode, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.PaymentAdjustmentCode = paymentAdjustmentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gS";
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "t9";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gS", 9, true)]
	[InlineData("gS", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		subject.PaymentAdjustmentCode = "m";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "t9";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t9", 2, true)]
	[InlineData("t9", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		subject.PaymentAdjustmentCode = "m";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gS";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
