using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ZTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZT*M*t*y*2*eLMRcQsB*2";

		var expected = new ZT_WaybillRequestInformation()
		{
			WaybillRequestCode = "M",
			EquipmentInitial = "t",
			EquipmentNumber = "y",
			WaybillNumber = 2,
			Date = "eLMRcQsB",
			EquipmentNumberCheckDigit = 2,
		};

		var actual = Map.MapObject<ZT_WaybillRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredWaybillRequestCode(string waybillRequestCode, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "y";
		subject.WaybillRequestCode = waybillRequestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		subject.WaybillRequestCode = "M";
		subject.EquipmentNumber = "y";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		subject.WaybillRequestCode = "M";
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "eLMRcQsB", true)]
	[InlineData(0, "eLMRcQsB", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		subject.WaybillRequestCode = "M";
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "y";
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
