using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*gZ*D*2*Q*a*G*Vi*c*s";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "gZ",
			BillOfLadingWaybillNumber = "D",
			EquipmentInitial = "2",
			EquipmentNumber = "Q",
			LocationQualifier = "a",
			LocationIdentifier = "G",
			ReferenceNumberQualifier = "Vi",
			ReferenceNumber = "c",
			FreeFormDescription = "s",
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.ReferenceNumberQualifier = "Vi";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vi", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumber = "c";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "gZ";
		subject.BillOfLadingWaybillNumber = "D";
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "Q";
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "G";
		subject.ReferenceNumberQualifier = "Vi";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
