using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZT*t*v*e*2*tt9DCF";

		var expected = new ZT_WaybillRequestInformation()
		{
			WaybillRequestCode = "t",
			EquipmentInitial = "v",
			EquipmentNumber = "e",
			WaybillNumber = 2,
			Date = "tt9DCF",
		};

		var actual = Map.MapObject<ZT_WaybillRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredWaybillRequestCode(string waybillRequestCode, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.EquipmentInitial = "v";
		subject.EquipmentNumber = "e";
		//Test Parameters
		subject.WaybillRequestCode = waybillRequestCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "tt9DCF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "t";
		subject.EquipmentNumber = "e";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "tt9DCF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "t";
		subject.EquipmentInitial = "v";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "tt9DCF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "tt9DCF", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "tt9DCF", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "t";
		subject.EquipmentInitial = "v";
		subject.EquipmentNumber = "e";
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
