using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*8*W*9*1*4DFfWA*s*wu*njFwbA*VF*ur*S*5*3M";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "8",
			EquipmentInitial = "W",
			EquipmentNumber = "9",
			WaybillNumber = 1,
			Date = "4DFfWA",
			FreeFormMessage = "s",
			StandardCarrierAlphaCode = "wu",
			Date2 = "njFwbA",
			InterlineSettlementSystemStatusActionOrDisputeCode = "VF",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "ur",
			ReferenceIdentification = "S",
			ReferenceIdentification2 = "5",
			CorrectionIndicator = "3M",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "9";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentNumber = "9";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentInitial = "W";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
