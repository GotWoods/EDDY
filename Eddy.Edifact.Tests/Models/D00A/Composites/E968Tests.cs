using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:C:b:c:l:e";

		var expected = new E968_DocumentInformation()
		{
			DocumentNameCode = "P",
			DocumentIdentifier = "C",
			CharacteristicValueDescriptionCode = "b",
			LocationNameCode = "c",
			CountryNameCode = "l",
			CountryNameCode2 = "e",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredDocumentNameCode(string documentNameCode, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		//Test Parameters
		subject.DocumentNameCode = documentNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
