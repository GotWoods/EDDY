using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQD*7*Q*P";

		var expected = new EQD_EQDEquipmentDamageInformation()
		{
			LocationOnEquipmentCode = "7",
			TypeOfDamageCode = "Q",
			EquipmentComponentCode = "P",
		};

		var actual = Map.MapObject<EQD_EQDEquipmentDamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredLocationOnEquipmentCode(string locationOnEquipmentCode, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.TypeOfDamageCode = "Q";
		//Test Parameters
		subject.LocationOnEquipmentCode = locationOnEquipmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredTypeOfDamageCode(string typeOfDamageCode, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		//Required fields
		subject.LocationOnEquipmentCode = "7";
		//Test Parameters
		subject.TypeOfDamageCode = typeOfDamageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
