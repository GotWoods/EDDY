using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*1*mf*R3HGpC*nw*2*w*5*q*z";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "1",
			IdentificationCode = "mf",
			Date = "R3HGpC",
			UnitOfMeasurementCode = "nw",
			Quantity = 2,
			AmountQualifierCode = "w",
			MonetaryAmount = 5,
			ItemDescriptionType = "q",
			Description = "z",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "mf";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "nw";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "w";
			subject.MonetaryAmount = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "q";
			subject.Description = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mf", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "nw";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "w";
			subject.MonetaryAmount = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "q";
			subject.Description = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("nw", 2, true)]
	[InlineData("nw", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "mf";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "w";
			subject.MonetaryAmount = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "q";
			subject.Description = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 5, true)]
	[InlineData("w", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "mf";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "nw";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.ItemDescriptionType = "q";
			subject.Description = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "z", true)]
	[InlineData("q", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredItemDescriptionType(string itemDescriptionType, string description, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "mf";
		subject.ItemDescriptionType = itemDescriptionType;
		subject.Description = description;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "nw";
			subject.Quantity = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "w";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
