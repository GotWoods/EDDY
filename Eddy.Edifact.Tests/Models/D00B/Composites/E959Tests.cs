using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:F22j:3Kee:z:x:V:j:u:t:T:m:E:1:Z:h:k:i:K:1";

		var expected = new E959_AdditionalServiceDetails()
		{
			SpecialServiceDescriptionCode = "l",
			TimeValue = "F22j",
			TimeValue2 = "3Kee",
			DateValue = "z",
			LocationName = "x",
			LocationNameCode = "V",
			LocationFunctionCodeQualifier = "j",
			CharacteristicDescriptionCode = "u",
			FirstRelatedLocationNameCode = "t",
			CountryNameCode = "T",
			SpecialServiceDescription = "m",
			CharacteristicDescription = "E",
			ActionRequestNotificationDescriptionCode = "1",
			SecondRelatedLocationNameCode = "Z",
			LanguageNameCode = "h",
			FrequencyValue = "k",
			MeasurementUnitCode = "i",
			Quantity = "K",
			PartyName = "1",
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
