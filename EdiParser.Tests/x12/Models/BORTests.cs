using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOR*Gj*Z*0*a*XU*U*I*q*Ckk*Ow";

		var expected = new BOR_BeginningOfReport()
		{
			ReportTypeCode = "Gj",
			ReferenceIdentification = "Z",
			ReferenceIdentification2 = "0",
			ReferenceIdentification3 = "a",
			DateTimePeriodFormatQualifier = "XU",
			DateTimePeriod = "U",
			TransportationMethodTypeCode = "I",
			ActionCode = "q",
			StatusReasonCode = "Ckk",
			LanguageCode = "Ow",
		};

		var actual = Map.MapObject<BOR_BeginningOfReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gj", true)]
	public void Validatation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("XU", "U", true)]
	[InlineData("", "U", false)]
	[InlineData("XU", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BOR_BeginningOfReport();
		subject.ReportTypeCode = "Gj";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
