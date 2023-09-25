using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*E*Y*6*3*omquADk9*D*mi*Xh9ENKX0*oA*0e*r*n*6T";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "E",
			EquipmentInitial = "Y",
			EquipmentNumber = "6",
			WaybillNumber = 3,
			Date = "omquADk9",
			FreeFormMessage = "D",
			StandardCarrierAlphaCode = "mi",
			Date2 = "Xh9ENKX0",
			InterlineSettlementSystemStatusActionOrDisputeCode = "oA",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "0e",
			ReferenceIdentification = "r",
			ReferenceIdentification2 = "n",
			CorrectionIndicator = "6T",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "6";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "E";
		subject.EquipmentNumber = "6";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "E";
		subject.EquipmentInitial = "Y";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
