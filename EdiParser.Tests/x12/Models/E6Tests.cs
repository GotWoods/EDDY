using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*J*u*uK*JPkMrT*8I*gc*Q*O*X";

		var expected = new E6_AdvanceCarDisposition()
		{
			EquipmentInitial = "J",
			EquipmentNumber = "u",
			CityName = "uK",
			StandardPointLocationCode = "JPkMrT",
			StandardCarrierAlphaCode = "8I",
			IntermediateSwitchCarrierCode = "gc",
			CommodityCode = "Q",
			CarTypeCode = "O",
			EquipmentStatusCode = "X",
		};

		var actual = Map.MapObject<E6_AdvanceCarDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validatation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentNumber = "u";
		subject.CityName = "uK";
		subject.StandardCarrierAlphaCode = "8I";
		subject.EquipmentStatusCode = "X";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validatation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "J";
		subject.CityName = "uK";
		subject.StandardCarrierAlphaCode = "8I";
		subject.EquipmentStatusCode = "X";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uK", true)]
	public void Validatation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "J";
		subject.EquipmentNumber = "u";
		subject.StandardCarrierAlphaCode = "8I";
		subject.EquipmentStatusCode = "X";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8I", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "J";
		subject.EquipmentNumber = "u";
		subject.CityName = "uK";
		subject.EquipmentStatusCode = "X";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "J";
		subject.EquipmentNumber = "u";
		subject.CityName = "uK";
		subject.StandardCarrierAlphaCode = "8I";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
