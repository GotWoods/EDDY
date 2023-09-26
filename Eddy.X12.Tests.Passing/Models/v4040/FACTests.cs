using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class FACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAC*N*P*7e*J*s*w";

		var expected = new FAC_FacingDirection()
		{
			EquipmentInitial = "N",
			EquipmentNumber = "P",
			EquipmentDescriptionCode = "7e",
			DirectionFacing = "J",
			EquipmentStatusCode = "s",
			YesNoConditionOrResponseCode = "w",
		};

		var actual = Map.MapObject<FAC_FacingDirection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentNumber = "P";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "N";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
