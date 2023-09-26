using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class EATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EA*0R**9";

		var expected = new EA_EquipmentAttributes()
		{
			EquipmentAttributeCode = "0R",
			CompositeUnitOfMeasure = null,
			Quantity = 9,
		};

		var actual = Map.MapObject<EA_EquipmentAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0R", true)]
	public void Validation_RequiredEquipmentAttributeCode(string equipmentAttributeCode, bool isValidExpected)
	{
		var subject = new EA_EquipmentAttributes();
		//Required fields
		//Test Parameters
		subject.EquipmentAttributeCode = equipmentAttributeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
