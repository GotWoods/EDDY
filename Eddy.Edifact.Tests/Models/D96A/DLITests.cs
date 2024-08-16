using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DLI+f+i";

		var expected = new DLI_DocumentLineIdentification()
		{
			DocumentLineIndicatorCoded = "f",
			LineItemNumber = "i",
		};

		var actual = Map.MapObject<DLI_DocumentLineIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredDocumentLineIndicatorCoded(string documentLineIndicatorCoded, bool isValidExpected)
	{
		var subject = new DLI_DocumentLineIdentification();
		//Required fields
		subject.LineItemNumber = "i";
		//Test Parameters
		subject.DocumentLineIndicatorCoded = documentLineIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredLineItemNumber(string lineItemNumber, bool isValidExpected)
	{
		var subject = new DLI_DocumentLineIdentification();
		//Required fields
		subject.DocumentLineIndicatorCoded = "f";
		//Test Parameters
		subject.LineItemNumber = lineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
