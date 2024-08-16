using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:gWac:aYKt:M:Z:b:4:P:7:i:c:e:h:0:K:6:f";

		var expected = new E959_ServiceDateTimeLocationInformation()
		{
			SpecialServiceDescriptionCode = "T",
			TimeValue = "gWac",
			TimeValue2 = "aYKt",
			DateValue = "M",
			LocationName = "Z",
			LocationNameCode = "b",
			LocationFunctionCodeQualifier = "4",
			CharacteristicDescriptionCode = "P",
			FirstRelatedLocationNameCode = "7",
			CountryNameCode = "i",
			SpecialServiceDescription = "c",
			CharacteristicDescription = "e",
			ActionRequestNotificationDescriptionCode = "h",
			SecondRelatedLocationNameCode = "0",
			LanguageNameCode = "K",
			FrequencyValue = "6",
			MeasurementUnitCode = "f",
		};

		var actual = Map.MapComposite<E959_ServiceDateTimeLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_ServiceDateTimeLocationInformation();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
