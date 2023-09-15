using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*v*zp*BrxyLMRk*6j*6*C*9*J*p*cZ*n";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "v",
			IdentificationCode = "zp",
			Date = "BrxyLMRk",
			UnitOrBasisForMeasurementCode = "6j",
			Quantity = 6,
			AmountQualifierCode = "C",
			MonetaryAmount = 9,
			ItemDescriptionTypeCode = "J",
			Description = "p",
			ServiceLevelCode = "cZ",
			ReportTransmissionCode = "n",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "zp";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "6j";
			subject.Quantity = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "C";
			subject.MonetaryAmount = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionTypeCode = "J";
			subject.Description = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zp", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "v";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "6j";
			subject.Quantity = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "C";
			subject.MonetaryAmount = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionTypeCode = "J";
			subject.Description = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6j", 6, true)]
	[InlineData("6j", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "v";
		subject.IdentificationCode = "zp";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "C";
			subject.MonetaryAmount = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionTypeCode = "J";
			subject.Description = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 9, true)]
	[InlineData("C", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "v";
		subject.IdentificationCode = "zp";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "6j";
			subject.Quantity = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionTypeCode = "J";
			subject.Description = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "p", true)]
	[InlineData("J", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, string description, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "v";
		subject.IdentificationCode = "zp";
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		subject.Description = description;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "6j";
			subject.Quantity = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "C";
			subject.MonetaryAmount = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
