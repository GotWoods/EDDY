using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BVSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVS*Su*z*7f*7*uC*g*p*O*RS*K*u*p";

		var expected = new BVS_BeginningSegmentForVehicleService()
		{
			StandardCarrierAlphaCode = "Su",
			IdentificationCodeQualifier = "z",
			IdentificationCode = "7f",
			Quantity = 7,
			VehicleServiceCode = "uC",
			VehicleStatus = "g",
			InvoiceNumber = "p",
			IdentificationCodeQualifier2 = "O",
			IdentificationCode2 = "RS",
			BillOfLadingWaybillNumber = "K",
			AccountNumber = "u",
			ReferenceIdentification = "p",
		};

		var actual = Map.MapObject<BVS_BeginningSegmentForVehicleService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("Su", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		subject.IdentificationCodeQualifier = "z";
		subject.IdentificationCode = "7f";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		subject.StandardCarrierAlphaCode = "Su";
		subject.IdentificationCode = "7f";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7f", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		subject.StandardCarrierAlphaCode = "Su";
		subject.IdentificationCodeQualifier = "z";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("O", "RS", true)]
	[InlineData("", "RS", false)]
	[InlineData("O", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		subject.StandardCarrierAlphaCode = "Su";
		subject.IdentificationCodeQualifier = "z";
		subject.IdentificationCode = "7f";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
