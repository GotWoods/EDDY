using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*m*O*bO*0nkc9o*KR*2W*a*L*y";

		var expected = new E6_AdvanceCarDisposition()
		{
			EquipmentInitial = "m",
			EquipmentNumber = "O",
			CityName = "bO",
			StandardPointLocationCode = "0nkc9o",
			StandardCarrierAlphaCode = "KR",
			IntermediateSwitchCarrierCode = "2W",
			CommodityCode = "a",
			CarTypeCode = "L",
			EquipmentStatusCode = "y",
		};

		var actual = Map.MapObject<E6_AdvanceCarDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentNumber = "O";
		subject.CityName = "bO";
		subject.StandardCarrierAlphaCode = "KR";
		subject.EquipmentStatusCode = "y";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "m";
		subject.CityName = "bO";
		subject.StandardCarrierAlphaCode = "KR";
		subject.EquipmentStatusCode = "y";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bO", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "O";
		subject.StandardCarrierAlphaCode = "KR";
		subject.EquipmentStatusCode = "y";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KR", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "O";
		subject.CityName = "bO";
		subject.EquipmentStatusCode = "y";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "O";
		subject.CityName = "bO";
		subject.StandardCarrierAlphaCode = "KR";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
