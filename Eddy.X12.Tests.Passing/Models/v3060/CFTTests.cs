using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFT*pH**9I*vdJ*Rny2Fx*Wp6*hWKSPp*K2*t";

		var expected = new CFT_CostReportingFormatType()
		{
			ReportTypeCode = "pH",
			CompositeUnitOfMeasure = null,
			ContractingFundingCode = "9I",
			DateTimeQualifier = "vdJ",
			Date = "Rny2Fx",
			DateTimeQualifier2 = "Wp6",
			Date2 = "hWKSPp",
			AppropriationCode = "K2",
			Description = "t",
		};

		var actual = Map.MapObject<CFT_CostReportingFormatType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pH", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "vdJ";
			subject.Date = "Rny2Fx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier2 = "Wp6";
			subject.Date2 = "hWKSPp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vdJ", "Rny2Fx", true)]
	[InlineData("vdJ", "", false)]
	[InlineData("", "Rny2Fx", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		subject.ReportTypeCode = "pH";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.DateTimeQualifier2 = "Wp6";
			subject.Date2 = "hWKSPp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Wp6", "hWKSPp", true)]
	[InlineData("Wp6", "", false)]
	[InlineData("", "hWKSPp", false)]
	public void Validation_AllAreRequiredDateTimeQualifier2(string dateTimeQualifier2, string date2, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		subject.ReportTypeCode = "pH";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "vdJ";
			subject.Date = "Rny2Fx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
