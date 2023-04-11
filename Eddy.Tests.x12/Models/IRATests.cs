using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IRA*Bb*TG*Z";

		var expected = new IRA_InvestorReportingAction()
		{
			InvestorReportingActionCode = "Bb",
			DateTimePeriodFormatQualifier = "TG",
			DateTimePeriod = "Z",
		};

		var actual = Map.MapObject<IRA_InvestorReportingAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bb", true)]
	public void Validation_RequiredInvestorReportingActionCode(string investorReportingActionCode, bool isValidExpected)
	{
		var subject = new IRA_InvestorReportingAction();
		subject.InvestorReportingActionCode = investorReportingActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("TG", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("TG", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IRA_InvestorReportingAction();
		subject.InvestorReportingActionCode = "Bb";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
