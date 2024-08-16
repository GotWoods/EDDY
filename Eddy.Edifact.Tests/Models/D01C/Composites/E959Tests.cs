using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:1jJr:CMVK:y:K:w:h:A:G:l:0:e:r:R:Y:o:N:C:n";

		var expected = new E959_AdditionalServiceDetails()
		{
			SpecialServiceDescriptionCode = "l",
			Time = "1jJr",
			Time2 = "CMVK",
			Date = "y",
			LocationName = "K",
			LocationNameCode = "w",
			LocationFunctionCodeQualifier = "h",
			CharacteristicDescriptionCode = "A",
			FirstRelatedLocationNameCode = "G",
			CountryNameCode = "l",
			SpecialServiceDescription = "0",
			CharacteristicDescription = "e",
			ActionRequestNotificationDescriptionCode = "r",
			SecondRelatedLocationNameCode = "R",
			LanguageNameCode = "Y",
			FrequencyRate = "o",
			MeasurementUnitCode = "N",
			Quantity = "C",
			PartyName = "n",
		};

		var actual = Map.MapComposite<E959_AdditionalServiceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_AdditionalServiceDetails();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
