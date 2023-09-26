using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BVSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVS*Mq*T*nj*5*3l*A*1*y*dH*o*X*O";

		var expected = new BVS_BeginningSegmentForVehicleService()
		{
			StandardCarrierAlphaCode = "Mq",
			IdentificationCodeQualifier = "T",
			IdentificationCode = "nj",
			Quantity = 5,
			VehicleServiceCode = "3l",
			VehicleStatus = "A",
			InvoiceNumber = "1",
			IdentificationCodeQualifier2 = "y",
			IdentificationCode2 = "dH",
			BillOfLadingWaybillNumber = "o",
			AccountNumber = "X",
			ReferenceIdentification = "O",
		};

		var actual = Map.MapObject<BVS_BeginningSegmentForVehicleService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mq", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.IdentificationCodeQualifier = "T";
		subject.IdentificationCode = "nj";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "dH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "Mq";
		subject.IdentificationCode = "nj";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "dH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nj", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "Mq";
		subject.IdentificationCodeQualifier = "T";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier2) || !string.IsNullOrEmpty(subject.IdentificationCode2))
		{
			subject.IdentificationCodeQualifier2 = "y";
			subject.IdentificationCode2 = "dH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "dH", true)]
	[InlineData("y", "", false)]
	[InlineData("", "dH", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BVS_BeginningSegmentForVehicleService();
		//Required fields
		subject.StandardCarrierAlphaCode = "Mq";
		subject.IdentificationCodeQualifier = "T";
		subject.IdentificationCode = "nj";
		//Test Parameters
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
