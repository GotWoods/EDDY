using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:O:x:y:G:h:G";

		var expected = new E968_DocumentInformation()
		{
			DocumentNameCode = "l",
			DocumentIdentifier = "O",
			CharacteristicValueDescriptionCode = "x",
			LocationNameCode = "y",
			CountryNameCode = "G",
			CountryNameCode2 = "h",
			CityName = "G",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredDocumentNameCode(string documentNameCode, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		//Test Parameters
		subject.DocumentNameCode = documentNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
