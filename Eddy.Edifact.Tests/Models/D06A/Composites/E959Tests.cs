using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:hi3L:E5Dw:g:W:J:1:H:X:Q:s:2:Y:d:T:R:R:M:d";

		var expected = new E959_AdditionalServiceDetails()
		{
			SpecialServiceDescriptionCode = "U",
			Time = "hi3L",
			Time2 = "E5Dw",
			Date = "g",
			LocationName = "W",
			LocationIdentifier = "J",
			LocationFunctionCodeQualifier = "1",
			CharacteristicDescriptionCode = "H",
			FirstRelatedLocationIdentifier = "X",
			CountryIdentifier = "Q",
			SpecialServiceDescription = "s",
			CharacteristicDescription = "2",
			ActionCode = "Y",
			SecondRelatedLocationIdentifier = "d",
			LanguageNameCode = "T",
			FrequencyRate = "R",
			MeasurementUnitCode = "R",
			Quantity = "M",
			PartyName = "d",
		};

		var actual = Map.MapComposite<E959_AdditionalServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_AdditionalServiceDetails();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
