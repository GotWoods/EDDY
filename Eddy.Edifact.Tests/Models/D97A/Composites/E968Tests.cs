using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E968Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:C:N:g:8:I";

		var expected = new E968_DocumentInformation()
		{
			DocumentMessageNameCoded = "k",
			DocumentMessageNumber = "C",
			CharacteristicValueCoded = "N",
			PlaceLocationIdentification = "g",
			CountryCoded = "8",
			CountryCoded2 = "I",
		};

		var actual = Map.MapComposite<E968_DocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredDocumentMessageNameCoded(string documentMessageNameCoded, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		subject.DocumentMessageNumber = "C";
		//Test Parameters
		subject.DocumentMessageNameCoded = documentMessageNameCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredDocumentMessageNumber(string documentMessageNumber, bool isValidExpected)
	{
		var subject = new E968_DocumentInformation();
		//Required fields
		subject.DocumentMessageNameCoded = "k";
		//Test Parameters
		subject.DocumentMessageNumber = documentMessageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
