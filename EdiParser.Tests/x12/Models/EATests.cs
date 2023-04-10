using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EA*uP**1";

		var expected = new EA_EquipmentAttributes()
		{
			EquipmentAttributeCode = "uP",
			CompositeUnitOfMeasure = "",
			Quantity = 1,
		};

		var actual = Map.MapObject<EA_EquipmentAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validatation_RequiredEquipmentAttributeCode(string equipmentAttributeCode, bool isValidExpected)
	{
		var subject = new EA_EquipmentAttributes();
		subject.EquipmentAttributeCode = equipmentAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
