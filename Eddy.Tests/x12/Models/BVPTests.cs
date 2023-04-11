using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BVPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVP*X*0*Lh*r*AD*Bl*xA*u*s*TkNvwDL5*dc";

		var expected = new BVP_BeginningSegmentForVehicleShippingOrder()
		{
			VehicleProductionStatus = "X",
			IdentificationCodeQualifier = "0",
			IdentificationCode = "Lh",
			IdentificationCodeQualifier2 = "r",
			IdentificationCode2 = "AD",
			VehicleServiceCode = "Bl",
			StandardCarrierAlphaCode = "xA",
			VehicleStatus = "u",
			ReferenceIdentification = "s",
			Date = "TkNvwDL5",
			TransactionSetPurposeCode = "dc",
		};

		var actual = Map.MapObject<BVP_BeginningSegmentForVehicleShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredVehicleProductionStatus(string vehicleProductionStatus, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		subject.IdentificationCodeQualifier = "0";
		subject.IdentificationCode = "Lh";
		subject.VehicleProductionStatus = vehicleProductionStatus;

        subject.VehicleServiceCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		subject.VehicleProductionStatus = "X";
		subject.IdentificationCode = "Lh";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;

        subject.VehicleServiceCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lh", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		subject.VehicleProductionStatus = "X";
		subject.IdentificationCodeQualifier = "0";
		subject.IdentificationCode = identificationCode;

        subject.VehicleServiceCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("r", "AD", true)]
	[InlineData("", "AD", false)]
	[InlineData("r", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		subject.VehicleProductionStatus = "X";
		subject.IdentificationCodeQualifier = "0";
		subject.IdentificationCode = "Lh";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

        subject.VehicleServiceCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("AD","Bl", true)]
	[InlineData("", "Bl", true)]
	[InlineData("AD", "", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		subject.VehicleProductionStatus = "X";
		subject.IdentificationCodeQualifier = "0";
		subject.IdentificationCode = "Lh";
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;

		if (identificationCode2 != "")
			subject.IdentificationCodeQualifier2 = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
