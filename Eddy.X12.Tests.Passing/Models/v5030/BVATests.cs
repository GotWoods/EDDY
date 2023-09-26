using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*rd*2f*I*jF*qJTSsBvV*G*q*tC*mX*L*2I*wpd*W*WT3AEGaw*z*BxkXrBbC*s*L*O*Hv*4*T*uX*B*61";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "rd",
			StandardCarrierAlphaCode = "2f",
			IdentificationCodeQualifier = "I",
			IdentificationCode = "jF",
			Date = "qJTSsBvV",
			InvoiceNumber = "G",
			IdentificationCodeQualifier2 = "q",
			IdentificationCode2 = "tC",
			VehicleServiceCode = "mX",
			IdentificationCodeQualifier3 = "L",
			IdentificationCode3 = "2I",
			CurrencyCode = "wpd",
			LadingDescriptionQualifier = "W",
			Date2 = "WT3AEGaw",
			ReferenceIdentification = "z",
			Date3 = "BxkXrBbC",
			CheckNumber = "s",
			EquipmentInitial = "L",
			EquipmentNumber = "O",
			EquipmentDescriptionCode = "Hv",
			Quantity = 4,
			ShipmentIdentificationNumber = "T",
			FlightVoyageNumber = "uX",
			VehicleStatus = "B",
			TransactionSetPurposeCode = "61",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rd", true)]
	public void Validation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.PaymentTypeCode = paymentTypeCode;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2f", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jF", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qJTSsBvV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "tC", true)]
	[InlineData("q", "", false)]
	[InlineData("", "tC", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "mX";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("tC", "mX", true)]
	[InlineData("tC", "", true)]
	[InlineData("", "mX", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "L";
			subject.IdentificationCode3 = "2I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "2I", true)]
	[InlineData("L", "", false)]
	[InlineData("", "2I", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "rd";
		subject.StandardCarrierAlphaCode = "2f";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "jF";
		subject.Date = "qJTSsBvV";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//At Least one
		subject.IdentificationCode2 = "tC";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "q";
			subject.IdentificationCode2 = "tC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
