using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class M20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M20*eO*a*e*9*n*F*ql*E*x*7*4";

		var expected = new M20_PermitToTransferRequestDetails()
		{
			StandardCarrierAlphaCode = "eO",
			BillOfLadingWaybillNumber = "a",
			EquipmentInitial = "e",
			EquipmentNumber = "9",
			LocationQualifier = "n",
			LocationIdentifier = "F",
			ReferenceIdentificationQualifier = "ql",
			ReferenceIdentification = "E",
			FreeFormDescription = "x",
			EquipmentNumberCheckDigit = 7,
			Quantity = 4,
		};

		var actual = Map.MapObject<M20_PermitToTransferRequestDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eO", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
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
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.ReferenceIdentificationQualifier = "ql";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ql", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new M20_PermitToTransferRequestDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "eO";
		subject.BillOfLadingWaybillNumber = "a";
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "9";
		subject.LocationQualifier = "n";
		subject.LocationIdentifier = "F";
		subject.ReferenceIdentificationQualifier = "ql";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
