using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOR*wV*1*O*i*6E*H*F*Z*mWV*CZ";

		var expected = new BOR_BeginningOfReport()
		{
			ReportTypeCode = "wV",
			ReferenceIdentification = "1",
			ReferenceIdentification2 = "O",
			ReferenceIdentification3 = "i",
			DateTimePeriodFormatQualifier = "6E",
			DateTimePeriod = "H",
			TransportationMethodTypeCode = "F",
			ActionCode = "Z",
			StatusReasonCode = "mWV",
			LanguageCode = "CZ",
		};

		var actual = Map.MapObject<BOR_BeginningOfReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wV", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "6E";
			subject.DateTimePeriod = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6E", "H", true)]
	[InlineData("6E", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		subject.ReportTypeCode = "wV";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
