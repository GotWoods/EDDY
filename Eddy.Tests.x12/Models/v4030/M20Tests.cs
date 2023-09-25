using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*LG*7*P*x*f*Z*6R*a*p";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "LG",
			BillOfLadingWaybillNumber = "7",
			EquipmentInitial = "P",
			EquipmentNumber = "x",
			LocationQualifier = "f",
			LocationIdentifier = "Z",
			ReferenceIdentificationQualifier = "6R",
			ReferenceIdentification = "a",
			FreeFormDescription = "p",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LG", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.ReferenceIdentificationQualifier = "6R";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6R", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "LG";
		subject.BillOfLadingWaybillNumber = "7";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "x";
		subject.LocationQualifier = "f";
		subject.LocationIdentifier = "Z";
		subject.ReferenceIdentificationQualifier = "6R";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
