using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:EVNL:gzGr:A:V:T:F:2:O:z:6:j:M:v:2:t:c:G:v";

		var expected = new E959_AdditionalServiceDetails()
		{
			SpecialServiceDescriptionCode = "S",
			Time = "EVNL",
			Time2 = "gzGr",
			Date = "A",
			LocationName = "V",
			LocationIdentifier = "T",
			LocationFunctionCodeQualifier = "F",
			CharacteristicDescriptionCode = "2",
			FirstRelatedLocationIdentifier = "O",
			CountryIdentifier = "z",
			SpecialServiceDescription = "6",
			CharacteristicDescription = "j",
			ActionCode = "M",
			SecondRelatedLocationIdentifier = "v",
			LanguageNameCode = "2",
			FrequencyRate = "t",
			MeasurementUnitCode = "c",
			Quantity = "G",
			PartyName = "v",
		};

		var actual = Map.MapComposite<E959_AdditionalServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_AdditionalServiceDetails();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
