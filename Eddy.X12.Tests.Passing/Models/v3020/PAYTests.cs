using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*4*9*8*9*2*Tk*1*EE*8*2*4*1*d*8*6*9*q*5*5*Y*c";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			MonetaryAmount = 4,
			Percent = 9,
			MonetaryAmount2 = 8,
			Percent2 = 9,
			MonetaryAmount3 = 2,
			UnitOfMeasurementCode = "Tk",
			Quantity = 1,
			UnitOfMeasurementCode2 = "EE",
			Quantity2 = 8,
			Percent3 = 2,
			Percent4 = 4,
			MonetaryAmount4 = 1,
			YesNoConditionOrResponseCode = "d",
			Percent5 = 8,
			Quantity3 = 6,
			MonetaryAmount5 = 9,
			NegativeAmortizationQualifier = "q",
			Percent6 = 5,
			MonetaryAmount6 = 5,
			NegativeAmoritzationCapSourceCode = "Y",
			YesNoConditionOrResponseCode2 = "c",
		};

		var actual = Map.MapObject<PAY_AdjustablePaymentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Tk", 1, true)]
	[InlineData("Tk", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOfMeasurementCode2 = "EE";
			subject.Quantity2 = 8;
		}
		if(subject.Quantity3 > 0 || subject.Quantity3 > 0 || subject.MonetaryAmount5 > 0)
		{
			subject.Quantity3 = 6;
			subject.MonetaryAmount5 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("EE", 8, true)]
	[InlineData("EE", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "Tk";
			subject.Quantity = 1;
		}
		if(subject.Quantity3 > 0 || subject.Quantity3 > 0 || subject.MonetaryAmount5 > 0)
		{
			subject.Quantity3 = 6;
			subject.MonetaryAmount5 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 9, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 9, false)]
	public void Validation_AllAreRequiredQuantity3(decimal quantity3, decimal monetaryAmount5, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "Tk";
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.Quantity2 > 0)
		{
			subject.UnitOfMeasurementCode2 = "EE";
			subject.Quantity2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
