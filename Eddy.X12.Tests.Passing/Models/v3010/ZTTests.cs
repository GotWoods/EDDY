using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZT*0*6*O*1*GTfpYi";

		var expected = new ZT_WaybillRequestInformation()
		{
			WaybillRequestCode = "0",
			EquipmentInitial = "6",
			EquipmentNumber = "O",
			WaybillNumber = 1,
			Date = "GTfpYi",
		};

		var actual = Map.MapObject<ZT_WaybillRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredWaybillRequestCode(string waybillRequestCode, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.EquipmentInitial = "6";
		subject.EquipmentNumber = "O";
		//Test Parameters
		subject.WaybillRequestCode = waybillRequestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "0";
		subject.EquipmentNumber = "O";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "0";
		subject.EquipmentInitial = "6";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
