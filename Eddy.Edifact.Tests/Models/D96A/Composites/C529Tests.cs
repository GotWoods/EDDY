using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C529Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:F:V:L";

		var expected = new C529_ProcessingIndicator()
		{
			ProcessingIndicatorCoded = "a",
			CodeListQualifier = "F",
			CodeListResponsibleAgencyCoded = "V",
			ProcessTypeIdentification = "L",
		};

		var actual = Map.MapComposite<C529_ProcessingIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredProcessingIndicatorCoded(string processingIndicatorCoded, bool isValidExpected)
	{
		var subject = new C529_ProcessingIndicator();
		//Required fields
		//Test Parameters
		subject.ProcessingIndicatorCoded = processingIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
