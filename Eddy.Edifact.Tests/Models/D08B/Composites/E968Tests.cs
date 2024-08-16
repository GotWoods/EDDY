using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:M:Q:w:G:3:t";

		var expected = new E968_DocumentInformation()
		{
			DocumentNameCode = "z",
			DocumentIdentifier = "M",
			CharacteristicValueDescriptionCode = "Q",
			LocationIdentifier = "w",
			CountryIdentifier = "G",
			CountryIdentifier2 = "3",
			CityName = "t",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDocumentNameCode(string documentNameCode, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		//Test Parameters
		subject.DocumentNameCode = documentNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
