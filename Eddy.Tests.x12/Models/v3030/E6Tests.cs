using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*1*2*bI*HwpuxS*TZ*A3*a*3zW2*j";

		var expected = new E6_AdvanceCarDisposition()
		{
			EquipmentInitial = "1",
			EquipmentNumber = "2",
			CityName = "bI",
			StandardPointLocationCode = "HwpuxS",
			StandardCarrierAlphaCode = "TZ",
			IntermediateSwitchCarrier = "A3",
			CommodityCode = "a",
			CarTypeCode = "3zW2",
			EquipmentStatusCode = "j",
		};

		var actual = Map.MapObject<E6_AdvanceCarDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentNumber = "2";
		subject.CityName = "bI";
		subject.StandardCarrierAlphaCode = "TZ";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.CityName = "bI";
		subject.StandardCarrierAlphaCode = "TZ";
		subject.EquipmentStatusCode = "j";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bI", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "2";
		subject.StandardCarrierAlphaCode = "TZ";
		subject.EquipmentStatusCode = "j";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "2";
		subject.CityName = "bI";
		subject.EquipmentStatusCode = "j";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "2";
		subject.CityName = "bI";
		subject.StandardCarrierAlphaCode = "TZ";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
