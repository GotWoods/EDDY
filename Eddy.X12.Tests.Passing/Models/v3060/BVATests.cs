using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*NX*CU*o*IY*oOfPwX*f*4*rV*wX*a*Q6*mgK*5*YibAS9*q*eEiIJr*T*j*G*vH*5*6*DD*6*jr";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "NX",
			StandardCarrierAlphaCode = "CU",
			IdentificationCodeQualifier = "o",
			IdentificationCode = "IY",
			Date = "oOfPwX",
			InvoiceNumber = "f",
			IdentificationCodeQualifier2 = "4",
			IdentificationCode2 = "rV",
			VehicleServiceCode = "wX",
			IdentificationCodeQualifier3 = "a",
			IdentificationCode3 = "Q6",
			CurrencyCode = "mgK",
			LadingDescriptionQualifier = "5",
			Date2 = "YibAS9",
			ReferenceIdentification = "q",
			Date3 = "eEiIJr",
			CheckNumber = "T",
			EquipmentInitial = "j",
			EquipmentNumber = "G",
			EquipmentDescriptionCode = "vH",
			Quantity = 5,
			ShipmentIdentificationNumber = "6",
			FlightVoyageNumber = "DD",
			VehicleStatus = "6",
			TransactionSetPurposeCode = "jr",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NX", true)]
	public void Validation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.PaymentTypeCode = paymentTypeCode;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CU", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IY", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oOfPwX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "rV", true)]
	[InlineData("4", "", false)]
	[InlineData("", "rV", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "wX";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("rV", "wX", true)]
	[InlineData("rV", "", true)]
	[InlineData("", "wX", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "a";
			subject.IdentificationCode3 = "Q6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "Q6", true)]
	[InlineData("a", "", false)]
	[InlineData("", "Q6", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "NX";
		subject.StandardCarrierAlphaCode = "CU";
		subject.IdentificationCodeQualifier = "o";
		subject.IdentificationCode = "IY";
		subject.Date = "oOfPwX";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//At Least one
		subject.IdentificationCode2 = "rV";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "4";
			subject.IdentificationCode2 = "rV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
