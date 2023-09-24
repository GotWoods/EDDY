using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*1*j*10*6cLcpq*zD*at*t*q*1";

		var expected = new E6_AdvanceCarDisposition()
		{
			EquipmentInitial = "1",
			EquipmentNumber = "j",
			CityName = "10",
			StandardPointLocationCode = "6cLcpq",
			StandardCarrierAlphaCode = "zD",
			IntermediateSwitchCarrier = "at",
			CommodityCode = "t",
			CarTypeCode = "q",
			EquipmentStatusCode = "1",
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
		subject.EquipmentNumber = "j";
		subject.CityName = "10";
		subject.StandardCarrierAlphaCode = "zD";
		subject.EquipmentStatusCode = "1";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.CityName = "10";
		subject.StandardCarrierAlphaCode = "zD";
		subject.EquipmentStatusCode = "1";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("10", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "j";
		subject.StandardCarrierAlphaCode = "zD";
		subject.EquipmentStatusCode = "1";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zD", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "j";
		subject.CityName = "10";
		subject.EquipmentStatusCode = "1";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_AdvanceCarDisposition();
		subject.EquipmentInitial = "1";
		subject.EquipmentNumber = "j";
		subject.CityName = "10";
		subject.StandardCarrierAlphaCode = "zD";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
