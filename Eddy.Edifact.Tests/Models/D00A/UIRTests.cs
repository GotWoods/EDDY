using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UIR+d++++D+G";

		var expected = new UIR_InteractiveStatus()
		{
			ReportFunctionCoded = "d",
			ReportReason = null,
			DialogueReference = null,
			DateAndOrTimeOfInitiation = null,
			InteractiveMessageReferenceNumber = "D",
			PackageReferenceNumber = "G",
		};

		var actual = Map.MapObject<UIR_InteractiveStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReportFunctionCoded(string reportFunctionCoded, bool isValidExpected)
	{
		var subject = new UIR_InteractiveStatus();
		//Required fields
		//Test Parameters
		subject.ReportFunctionCoded = reportFunctionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
