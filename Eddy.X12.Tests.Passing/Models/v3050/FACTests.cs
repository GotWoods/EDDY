using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAC*4*l*1R*p*9*h";

		var expected = new FAC_FacingDirection()
		{
			EquipmentInitial = "4",
			EquipmentNumber = "l",
			EquipmentDescriptionCode = "1R",
			DirectionFacing = "p",
			EquipmentStatusCode = "9",
			YesNoConditionOrResponseCode = "h",
		};

		var actual = Map.MapObject<FAC_FacingDirection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "4";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
