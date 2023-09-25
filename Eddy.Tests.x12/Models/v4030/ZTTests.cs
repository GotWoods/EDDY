using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ZTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZT*y*B*c*2*swQzZhJd*6";

		var expected = new ZT_WaybillRequestInformation()
		{
			WaybillRequestCode = "y",
			EquipmentInitial = "B",
			EquipmentNumber = "c",
			WaybillNumber = 2,
			Date = "swQzZhJd",
			EquipmentNumberCheckDigit = 6,
		};

		var actual = Map.MapObject<ZT_WaybillRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredWaybillRequestCode(string waybillRequestCode, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.WaybillRequestCode = waybillRequestCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "swQzZhJd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "y";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "swQzZhJd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "y";
		subject.EquipmentInitial = "B";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "swQzZhJd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "swQzZhJd", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "swQzZhJd", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZT_WaybillRequestInformation();
		//Required fields
		subject.WaybillRequestCode = "y";
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "c";
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
