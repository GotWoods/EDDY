using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BVSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVS*vQ*5*7m*9*5l*o*l*c*Fl*0*q*y";

		var expected = new BVS_BeginningSegmentForVehicleService()
		{
			StandardCarrierAlphaCode = "vQ",
			IdentificationCodeQualifier = "5",
			IdentificationCode = "7m",
			Quantity = 9,
			VehicleServiceCode = "5l",
			VehicleStatus = "o",
			InvoiceNumber = "l",
			IdentificationCodeQualifier2 = "c",
			IdentificationCode2 = "Fl",
			BillOfLadingWaybillNumber = "0",
			AccountNumber = "q",
			ReferenceIdentification = "y",
		};

		var actual = Map.MapObject<BVS_BeginningSegmentForVehicleService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.IdentificationCodeQualifier = "5";
		subject.IdentificationCode = "7m";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "c";
			subject.IdentificationCode2 = "Fl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "vQ";
		subject.IdentificationCode = "7m";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "c";
			subject.IdentificationCode2 = "Fl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7m", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "vQ";
		subject.IdentificationCodeQualifier = "5";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "c";
			subject.IdentificationCode2 = "Fl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "Fl", true)]
	[InlineData("c", "", false)]
	[InlineData("", "Fl", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "vQ";
		subject.IdentificationCodeQualifier = "5";
		subject.IdentificationCode = "7m";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
