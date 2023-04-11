using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQD*Z*T*m";

		var expected = new EQD_EQDEquipmentDamageInformation()
		{
			LocationOnEquipmentCode = "Z",
			TypeOfDamageCode = "T",
			EquipmentComponentCode = "m",
		};

		var actual = Map.MapObject<EQD_EQDEquipmentDamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validatation_RequiredLocationOnEquipmentCode(string locationOnEquipmentCode, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		subject.TypeOfDamageCode = "T";
		subject.LocationOnEquipmentCode = locationOnEquipmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredTypeOfDamageCode(string typeOfDamageCode, bool isValidExpected)
	{
		var subject = new EQD_EQDEquipmentDamageInformation();
		subject.LocationOnEquipmentCode = "Z";
		subject.TypeOfDamageCode = typeOfDamageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
