using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:x6Cl:KXKj:q:h:9:v:c:J:1:e:K";

		var expected = new E959_ServiceDateTimeLocationInformation()
		{
			SpecialServiceDescriptionCode = "z",
			Time = "x6Cl",
			Time2 = "KXKj",
			DateValue = "q",
			LocationName = "h",
			LocationNameCode = "9",
			LocationFunctionCodeQualifier = "v",
			CharacteristicDescriptionCode = "c",
			RelatedPlaceLocationOneIdentification = "J",
			CountryNameCode = "1",
			SpecialServiceDescription = "e",
			CharacteristicDescription = "K",
		};

		var actual = Map.MapComposite<E959_ServiceDateTimeLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredSpecialServiceDescriptionCode(string specialServiceDescriptionCode, bool isValidExpected)
	{
		var subject = new E959_ServiceDateTimeLocationInformation();
		//Required fields
		//Test Parameters
		subject.SpecialServiceDescriptionCode = specialServiceDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
