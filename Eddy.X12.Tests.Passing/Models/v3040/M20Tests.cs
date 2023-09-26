using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*xR*c*H*8*e*M*Hg*b*a";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "xR",
			BillOfLadingWaybillNumber = "c",
			EquipmentInitial = "H",
			EquipmentNumber = "8",
			LocationQualifier = "e",
			LocationIdentifier = "M",
			ReferenceNumberQualifier = "Hg",
			ReferenceNumber = "b",
			FreeFormDescription = "a",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xR", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
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
		subject.StandardCarrierAlphaCode = "xR";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
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
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.ReferenceNumberQualifier = "Hg";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hg", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "xR";
		subject.BillOfLadingWaybillNumber = "c";
		subject.EquipmentInitial = "H";
		subject.EquipmentNumber = "8";
		subject.LocationQualifier = "e";
		subject.LocationIdentifier = "M";
		subject.ReferenceNumberQualifier = "Hg";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
