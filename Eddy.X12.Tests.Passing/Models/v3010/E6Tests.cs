using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*O*F*pj*tVtPbH*Px*y8*V*jwep";

		var expected = new E6_EmptyCarAdvanceDisposition()
		{
			EquipmentInitial = "O",
			EquipmentNumber = "F",
			CityName = "pj",
			StandardPointLocationCode = "tVtPbH",
			StandardCarrierAlphaCode = "Px",
			IntermediateSwitchCarrier = "y8",
			CommodityCode = "V",
			CarTypeCode = "jwep",
		};

		var actual = Map.MapObject<E6_EmptyCarAdvanceDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentNumber = "F";
		subject.CityName = "pj";
		subject.StandardCarrierAlphaCode = "Px";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "O";
		subject.CityName = "pj";
		subject.StandardCarrierAlphaCode = "Px";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pj", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "F";
		subject.StandardCarrierAlphaCode = "Px";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Px", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "F";
		subject.CityName = "pj";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
