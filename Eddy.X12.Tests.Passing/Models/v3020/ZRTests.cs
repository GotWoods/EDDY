using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*7*1*j*4*V4aqW3*0*ip*hUiKCw";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillRequestResponseCode = "7",
			EquipmentInitial = "1",
			EquipmentNumber = "j",
			WaybillNumber = 4,
			Date = "V4aqW3",
			FreeFormMessage = "0",
			StandardCarrierAlphaCode = "ip",
			Date2 = "hUiKCw",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredWaybillRequestResponseCode(string waybillRequestResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "j";
		//Test Parameters
		subject.WaybillRequestResponseCode = waybillRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillRequestResponseCode = "7";
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
		subject.WaybillRequestResponseCode = "7";
		subject.EquipmentInitial = "1";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
