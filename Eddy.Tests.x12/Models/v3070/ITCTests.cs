using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*0*cM*j*7*n*1*FX*4*L*7p*8*X";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "0",
			InformationType = "cM",
			InformationStatusCode = "j",
			ActionCode = "7",
			FinancialInformationTypeCode = "n",
			ConsolidationCode = "1",
			ConditionIndicator = "FX",
			FinancialStatementFormatCode = "4",
			FreeFormMessage = "L",
			UnitOfTimePeriodOrInterval = "7p",
			Description = "8",
			SourceOfDisclosureCode = "X",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		//Test Parameters
		subject.InformationRequestResultCode = informationRequestResultCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "cM", true)]
	[InlineData("j", "", false)]
	[InlineData("", "cM", true)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "cM", true)]
	[InlineData("7", "", false)]
	[InlineData("", "cM", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.ActionCode = actionCode;
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "L", false)]
	[InlineData("n", "", true)]
	[InlineData("", "L", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "n", true)]
	[InlineData("1", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FX", "n", true)]
	[InlineData("FX", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBConditionIndicator(string conditionIndicator, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "n", true)]
	[InlineData("4", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7p", "8", false)]
	[InlineData("7p", "", true)]
	[InlineData("", "8", true)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "0";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
