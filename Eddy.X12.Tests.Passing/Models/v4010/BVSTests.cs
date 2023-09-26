using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BVSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVS*gI*e*Hc*1*GF*r*c*V*nC*r*M*f";

		var expected = new BVS_BeginningSegmentForVehicleService()
		{
			StandardCarrierAlphaCode = "gI",
			IdentificationCodeQualifier = "e",
			IdentificationCode = "Hc",
			Quantity = 1,
			VehicleServiceCode = "GF",
			VehicleStatus = "r",
			InvoiceNumber = "c",
			IdentificationCodeQualifier2 = "V",
			IdentificationCode2 = "nC",
			BillOfLadingWaybillNumber = "r",
			AccountNumber = "M",
			ReferenceIdentification = "f",
		};

		var actual = Map.MapObject<BVS_BeginningSegmentForVehicleService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gI", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = "Hc";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "nC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "gI";
		subject.IdentificationCode = "Hc";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "nC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hc", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "gI";
		subject.IdentificationCodeQualifier = "e";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "nC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "nC", true)]
	[InlineData("V", "", false)]
	[InlineData("", "nC", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "gI";
		subject.IdentificationCodeQualifier = "e";
		subject.IdentificationCode = "Hc";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
