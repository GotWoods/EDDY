using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*Y*Zs*0fSAro*1U*2*v*4*u*t*Lb*0x";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "Y",
			IdentificationCode = "Zs",
			Date = "0fSAro",
			UnitOrBasisForMeasurementCode = "1U",
			Quantity = 2,
			AmountQualifierCode = "v",
			MonetaryAmount = 4,
			ItemDescriptionType = "u",
			Description = "t",
			ServiceLevelCode = "Lb",
			ReportTransmissionCode = "0x",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "Zs";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1U";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "v";
			subject.MonetaryAmount = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "u";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zs", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "Y";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1U";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "v";
			subject.MonetaryAmount = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "u";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1U", 2, true)]
	[InlineData("1U", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "Y";
		subject.IdentificationCode = "Zs";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "v";
			subject.MonetaryAmount = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "u";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("v", 4, true)]
	[InlineData("v", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "Y";
		subject.IdentificationCode = "Zs";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1U";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "u";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "t", true)]
	[InlineData("u", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredItemDescriptionType(string itemDescriptionType, string description, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "Y";
		subject.IdentificationCode = "Zs";
		subject.ItemDescriptionType = itemDescriptionType;
		subject.Description = description;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1U";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "v";
			subject.MonetaryAmount = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
