using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*B*h*5*4*qO1OpG*t";

		var expected = new ZR_WaybillRequestResponseInformation()
		{
			WaybillRequestResponseCode = "B",
			EquipmentInitial = "h",
			EquipmentNumber = "5",
			WaybillNumber = 4,
			Date = "qO1OpG",
			FreeFormMessage = "t",
		};

		var actual = Map.MapObject<ZR_WaybillRequestResponseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredWaybillRequestResponseCode(string waybillRequestResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillRequestResponseInformation();
		//Required fields
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.WaybillRequestResponseCode = waybillRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillRequestResponseInformation();
		//Required fields
		subject.WaybillRequestResponseCode = "B";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillRequestResponseInformation();
		//Required fields
		subject.WaybillRequestResponseCode = "B";
		subject.EquipmentInitial = "h";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
