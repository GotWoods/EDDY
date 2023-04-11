using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*w*NW*i*f*H*I*jX*9*C*6G*b*X";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "w",
			InformationTypeCode = "NW",
			InformationStatusCode = "i",
			ActionCode = "f",
			FinancialInformationTypeCode = "H",
			ConsolidationCode = "I",
			ConditionIndicatorCode = "jX",
			FinancialStatementFormatCode = "9",
			FreeFormInformation = "C",
			UnitOfTimePeriodOrIntervalCode = "6G",
			Description = "b",
			SourceOfDisclosureCode = "X",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = informationRequestResultCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "NW", true)]
	[InlineData("i", "", false)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationTypeCode = informationTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "NW", true)]
	[InlineData("f", "", false)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.ActionCode = actionCode;
		subject.InformationTypeCode = informationTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "C", false)]
	[InlineData("", "C", true)]
	[InlineData("H", "", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "H", true)]
	[InlineData("I", "", false)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "H", true)]
	[InlineData("jX", "", false)]
	public void Validation_ARequiresBConditionIndicatorCode(string conditionIndicatorCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "H", true)]
	[InlineData("9", "", false)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6G", "b", false)]
	[InlineData("", "b", true)]
	[InlineData("6G", "", true)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6G", "H", false)]
	[InlineData("","H", true)]
	[InlineData("6G", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("b", "H", false)]
	[InlineData("","H", true)]
	[InlineData("b", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description(string description, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		subject.InformationRequestResultCode = "w";
		subject.Description = description;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
