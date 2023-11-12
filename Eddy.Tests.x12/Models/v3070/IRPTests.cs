using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IRP*c*H*J*j*e*f*u";

		var expected = new IRP_ReportSelectionSegment()
		{
			ReportTypeCode = "c",
			ReportIdentifier = "H",
			ReportIncrementalIndicatorCode = "J",
			MessageDirectionCode = "j",
			ReportStatusLevelCode = "e",
			ReportLevelOfDetailCode = "f",
			ShipDeliveryOrCalendarPatternCode = "u",
		};

		var actual = Map.MapObject<IRP_ReportSelectionSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new IRP_ReportSelectionSegment();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
