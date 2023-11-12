using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BVPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVP*1*N*hn*B*lS*b4*qH*q*s*3sHh7AXy*FU";

		var expected = new BVP_BeginningSegmentForVehicleShippingOrder()
		{
			VehicleProductionStatus = "1",
			IdentificationCodeQualifier = "N",
			IdentificationCode = "hn",
			IdentificationCodeQualifier2 = "B",
			IdentificationCode2 = "lS",
			VehicleServiceCode = "b4",
			StandardCarrierAlphaCode = "qH",
			VehicleStatus = "q",
			ReferenceIdentification = "s",
			Date = "3sHh7AXy",
			TransactionSetPurposeCode = "FU",
		};

		var actual = Map.MapObject<BVP_BeginningSegmentForVehicleShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredVehicleProductionStatus(string vehicleProductionStatus, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "N";
		subject.IdentificationCode = "hn";
		//Test Parameters
		subject.VehicleProductionStatus = vehicleProductionStatus;
		//At Least one
		subject.IdentificationCode2 = "lS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "B";
			subject.IdentificationCode2 = "lS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "1";
		subject.IdentificationCode = "hn";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "lS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "B";
			subject.IdentificationCode2 = "lS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hn", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "1";
		subject.IdentificationCodeQualifier = "N";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "lS";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "B";
			subject.IdentificationCode2 = "lS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "lS", true)]
	[InlineData("B", "", false)]
	[InlineData("", "lS", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "1";
		subject.IdentificationCodeQualifier = "N";
		subject.IdentificationCode = "hn";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "b4";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("lS", "b4", true)]
	[InlineData("lS", "", true)]
	[InlineData("", "b4", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "1";
		subject.IdentificationCodeQualifier = "N";
		subject.IdentificationCode = "hn";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "B";
			subject.IdentificationCode2 = "lS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
