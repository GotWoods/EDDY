using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EA*uP**1";

		var expected = new EA_EquipmentAttributes()
		{
			EquipmentAttributeCode = "uP",
			CompositeUnitOfMeasure = null,
			Quantity = 1,
		};

		var actual = Map.MapObject<EA_EquipmentAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validation_RequiredEquipmentAttributeCode(string equipmentAttributeCode, bool isValidExpected)
	{
		var subject = new EA_EquipmentAttributes();
		subject.EquipmentAttributeCode = equipmentAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
