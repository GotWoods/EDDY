using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*MO*li*p*wg*6GrPCEB0*W*2*2T*EO*c*xR*7Tt*I*F730IIQJ*Q*EKuLiNXt*u*K*H*hr*3*V*Qf*d*0k";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "MO",
			StandardCarrierAlphaCode = "li",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "wg",
			Date = "6GrPCEB0",
			InvoiceNumber = "W",
			IdentificationCodeQualifier2 = "2",
			IdentificationCode2 = "2T",
			VehicleServiceCode = "EO",
			IdentificationCodeQualifier3 = "c",
			IdentificationCode3 = "xR",
			CurrencyCode = "7Tt",
			LadingDescriptionQualifier = "I",
			Date2 = "F730IIQJ",
			ReferenceIdentification = "Q",
			Date3 = "EKuLiNXt",
			CheckNumber = "u",
			EquipmentInitial = "K",
			EquipmentNumber = "H",
			EquipmentDescriptionCode = "hr",
			Quantity = 3,
			ShipmentIdentificationNumber = "V",
			FlightVoyageNumber = "Qf",
			VehicleStatus = "d",
			TransactionSetPurposeCode = "0k",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MO", true)]
	public void Validation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.PaymentTypeCode = paymentTypeCode;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("li", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wg", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6GrPCEB0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "2T", true)]
	[InlineData("2", "", false)]
	[InlineData("", "2T", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "EO";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2T", "EO", true)]
	[InlineData("2T", "", true)]
	[InlineData("", "EO", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "c";
			subject.IdentificationCode3 = "xR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "xR", true)]
	[InlineData("c", "", false)]
	[InlineData("", "xR", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "MO";
		subject.StandardCarrierAlphaCode = "li";
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = "wg";
		subject.Date = "6GrPCEB0";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//At Least one
		subject.IdentificationCode2 = "2T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "2";
			subject.IdentificationCode2 = "2T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
