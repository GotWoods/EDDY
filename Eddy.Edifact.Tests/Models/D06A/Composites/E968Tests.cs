using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:Q:w:j:z:m:h";

		var expected = new E968_DocumentInformation()
		{
			DocumentNameCode = "q",
			DocumentIdentifier = "Q",
			CharacteristicValueDescriptionCode = "w",
			LocationIdentifier = "j",
			CountryIdentifier = "z",
			CountryIdentifier2 = "m",
			CityName = "h",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredDocumentNameCode(string documentNameCode, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		//Test Parameters
		subject.DocumentNameCode = documentNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
