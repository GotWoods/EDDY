using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*oL*y*s*8*3*P*2Z*2*6";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "oL",
			BillOfLadingWaybillNumber = "y",
			EquipmentInitial = "s",
			EquipmentNumber = "8",
			LocationQualifier = "3",
			LocationIdentifier = "P",
			ReferenceIdentificationQualifier = "2Z",
			ReferenceIdentification = "2",
			FreeFormDescription = "6",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oL", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.ReferenceIdentificationQualifier = "2Z";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2Z", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "oL";
		subject.BillOfLadingWaybillNumber = "y";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "P";
		subject.ReferenceIdentificationQualifier = "2Z";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
