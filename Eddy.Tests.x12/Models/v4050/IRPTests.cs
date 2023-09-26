using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class IRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IRP*Z*d*x*H*R*u*6";

		var expected = new IRP_ReportSelectionSegment()
		{
			InterchangeReportTypeCode = "Z",
			InterchangeReportIdentifier = "d",
			InterchangeReportIncrementalIndicatorCode = "x",
			InterchangeMessageDirectionCode = "H",
			InterchangeReportStatusLevelCode = "R",
			InterchangeReportLevelOfDetailCode = "u",
			ShipDeliveryOrCalendarPatternCode = "6",
		};

		var actual = Map.MapObject<IRP_ReportSelectionSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredInterchangeReportTypeCode(string interchangeReportTypeCode, bool isValidExpected)
	{
		var subject = new IRP_ReportSelectionSegment();
		//Required fields
		//Test Parameters
		subject.InterchangeReportTypeCode = interchangeReportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
