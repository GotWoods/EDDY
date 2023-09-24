using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IRP*n*k*3*v*g*p*O";

		var expected = new IRP_ReportSelectionSegment()
		{
			InterchangeReportTypeCode = "n",
			InterchangeReportIdentifier = "k",
			InterchangeReportIncrementalIndicatorCode = "3",
			InterchangeMessageDirectionCode = "v",
			InterchangeReportStatusLevelCode = "g",
			InterchangeReportLevelOfDetailCode = "p",
			ShipDeliveryOrCalendarPatternCode = "O",
		};

		var actual = Map.MapObject<IRP_ReportSelectionSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredInterchangeReportTypeCode(string interchangeReportTypeCode, bool isValidExpected)
	{
		var subject = new IRP_ReportSelectionSegment();
		subject.InterchangeReportTypeCode = interchangeReportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
