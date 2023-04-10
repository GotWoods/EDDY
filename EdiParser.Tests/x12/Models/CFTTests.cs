using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFT*aP*AA*Wd*bbu*Gmv8Gv5j*1zt*NGY102EF*pD*a";

		var expected = new CFT_CostReportingFormatType()
		{
			ReportTypeCode = "aP",
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = "AA"},
			ContractingFundingCode = "Wd",
			DateTimeQualifier = "bbu",
			Date = "Gmv8Gv5j",
			DateTimeQualifier2 = "1zt",
			Date2 = "NGY102EF",
			AppropriationCode = "pD",
			Description = "a",
		};

		var actual = Map.MapObject<CFT_CostReportingFormatType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aP", true)]
	public void Validatation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("bbu", "Gmv8Gv5j", true)]
	[InlineData("", "Gmv8Gv5j", false)]
	[InlineData("bbu", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		subject.ReportTypeCode = "aP";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1zt", "NGY102EF", true)]
	[InlineData("", "NGY102EF", false)]
	[InlineData("1zt", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier2(string dateTimeQualifier2, string date2, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		subject.ReportTypeCode = "aP";
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
