using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ED*I*o*t*H*x*8*g*tWKzmETo";

		var expected = new ED_EquipmentDescription()
		{
			EquipmentInitial = "I",
			EquipmentNumber = "o",
			LoadEmptyStatusCode = "t",
			CommodityCode = "H",
			LadingDescription = "x",
			WaybillNumber = 8,
			EquipmentNumber2 = "g",
			Date = "tWKzmETo",
		};

		var actual = Map.MapObject<ED_EquipmentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentNumber = "o";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validatation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "I";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
