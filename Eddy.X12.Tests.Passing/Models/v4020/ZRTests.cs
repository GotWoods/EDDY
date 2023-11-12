using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*V*2*j*7*RGmvJshM*1*0q*oKlAX6Rb*VD*kC*r*S*y7*1";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "V",
			EquipmentInitial = "2",
			EquipmentNumber = "j",
			WaybillNumber = 7,
			Date = "RGmvJshM",
			FreeFormMessage = "1",
			StandardCarrierAlphaCode = "0q",
			Date2 = "oKlAX6Rb",
			InterlineSettlementSystemStatusActionOrDisputeCode = "VD",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "kC",
			ReferenceIdentification = "r",
			ReferenceIdentification2 = "S",
			CorrectionIndicator = "y7",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "2";
		subject.EquipmentNumber = "j";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "V";
		subject.EquipmentNumber = "j";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "V";
		subject.EquipmentInitial = "2";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
