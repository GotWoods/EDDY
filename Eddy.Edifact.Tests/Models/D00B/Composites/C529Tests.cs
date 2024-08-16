using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C529Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:W:6:u";

		var expected = new C529_ProcessingIndicator()
		{
			ProcessingIndicatorDescriptionCode = "i",
			CodeListIdentificationCode = "W",
			CodeListResponsibleAgencyCode = "6",
			ProcessTypeDescriptionCode = "u",
		};

		var actual = Map.MapComposite<C529_ProcessingIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredProcessingIndicatorDescriptionCode(string processingIndicatorDescriptionCode, bool isValidExpected)
	{
		var subject = new C529_ProcessingIndicator();
		//Required fields
		//Test Parameters
		subject.ProcessingIndicatorDescriptionCode = processingIndicatorDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
