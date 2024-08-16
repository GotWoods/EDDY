using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C529Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:G:L:L";

		var expected = new C529_ProcessingIndicator()
		{
			ProcessingIndicatorDescriptionCode = "B",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "L",
			ProcessTypeDescriptionCode = "L",
		};

		var actual = Map.MapComposite<C529_ProcessingIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredProcessingIndicatorDescriptionCode(string processingIndicatorDescriptionCode, bool isValidExpected)
	{
		var subject = new C529_ProcessingIndicator();
		//Required fields
		//Test Parameters
		subject.ProcessingIndicatorDescriptionCode = processingIndicatorDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
