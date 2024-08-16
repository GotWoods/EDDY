using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C240Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:O:V:d:1";

		var expected = new C240_ProductCharacteristic()
		{
			CharacteristicDescriptionCode = "a",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "V",
			CharacteristicDescription = "d",
			CharacteristicDescription2 = "1",
		};

		var actual = Map.MapComposite<C240_ProductCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCharacteristicDescriptionCode(string characteristicDescriptionCode, bool isValidExpected)
	{
		var subject = new C240_ProductCharacteristic();
		//Required fields
		//Test Parameters
		subject.CharacteristicDescriptionCode = characteristicDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
