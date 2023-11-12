using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQD*X*z*C";

		var expected = new EQD_EQDEquipmentDamageInformation()
		{
			LocationOnEquipment = "X",
			TypeOfDamage = "z",
			EquipmentComponent = "C",
		};

		var actual = Map.MapObject<EQD_EQDEquipmentDamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredLocationOnEquipment(string locationOnEquipment, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.TypeOfDamage = "z";
		//Test Parameters
		subject.LocationOnEquipment = locationOnEquipment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTypeOfDamage(string typeOfDamage, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.LocationOnEquipment = "X";
		//Test Parameters
		subject.TypeOfDamage = typeOfDamage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
