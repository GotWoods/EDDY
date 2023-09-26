using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*Z*pW*z*9*o*e*3E*W*U*JN*1*S";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "Z",
			InformationType = "pW",
			InformationStatusCode = "z",
			ActionCode = "9",
			FinancialInformationTypeCode = "o",
			ConsolidationCode = "e",
			ConditionIndicator = "3E",
			FinancialStatementFormatCode = "W",
			FreeFormInformation = "U",
			UnitOfTimePeriodOrInterval = "JN",
			Description = "1",
			SourceOfDisclosureCode = "S",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		//Test Parameters
		subject.InformationRequestResultCode = informationRequestResultCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "pW", true)]
	[InlineData("z", "", false)]
	[InlineData("", "pW", true)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "pW", true)]
	[InlineData("9", "", false)]
	[InlineData("", "pW", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.ActionCode = actionCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "U", false)]
	[InlineData("o", "", true)]
	[InlineData("", "U", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "o", true)]
	[InlineData("e", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3E", "o", true)]
	[InlineData("3E", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBConditionIndicator(string conditionIndicator, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "o", true)]
	[InlineData("W", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
			subject.FreeFormInformation = "U";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "1";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JN", "1", false)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.Description = description;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.FinancialInformationTypeCode = "o";
			subject.FreeFormInformation = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("JN", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("1", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description(string description, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "Z";
		//Test Parameters
		subject.Description = description;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "JN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
