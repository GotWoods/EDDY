using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BVPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVP*j*1*kA*R*Wf*HG*O3*w*a*R0VaIo*GM";

		var expected = new BVP_BeginningSegmentForVehicleShippingOrder()
		{
			VehicleProductionStatus = "j",
			IdentificationCodeQualifier = "1",
			IdentificationCode = "kA",
			IdentificationCodeQualifier2 = "R",
			IdentificationCode2 = "Wf",
			VehicleServiceCode = "HG",
			StandardCarrierAlphaCode = "O3",
			VehicleStatus = "w",
			ReferenceNumber = "a",
			Date = "R0VaIo",
			TransactionSetPurposeCode = "GM",
		};

		var actual = Map.MapObject<BVP_BeginningSegmentForVehicleShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredVehicleProductionStatus(string vehicleProductionStatus, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "kA";
		//Test Parameters
		subject.VehicleProductionStatus = vehicleProductionStatus;
		//At Least one
		subject.IdentificationCode2 = "Wf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "R";
			subject.IdentificationCode2 = "Wf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "j";
		subject.IdentificationCode = "kA";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "Wf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "R";
			subject.IdentificationCode2 = "Wf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kA", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "j";
		subject.IdentificationCodeQualifier = "1";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "Wf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "R";
			subject.IdentificationCode2 = "Wf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "Wf", true)]
	[InlineData("R", "", false)]
	[InlineData("", "Wf", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "j";
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "kA";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "HG";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Wf", "HG", true)]
	[InlineData("Wf", "", true)]
	[InlineData("", "HG", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "j";
		subject.IdentificationCodeQualifier = "1";
		subject.IdentificationCode = "kA";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "R";
			subject.IdentificationCode2 = "Wf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
