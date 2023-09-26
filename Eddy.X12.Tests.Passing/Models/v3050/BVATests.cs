using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*Rl*wb*B*ML*81ttgk*q*H*Pf*cF*t*IP*fU7*X*b6Tt7G*C*Mr8Wii*M*l*L*AF*9*A*2q*z*zd";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "Rl",
			StandardCarrierAlphaCode = "wb",
			IdentificationCodeQualifier = "B",
			IdentificationCode = "ML",
			Date = "81ttgk",
			InvoiceNumber = "q",
			IdentificationCodeQualifier2 = "H",
			IdentificationCode2 = "Pf",
			VehicleServiceCode = "cF",
			IdentificationCodeQualifier3 = "t",
			IdentificationCode3 = "IP",
			CurrencyCode = "fU7",
			LadingDescriptionQualifier = "X",
			Date2 = "b6Tt7G",
			ReferenceNumber = "C",
			Date3 = "Mr8Wii",
			CheckNumber = "M",
			EquipmentInitial = "l",
			EquipmentNumber = "L",
			EquipmentDescriptionCode = "AF",
			Quantity = 9,
			ShipmentIdentificationNumber = "A",
			FlightVoyageNumber = "2q",
			VehicleStatus = "z",
			TransactionSetPurposeCode = "zd",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rl", true)]
	public void Validation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.PaymentTypeCode = paymentTypeCode;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ML", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("81ttgk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "Pf", true)]
	[InlineData("H", "", false)]
	[InlineData("", "Pf", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "cF";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Pf", "cF", true)]
	[InlineData("Pf", "", true)]
	[InlineData("", "cF", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "t";
			subject.IdentificationCode3 = "IP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "IP", true)]
	[InlineData("t", "", false)]
	[InlineData("", "IP", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "Rl";
		subject.StandardCarrierAlphaCode = "wb";
		subject.IdentificationCodeQualifier = "B";
		subject.IdentificationCode = "ML";
		subject.Date = "81ttgk";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//At Least one
		subject.IdentificationCode2 = "Pf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "H";
			subject.IdentificationCode2 = "Pf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
