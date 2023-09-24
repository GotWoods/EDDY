using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E6*m*t*t1*jBBEJV*gk*99*g*kWeu*h";

		var expected = new E6_EmptyCarAdvanceDisposition()
		{
			EquipmentInitial = "m",
			EquipmentNumber = "t",
			CityName = "t1",
			StandardPointLocationCode = "jBBEJV",
			StandardCarrierAlphaCode = "gk",
			IntermediateSwitchCarrier = "99",
			CommodityCode = "g",
			CarTypeCode = "kWeu",
			EquipmentStatusCode = "h",
		};

		var actual = Map.MapObject<E6_EmptyCarAdvanceDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentNumber = "t";
		subject.CityName = "t1";
		subject.StandardCarrierAlphaCode = "gk";
		subject.EquipmentStatusCode = "h";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "m";
		subject.CityName = "t1";
		subject.StandardCarrierAlphaCode = "gk";
		subject.EquipmentStatusCode = "h";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t1", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "t";
		subject.StandardCarrierAlphaCode = "gk";
		subject.EquipmentStatusCode = "h";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gk", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "t";
		subject.CityName = "t1";
		subject.EquipmentStatusCode = "h";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new E6_EmptyCarAdvanceDisposition();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "t";
		subject.CityName = "t1";
		subject.StandardCarrierAlphaCode = "gk";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
