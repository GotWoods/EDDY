using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PO3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO3*f8*asXiSkbK*wca*4*4V*4*mj*G";

		var expected = new PO3_AdditionalItemDetail()
		{
			ChangeReasonCode = "f8",
			Date = "asXiSkbK",
			PriceIdentifierCode = "wca",
			UnitPrice = 4,
			BasisOfUnitPriceCode = "4V",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "mj",
			Description = "G",
		};

		var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f8", true)]
	public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "mj";
		subject.ChangeReasonCode = changeReasonCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 4;
			subject.PriceIdentifierCode = "wca";
			subject.BasisOfUnitPriceCode = "4V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(4, "wca", "4V", true)]
	[InlineData(4, "", "", false)]
	[InlineData(0, "wca", "4V", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitPrice(decimal unitPrice, string priceIdentifierCode, string basisOfUnitPriceCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "f8";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "mj";
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
		subject.ChangeReasonCode = "f8";
		subject.UnitOrBasisForMeasurementCode = "mj";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 4;
			subject.PriceIdentifierCode = "wca";
			subject.BasisOfUnitPriceCode = "4V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mj", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "f8";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 4;
			subject.PriceIdentifierCode = "wca";
			subject.BasisOfUnitPriceCode = "4V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
