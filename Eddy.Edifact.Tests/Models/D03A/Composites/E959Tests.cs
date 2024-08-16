using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:oHvM:Famv:s:u:f:a:p:s:T:j:h:j:q:w:o:b:Z:X";

		var expected = new E959_AdditionalServiceDetails()
		{
			SpecialServiceDescriptionCode = "4",
			Time = "oHvM",
			Time2 = "Famv",
			Date = "s",
			LocationName = "u",
			LocationNameCode = "f",
			LocationFunctionCodeQualifier = "a",
			CharacteristicDescriptionCode = "p",
			FirstRelatedLocationNameCode = "s",
			CountryNameCode = "T",
			SpecialServiceDescription = "j",
			CharacteristicDescription = "h",
			ActionRequestNotificationDescriptionCode = "j",
			SecondRelatedLocationNameCode = "q",
			LanguageNameCode = "w",
			FrequencyRate = "o",
			MeasurementUnitCode = "b",
			Quantity = "Z",
			PartyName = "X",
		};

		var actual = Map.MapComposite<E959_AdditionalServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_AdditionalServiceDetails();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
