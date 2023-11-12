using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*u*71*LBaWHA*ow*5*B*3*Q*T*Pc*x";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "u",
			IdentificationCode = "71",
			Date = "LBaWHA",
			UnitOrBasisForMeasurementCode = "ow",
			Quantity = 5,
			AmountQualifierCode = "B",
			MonetaryAmount = 3,
			ItemDescriptionType = "Q",
			Description = "T",
			ServiceLevelCode = "Pc",
			ReportTransmissionCode = "x",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "71";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ow";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "B";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "Q";
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("71", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ow";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "B";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "Q";
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ow", 5, true)]
	[InlineData("ow", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = "71";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "B";
			subject.MonetaryAmount = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "Q";
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 3, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = "71";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ow";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "Q";
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "T", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredItemDescriptionType(string itemDescriptionType, string description, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "u";
		subject.IdentificationCode = "71";
		subject.ItemDescriptionType = itemDescriptionType;
		subject.Description = description;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ow";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "B";
			subject.MonetaryAmount = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
