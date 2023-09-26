using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAC*U*Q*r2*j";

		var expected = new FAC_FacingDirection()
		{
			EquipmentInitial = "U",
			EquipmentNumber = "Q",
			EquipmentDescriptionCode = "r2",
			DirectionFacing = "j",
		};

		var actual = Map.MapObject<FAC_FacingDirection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.EquipmentDescriptionCode = "r2";
		subject.DirectionFacing = "j";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "U";
		subject.EquipmentDescriptionCode = "r2";
		subject.DirectionFacing = "j";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r2", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "U";
		subject.EquipmentNumber = "Q";
		subject.DirectionFacing = "j";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredDirectionFacing(string directionFacing, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "U";
		subject.EquipmentNumber = "Q";
		subject.EquipmentDescriptionCode = "r2";
		//Test Parameters
		subject.DirectionFacing = directionFacing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
