using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C240Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "c:k:B:q:c";

		var expected = new C240_ProductCharacteristic()
		{
			CharacteristicDescriptionCode = "c",
			CodeListIdentificationCode = "k",
			CodeListResponsibleAgencyCode = "B",
			CharacteristicDescription = "q",
			CharacteristicDescription2 = "c",
		};

		var actual = Map.MapComposite<C240_ProductCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredCharacteristicDescriptionCode(string characteristicDescriptionCode, bool isValidExpected)
	{
		var subject = new C240_ProductCharacteristic();
		//Required fields
		//Test Parameters
		subject.CharacteristicDescriptionCode = characteristicDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
