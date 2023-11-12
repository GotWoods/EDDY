using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*S*Y*OZ*8nbQi9*R5*Md*c*f*n";

		var expected = new E6_AdvanceCarDisposition()
		{
			EquipmentInitial = "S",
			EquipmentNumber = "Y",
			CityName = "OZ",
			StandardPointLocationCode = "8nbQi9",
			StandardCarrierAlphaCode = "R5",
			IntermediateSwitchCarrier = "Md",
			CommodityCode = "c",
			CarTypeCode = "f",
			EquipmentStatusCode = "n",
		};

		var actual = Map.MapObject<E6_AdvanceCarDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentNumber = "Y";
		subject.CityName = "OZ";
		subject.StandardCarrierAlphaCode = "R5";
		subject.EquipmentStatusCode = "n";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "S";
		subject.CityName = "OZ";
		subject.StandardCarrierAlphaCode = "R5";
		subject.EquipmentStatusCode = "n";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OZ", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "S";
		subject.EquipmentNumber = "Y";
		subject.StandardCarrierAlphaCode = "R5";
		subject.EquipmentStatusCode = "n";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R5", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "S";
		subject.EquipmentNumber = "Y";
		subject.CityName = "OZ";
		subject.EquipmentStatusCode = "n";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "S";
		subject.EquipmentNumber = "Y";
		subject.CityName = "OZ";
		subject.StandardCarrierAlphaCode = "R5";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
