using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*G4*J*d*z*8*4*M4*M*T";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "G4",
			BillOfLadingWaybillNumber = "J",
			EquipmentInitial = "d",
			EquipmentNumber = "z",
			LocationQualifier = "8",
			LocationIdentifier = "4",
			ReferenceIdentificationQualifier = "M4",
			ReferenceIdentification = "M",
			FreeFormDescription = "T",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.ReferenceIdentificationQualifier = "M4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M4", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "G4";
		subject.BillOfLadingWaybillNumber = "J";
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "4";
		subject.ReferenceIdentificationQualifier = "M4";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
