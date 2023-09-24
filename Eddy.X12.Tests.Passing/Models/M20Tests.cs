using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*Mx*d*r*1*B*d*iw*C*E*3*7";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "Mx",
			BillOfLadingWaybillNumber = "d",
			EquipmentInitial = "r",
			EquipmentNumber = "1",
			LocationQualifier = "B",
			LocationIdentifier = "d",
			ReferenceIdentificationQualifier = "iw",
			ReferenceIdentification = "C",
			FreeFormDescription = "E",
			EquipmentNumberCheckDigit = 3,
			Quantity = 7,
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mx", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = "C";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iw", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentification = "C";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		subject.StandardCarrierAlphaCode = "Mx";
		subject.BillOfLadingWaybillNumber = "d";
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "1";
		subject.LocationQualifier = "B";
		subject.LocationIdentifier = "d";
		subject.ReferenceIdentificationQualifier = "iw";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
