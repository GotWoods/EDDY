using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:O:L:k:O:m";

		var expected = new E968_DocumentInformation()
		{
			DocumentNameCode = "a",
			DocumentMessageNumber = "O",
			CharacteristicValueCoded = "L",
			LocationNameCode = "k",
			CountryNameCode = "O",
			CountryNameCode2 = "m",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDocumentNameCode(string documentNameCode, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		//Test Parameters
		subject.DocumentNameCode = documentNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
