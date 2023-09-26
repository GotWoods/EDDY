using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*6p*z*E*4*5*v*mE*m*c*9";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "6p",
			BillOfLadingWaybillNumber = "z",
			EquipmentInitial = "E",
			EquipmentNumber = "4",
			LocationQualifier = "5",
			LocationIdentifier = "v",
			ReferenceIdentificationQualifier = "mE",
			ReferenceIdentification = "m",
			FreeFormDescription = "c",
			EquipmentNumberCheckDigit = 9,
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6p", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.ReferenceIdentificationQualifier = "mE";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mE", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "6p";
		subject.BillOfLadingWaybillNumber = "z";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "4";
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "v";
		subject.ReferenceIdentificationQualifier = "mE";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
