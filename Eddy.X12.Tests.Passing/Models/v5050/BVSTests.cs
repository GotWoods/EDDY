using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class BVSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVS*50*i*CZ*1*ZP*G*j*r*Bn*f*s*l";

		var expected = new BVS_BeginningSegmentForVehicleService()
		{
			StandardCarrierAlphaCode = "50",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "CZ",
			Quantity = 1,
			VehicleServiceCode = "ZP",
			VehicleStatus = "G",
			InvoiceNumber = "j",
			IdentificationCodeQualifier2 = "r",
			IdentificationCode2 = "Bn",
			BillOfLadingWaybillNumber = "f",
			AccountNumber = "s",
			ReferenceIdentification = "l",
		};

		var actual = Map.MapObject<BVS_BeginningSegmentForVehicleService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("50", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.IdentificationCodeQualifier = "i";
		subject.IdentificationCode = "CZ";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "r";
			subject.IdentificationCode2 = "Bn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "50";
		subject.IdentificationCode = "CZ";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "r";
			subject.IdentificationCode2 = "Bn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CZ", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "50";
		subject.IdentificationCodeQualifier = "i";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "r";
			subject.IdentificationCode2 = "Bn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "Bn", true)]
	[InlineData("r", "", false)]
	[InlineData("", "Bn", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "50";
		subject.IdentificationCodeQualifier = "i";
		subject.IdentificationCode = "CZ";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
