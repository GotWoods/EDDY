using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*SG*i*k*9*8*j*OA*o*2";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "SG",
			BillOfLadingWaybillNumber = "i",
			EquipmentInitial = "k",
			EquipmentNumber = "9",
			LocationQualifier = "8",
			LocationIdentifier = "j",
			ReferenceIdentificationQualifier = "OA",
			ReferenceIdentification = "o",
			FreeFormDescription = "2",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SG", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
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
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.ReferenceIdentificationQualifier = "OA";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OA", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "SG";
		subject.BillOfLadingWaybillNumber = "i";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "8";
		subject.LocationIdentifier = "j";
		subject.ReferenceIdentificationQualifier = "OA";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
