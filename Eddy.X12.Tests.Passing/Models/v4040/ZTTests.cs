using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ZTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZT*5*A*U*8*SqCvzjyo*6";

		var expected = new ZT_WaybillRequestInformation()
		{
			WaybillRequestCode = "5",
			EquipmentInitial = "A",
			EquipmentNumber = "U",
			WaybillNumber = 8,
			Date = "SqCvzjyo",
			EquipmentNumberCheckDigit = 6,
		};

		var actual = Map.MapObject<ZT_WaybillRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredWaybillRequestCode(string waybillRequestCode, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "U";
		//Test Parameters
		subject.WaybillRequestCode = waybillRequestCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 8;
			subject.Date = "SqCvzjyo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "5";
		subject.EquipmentNumber = "U";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 8;
			subject.Date = "SqCvzjyo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "5";
		subject.EquipmentInitial = "A";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 8;
			subject.Date = "SqCvzjyo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "SqCvzjyo", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "SqCvzjyo", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "5";
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "U";
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
