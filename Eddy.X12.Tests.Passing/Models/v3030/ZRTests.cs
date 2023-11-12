using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*c*i*R*1*WCkGs5*u*ko*JFouB1*zl*gB*4*w*No";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "c",
			EquipmentInitial = "i",
			EquipmentNumber = "R",
			WaybillNumber = 1,
			Date = "WCkGs5",
			FreeFormMessage = "u",
			StandardCarrierAlphaCode = "ko",
			Date2 = "JFouB1",
			InterlineSettlementSystemStatusActionOrDisputeCode = "zl",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "gB",
			ReferenceNumber = "4",
			ReferenceNumber2 = "w",
			CorrectionIndicator = "No",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "i";
		subject.EquipmentNumber = "R";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "c";
		subject.EquipmentNumber = "R";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "c";
		subject.EquipmentInitial = "i";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
