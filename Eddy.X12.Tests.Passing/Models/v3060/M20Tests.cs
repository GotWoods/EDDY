using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*1l*c*a*z*h*l*D6*V*Z";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "1l",
			BillOfLadingWaybillNumber = "c",
			EquipmentInitial = "a",
			EquipmentNumber = "z",
			LocationQualifier = "h",
			LocationIdentifier = "l",
			ReferenceIdentificationQualifier = "D6",
			ReferenceIdentification = "V",
			FreeFormDescription = "Z",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1l", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
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
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.ReferenceIdentificationQualifier = "D6";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D6", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentification = "V";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "1l";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "z";
		subject.LocationQualifier = "h";
		subject.LocationIdentifier = "l";
		subject.ReferenceIdentificationQualifier = "D6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
