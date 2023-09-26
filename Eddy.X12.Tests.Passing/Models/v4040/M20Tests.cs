using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*rx*I*i*a*Z*J*Dn*o*0";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "rx",
			BillOfLadingWaybillNumber = "I",
			EquipmentInitial = "i",
			EquipmentNumber = "a",
			LocationQualifier = "Z",
			LocationIdentifier = "J",
			ReferenceIdentificationQualifier = "Dn",
			ReferenceIdentification = "o",
			FreeFormDescription = "0",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rx", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.ReferenceIdentificationQualifier = "Dn";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dn", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
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
		subject.StandardCarrierAlphaCode = "rx";
		subject.BillOfLadingWaybillNumber = "I";
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "a";
		subject.LocationQualifier = "Z";
		subject.LocationIdentifier = "J";
		subject.ReferenceIdentificationQualifier = "Dn";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
