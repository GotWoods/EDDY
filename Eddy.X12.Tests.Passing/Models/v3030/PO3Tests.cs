using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PO3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO3*wT*HkwZ9x*UK2*3*QT*4*5E*2";

		var expected = new PO3_AdditionalItemDetail()
		{
			ChangeReasonCode = "wT",
			Date = "HkwZ9x",
			PriceIdentifierCode = "UK2",
			UnitPrice = 3,
			BasisOfUnitPriceCode = "QT",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "5E",
			Description = "2",
		};

		var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wT", true)]
	public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "5E";
		subject.ChangeReasonCode = changeReasonCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 3;
			subject.PriceIdentifierCode = "UK2";
			subject.BasisOfUnitPriceCode = "QT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(3, "UK2", "QT", true)]
	[InlineData(3, "", "", false)]
	[InlineData(0, "UK2", "QT", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitPrice(decimal unitPrice, string priceIdentifierCode, string basisOfUnitPriceCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "wT";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "5E";
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		subject.PriceIdentifierCode = priceIdentifierCode;
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "wT";
		subject.UnitOrBasisForMeasurementCode = "5E";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 3;
			subject.PriceIdentifierCode = "UK2";
			subject.BasisOfUnitPriceCode = "QT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5E", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "wT";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 3;
			subject.PriceIdentifierCode = "UK2";
			subject.BasisOfUnitPriceCode = "QT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
