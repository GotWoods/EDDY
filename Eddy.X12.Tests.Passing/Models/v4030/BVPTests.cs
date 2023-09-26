using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BVPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVP*y*M*ZH*V*jR*Ib*Z4*t*D*xozIAPK0*VS";

		var expected = new BVP_BeginningSegmentForVehicleShippingOrder()
		{
			VehicleProductionStatus = "y",
			IdentificationCodeQualifier = "M",
			IdentificationCode = "ZH",
			IdentificationCodeQualifier2 = "V",
			IdentificationCode2 = "jR",
			VehicleServiceCode = "Ib",
			StandardCarrierAlphaCode = "Z4",
			VehicleStatus = "t",
			ReferenceIdentification = "D",
			Date = "xozIAPK0",
			TransactionSetPurposeCode = "VS",
		};

		var actual = Map.MapObject<BVP_BeginningSegmentForVehicleShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredVehicleProductionStatus(string vehicleProductionStatus, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "M";
		subject.IdentificationCode = "ZH";
		//Test Parameters
		subject.VehicleProductionStatus = vehicleProductionStatus;
		//At Least one
		subject.IdentificationCode2 = "jR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "jR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "y";
		subject.IdentificationCode = "ZH";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//At Least one
		subject.IdentificationCode2 = "jR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "jR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZH", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "y";
		subject.IdentificationCodeQualifier = "M";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.IdentificationCode2 = "jR";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "jR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "jR", true)]
	[InlineData("V", "", false)]
	[InlineData("", "jR", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "y";
		subject.IdentificationCodeQualifier = "M";
		subject.IdentificationCode = "ZH";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		//At Least one
		subject.VehicleServiceCode = "Ib";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("jR", "Ib", true)]
	[InlineData("jR", "", true)]
	[InlineData("", "Ib", true)]
	public void Validation_AtLeastOneIdentificationCode2(string identificationCode2, string vehicleServiceCode, bool isValidExpected)
	{
		var subject = new BVP_BeginningSegmentForVehicleShippingOrder();
		//Required fields
		subject.VehicleProductionStatus = "y";
		subject.IdentificationCodeQualifier = "M";
		subject.IdentificationCode = "ZH";
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		subject.VehicleServiceCode = vehicleServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "V";
			subject.IdentificationCode2 = "jR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
