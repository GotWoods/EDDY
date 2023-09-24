using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAC*7*q*zG*e*q*G";

		var expected = new FAC_FacingDirection()
		{
			EquipmentInitial = "7",
			EquipmentNumber = "q",
			EquipmentDescriptionCode = "zG",
			DirectionFacingCode = "e",
			EquipmentStatusCode = "q",
			YesNoConditionOrResponseCode = "G",
		};

		var actual = Map.MapObject<FAC_FacingDirection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		subject.EquipmentNumber = "q";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		subject.EquipmentInitial = "7";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
