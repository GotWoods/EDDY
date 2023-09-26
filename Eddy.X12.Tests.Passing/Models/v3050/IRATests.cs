using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class IRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IRA*rC*2B*L";

		var expected = new IRA_InvestorReportingActionCode()
		{
			InvestorReportingActionCode = "rC",
			DateTimePeriodFormatQualifier = "2B",
			DateTimePeriod = "L",
		};

		var actual = Map.MapObject<IRA_InvestorReportingActionCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rC", true)]
	public void Validation_RequiredInvestorReportingActionCode(string investorReportingActionCode, bool isValidExpected)
	{
		var subject = new IRA_InvestorReportingActionCode();
		//Required fields
		//Test Parameters
		subject.InvestorReportingActionCode = investorReportingActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "2B";
			subject.DateTimePeriod = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2B", "L", true)]
	[InlineData("2B", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IRA_InvestorReportingActionCode();
		//Required fields
		subject.InvestorReportingActionCode = "rC";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
