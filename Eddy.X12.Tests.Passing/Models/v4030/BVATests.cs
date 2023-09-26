using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVA*AL*BZ*I*N3*SzJlS2YV*Q*w*qQ*kN*f*Dc*87S*m*THFiEfMU*i*6a9MEsde*j*N*u*A2*8*W*Nb*4*FT";

		var expected = new BVA_BeginningVehicleAdvice()
		{
			PaymentTypeCode = "AL",
			StandardCarrierAlphaCode = "BZ",
			IdentificationCodeQualifier = "I",
			IdentificationCode = "N3",
			Date = "SzJlS2YV",
			InvoiceNumber = "Q",
			IdentificationCodeQualifier2 = "w",
			IdentificationCode2 = "qQ",
			VehicleServiceCode = "kN",
			IdentificationCodeQualifier3 = "f",
			IdentificationCode3 = "Dc",
			CurrencyCode = "87S",
			LadingDescriptionQualifier = "m",
			Date2 = "THFiEfMU",
			ReferenceIdentification = "i",
			Date3 = "6a9MEsde",
			CheckNumber = "j",
			EquipmentInitial = "N",
			EquipmentNumber = "u",
			EquipmentDescriptionCode = "A2",
			Quantity = 8,
			ShipmentIdentificationNumber = "W",
			FlightVoyageNumber = "Nb",
			VehicleStatus = "4",
			TransactionSetPurposeCode = "FT",
		};

		var actual = Map.MapObject<BVA_BeginningVehicleAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AL", true)]
	public void Validation_RequiredPaymentTypeCode(string paymentTypeCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.PaymentTypeCode = paymentTypeCode;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
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
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N3", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SzJlS2YV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "qQ", true)]
	[InlineData("w", "", false)]
	[InlineData("", "qQ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "kN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("qQ", "kN", true)]
	[InlineData("qQ", "", true)]
	[InlineData("", "kN", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier3) || !string.IsNullOrEmpty(subject.IdentificationCode3))
		{
			subject.IdentificationCodeQualifier3 = "f";
			subject.IdentificationCode3 = "Dc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "Dc", true)]
	[InlineData("f", "", false)]
	[InlineData("", "Dc", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BVA_BeginningVehicleAdvice();
		//Required fields
		subject.PaymentTypeCode = "AL";
		subject.StandardCarrierAlphaCode = "BZ";
		subject.IdentificationCodeQualifier = "I";
		subject.IdentificationCode = "N3";
		subject.Date = "SzJlS2YV";
		//Test Parameters
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;
		//At Least one
		subject.IdentificationCode2 = "qQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "w";
			subject.IdentificationCode2 = "qQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
