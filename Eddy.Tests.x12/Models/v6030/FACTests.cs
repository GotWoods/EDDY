using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class FACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAC*6*T*Lj*I*p*E";

		var expected = new FAC_FacingDirection()
		{
			EquipmentInitial = "6",
			EquipmentNumber = "T",
			EquipmentDescriptionCode = "Lj",
			DirectionFacingCode = "I",
			EquipmentStatusCode = "p",
			YesNoConditionOrResponseCode = "E",
		};

		var actual = Map.MapObject<FAC_FacingDirection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentNumber = "T";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new FAC_FacingDirection();
		//Required fields
		subject.EquipmentInitial = "6";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
