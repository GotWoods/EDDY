using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*6*0e*m*E*q*q*B8*7*C*u9*J*c";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "6",
			InformationType = "0e",
			InformationStatusCode = "m",
			ActionCode = "E",
			FinancialInformationTypeCode = "q",
			ConsolidationCode = "q",
			ConditionIndicator = "B8",
			FinancialStatementFormatCode = "7",
			FreeFormMessage = "C",
			UnitOfTimePeriodOrInterval = "u9",
			Description = "J",
			SourceOfDisclosureCode = "c",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		//Test Parameters
		subject.InformationRequestResultCode = informationRequestResultCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "0e", true)]
	[InlineData("m", "", false)]
	[InlineData("", "0e", true)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "0e", true)]
	[InlineData("E", "", false)]
	[InlineData("", "0e", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.ActionCode = actionCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "C", false)]
	[InlineData("q", "", true)]
	[InlineData("", "C", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "q", true)]
	[InlineData("q", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B8", "q", true)]
	[InlineData("B8", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBConditionIndicator(string conditionIndicator, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "q", true)]
	[InlineData("7", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
			subject.FreeFormMessage = "C";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "J";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u9", "J", false)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.Description = description;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.FinancialInformationTypeCode = "q";
			subject.FreeFormMessage = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("u9", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("J", "", "", false)]
	
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description(string description, string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "6";
		//Test Parameters
		subject.Description = description;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "u9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
