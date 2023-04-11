using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*d*xr*QueNbTZs*B7*3*A*3*G*y*6v*A";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "d",
			IdentificationCode = "xr",
			Date = "QueNbTZs",
			UnitOrBasisForMeasurementCode = "B7",
			Quantity = 3,
			AmountQualifierCode = "A",
			MonetaryAmount = 3,
			ItemDescriptionTypeCode = "G",
			Description = "y",
			ServiceLevelCode = "6v",
			ReportTransmissionCode = "A",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "xr";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xr", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "d";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("B7", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("B7", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "d";
		subject.IdentificationCode = "xr";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("A", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("A", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "d";
		subject.IdentificationCode = "xr";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("G", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("G", "", false)]
	public void Validation_AllAreRequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, string description, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "d";
		subject.IdentificationCode = "xr";
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
