using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOR*yH*x*6*h*kS*a*c*T*lEE*P0";

		var expected = new BOR_BeginningOfReport()
		{
			ReportTypeCode = "yH",
			ReferenceIdentification = "x",
			ReferenceIdentification2 = "6",
			ReferenceIdentification3 = "h",
			DateTimePeriodFormatQualifier = "kS",
			DateTimePeriod = "a",
			TransportationMethodTypeCode = "c",
			ActionCode = "T",
			StatusReasonCode = "lEE",
			LanguageCode = "P0",
		};

		var actual = Map.MapObject<BOR_BeginningOfReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yH", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "kS";
			subject.DateTimePeriod = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kS", "a", true)]
	[InlineData("kS", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		subject.ReportTypeCode = "yH";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
