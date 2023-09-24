using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PO3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO3*jj*Uvt77p*DfV*5*pW*3*Bv*5";

		var expected = new PO3_AdditionalItemDetail()
		{
			ChangeReasonCode = "jj",
			Date = "Uvt77p",
			PriceIdentifierCode = "DfV",
			UnitPrice = 5,
			BasisOfUnitPriceCode = "pW",
			Quantity = 3,
			UnitOfMeasurementCode = "Bv",
			Description = "5",
		};

		var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
	public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = "Bv";
		subject.ChangeReasonCode = changeReasonCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 5;
			subject.PriceIdentifierCode = "DfV";
			subject.BasisOfUnitPriceCode = "pW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(5, "DfV", "pW", true)]
	[InlineData(5, "", "", false)]
	[InlineData(0, "DfV", "pW", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitPrice(decimal unitPrice, string priceIdentifierCode, string basisOfUnitPriceCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "jj";
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = "Bv";
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		subject.PriceIdentifierCode = priceIdentifierCode;
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "jj";
		subject.UnitOfMeasurementCode = "Bv";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 5;
			subject.PriceIdentifierCode = "DfV";
			subject.BasisOfUnitPriceCode = "pW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bv", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "jj";
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, at least one more is required
		if(subject.UnitPrice > 0 || subject.UnitPrice > 0 || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.BasisOfUnitPriceCode))
		{
			subject.UnitPrice = 5;
			subject.PriceIdentifierCode = "DfV";
			subject.BasisOfUnitPriceCode = "pW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
