using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class EDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ED*I*A*C*R*3*4*x*NLF8Bl";

		var expected = new ED_EquipmentDescription()
		{
			EquipmentInitial = "I",
			EquipmentNumber = "A",
			LoadEmptyStatusCode = "C",
			CommodityCode = "R",
			LadingDescription = "3",
			WaybillNumber = 4,
			EquipmentNumber2 = "x",
			Date = "NLF8Bl",
		};

		var actual = Map.MapObject<ED_EquipmentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentNumber = "A";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ED_EquipmentDescription();
		subject.EquipmentInitial = "I";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
