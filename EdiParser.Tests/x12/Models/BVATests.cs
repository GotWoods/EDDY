using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*RA*vI*l*KL*gcrInKSt*M*o*cv*aF*B*Nm*GVp*d*cXZjiC8f*a*x06zG5cu*L*X*j*PR*8*Z*sj*2*th";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "RA",
			StandardCarrierAlphaCode = "vI",
			IdentificationCodeQualifier = "l",
			IdentificationCode = "KL",
			Date = "gcrInKSt",
			InvoiceNumber = "M",
			IdentificationCodeQualifier2 = "o",
			IdentificationCode2 = "cv",
			VehicleServiceCode = "aF",
			IdentificationCodeQualifier3 = "B",
			IdentificationCode3 = "Nm",
			CurrencyCode = "GVp",
			LadingDescriptionQualifier = "d",
			Date2 = "cXZjiC8f",
			ReferenceIdentification = "a",
			Date3 = "x06zG5cu",
			CheckNumber = "L",
			EquipmentInitial = "X",
			EquipmentNumber = "j",
			EquipmentDescriptionCode = "PR",
			Quantity = 8,
			ShipmentIdentificationNumber = "Z",
			FlightVoyageNumber = "sj",
			VehicleStatus = "2",
			TransactionSetPurposeCode = "th",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RA", true)]
	public void Validatation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.PaymentTypeCode = paymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vI", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KL", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.Date = "gcrInKSt";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gcrInKSt", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("o", "cv", true)]
	[InlineData("", "cv", false)]
	[InlineData("o", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("cv","aF", true)]
	[InlineData("", "aF", true)]
	[InlineData("cv", "", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("B", "Nm", true)]
	[InlineData("", "Nm", false)]
	[InlineData("B", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		subject.PaymentTypeCode = "RA";
		subject.StandardCarrierAlphaCode = "vI";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "KL";
		subject.Date = "gcrInKSt";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
