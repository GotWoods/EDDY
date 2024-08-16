using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C240Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:6:j:v:d";

		var expected = new C240_ProductCharacteristic()
		{
			CharacteristicIdentification = "A",
			CodeListQualifier = "6",
			CodeListResponsibleAgencyCoded = "j",
			Characteristic = "v",
			Characteristic2 = "d",
		};

		var actual = Map.MapComposite<C240_ProductCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCharacteristicIdentification(string characteristicIdentification, bool isValidExpected)
	{
		var subject = new C240_ProductCharacteristic();
		//Required fields
		//Test Parameters
		subject.CharacteristicIdentification = characteristicIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
