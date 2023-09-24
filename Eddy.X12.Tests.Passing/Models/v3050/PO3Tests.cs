using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PO3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO3*bp*7cIMT8*wt1*2*pN*4*US*Q";

		var expected = new PO3_AdditionalItemDetail()
		{
			ChangeReasonCode = "bp",
			Date = "7cIMT8",
			PriceIdentifierCode = "wt1",
			UnitPrice = 2,
			BasisOfUnitPriceCode = "pN",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "US",
			Description = "Q",
		};

		var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bp", true)]
	public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "US";
		subject.ChangeReasonCode = changeReasonCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 2;
			subject.PriceIdentifierCode = "wt1";
			subject.BasisOfUnitPriceCode = "pN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(2, "wt1", "pN", true)]
	[InlineData(2, "", "", false)]
	[InlineData(0, "wt1", "pN", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitPrice(decimal unitPrice, string priceIdentifierCode, string basisOfUnitPriceCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "bp";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "US";
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
		subject.ChangeReasonCode = "bp";
		subject.UnitOrBasisForMeasurementCode = "US";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 2;
			subject.PriceIdentifierCode = "wt1";
			subject.BasisOfUnitPriceCode = "pN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("US", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "bp";
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 2;
			subject.PriceIdentifierCode = "wt1";
			subject.BasisOfUnitPriceCode = "pN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
