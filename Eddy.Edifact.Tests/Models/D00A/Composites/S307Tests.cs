using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S307Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "m:9:F";

		var expected = new S307_ReportReason()
		{
			ReportReasonCoded = "m",
			ReportReasonText = "9",
			ReportLanguageCoded = "F",
		};

		var actual = Map.MapComposite<S307_ReportReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
