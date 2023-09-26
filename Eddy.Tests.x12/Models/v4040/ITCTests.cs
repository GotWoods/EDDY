using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*d*TA*n*s*r*U*wa*U*n*w7*T*C";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "d",
			InformationType = "TA",
			InformationStatusCode = "n",
			ActionCode = "s",
			FinancialInformationTypeCode = "r",
			ConsolidationCode = "U",
			ConditionIndicator = "wa",
			FinancialStatementFormatCode = "U",
			FreeFormMessage = "n",
			UnitOfTimePeriodOrInterval = "w7",
			Description = "T",
			SourceOfDisclosureCode = "C",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		//Test Parameters
		subject.InformationRequestResultCode = informationRequestResultCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "TA", true)]
	[InlineData("n", "", false)]
	[InlineData("", "TA", true)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "TA", true)]
	[InlineData("s", "", false)]
	[InlineData("", "TA", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationType, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.ActionCode = actionCode;
		subject.InformationType = informationType;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "n", false)]
	[InlineData("r", "", true)]
	[InlineData("", "n", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "r", true)]
	[InlineData("U", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wa", "r", true)]
	[InlineData("wa", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBConditionIndicator(string conditionIndicator, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "r", true)]
	[InlineData("U", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
			subject.FreeFormMessage = "n";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.Description = "T";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w7", "T", false)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.Description = description;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.FinancialInformationTypeCode = "r";
			subject.FreeFormMessage = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("w7", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("T", "", "", false)]
	
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description(string description, string financialInformationTypeCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "d";
		//Test Parameters
		subject.Description = description;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.UnitOfTimePeriodOrInterval = "w7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
