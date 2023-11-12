using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQD*U*X";

		var expected = new EQD_EQDEquipmentDamageInformation()
		{
			DamageLocationOnEquipment = "U",
			TypeOfDamage = "X",
		};

		var actual = Map.MapObject<EQD_EQDEquipmentDamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredDamageLocationOnEquipment(string damageLocationOnEquipment, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.TypeOfDamage = "X";
		//Test Parameters
		subject.DamageLocationOnEquipment = damageLocationOnEquipment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredTypeOfDamage(string typeOfDamage, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.DamageLocationOnEquipment = "U";
		//Test Parameters
		subject.TypeOfDamage = typeOfDamage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
