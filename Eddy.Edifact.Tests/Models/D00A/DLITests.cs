using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DLI+B+O";

		var expected = new DLI_DocumentLineIdentification()
		{
			DocumentLineActionCode = "B",
			LineItemIdentifier = "O",
		};

		var actual = Map.MapObject<DLI_DocumentLineIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredDocumentLineActionCode(string documentLineActionCode, bool isValidExpected)
	{
		var subject = new DLI_DocumentLineIdentification();
		//Required fields
		subject.LineItemIdentifier = "O";
		//Test Parameters
		subject.DocumentLineActionCode = documentLineActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredLineItemIdentifier(string lineItemIdentifier, bool isValidExpected)
	{
		var subject = new DLI_DocumentLineIdentification();
		//Required fields
		subject.DocumentLineActionCode = "B";
		//Test Parameters
		subject.LineItemIdentifier = lineItemIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
