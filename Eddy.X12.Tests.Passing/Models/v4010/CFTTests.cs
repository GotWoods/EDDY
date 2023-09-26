using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFT*71**zl*obl*TqMSLIxc*G2S*AacZSWtJ*NW*n";

		var expected = new CFT_CostReportingFormatType()
		{
			ReportTypeCode = "71",
			CompositeUnitOfMeasure = null,
			ContractingFundingCode = "zl",
			DateTimeQualifier = "obl",
			Date = "TqMSLIxc",
			DateTimeQualifier2 = "G2S",
			Date2 = "AacZSWtJ",
			AppropriationCode = "NW",
			Description = "n",
		};

		var actual = Map.MapObject<CFT_CostReportingFormatType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("71", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "obl";
			subject.Date = "TqMSLIxc";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier2 = "G2S";
			subject.Date2 = "AacZSWtJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("obl", "TqMSLIxc", true)]
	[InlineData("obl", "", false)]
	[InlineData("", "TqMSLIxc", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		subject.ReportTypeCode = "71";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier2 = "G2S";
			subject.Date2 = "AacZSWtJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G2S", "AacZSWtJ", true)]
	[InlineData("G2S", "", false)]
	[InlineData("", "AacZSWtJ", false)]
	public void Validation_AllAreRequiredDateTimeQualifier2(string dateTimeQualifier2, string date2, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		subject.ReportTypeCode = "71";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "obl";
			subject.Date = "TqMSLIxc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
