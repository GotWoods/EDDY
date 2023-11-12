using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOR*Xb*j*N*M*en*7*F*b*u4f*vF";

		var expected = new BOR_BeginningOfReport()
		{
			ReportTypeCode = "Xb",
			ReferenceIdentification = "j",
			ReferenceIdentification2 = "N",
			ReferenceIdentification3 = "M",
			DateTimePeriodFormatQualifier = "en",
			DateTimePeriod = "7",
			TransportationMethodTypeCode = "F",
			ActionCode = "b",
			StatusReasonCode = "u4f",
			LanguageCode = "vF",
		};

		var actual = Map.MapObject<BOR_BeginningOfReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xb", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "en";
			subject.DateTimePeriod = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("en", "7", true)]
	[InlineData("en", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		//Required fields
		subject.ReportTypeCode = "Xb";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
