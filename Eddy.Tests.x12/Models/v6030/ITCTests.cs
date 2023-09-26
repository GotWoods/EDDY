using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITC*a*zj*z*V*V*t*HV*T*d*E3*A*l";

		var expected = new ITC_InformationTypeAndCommentResults()
		{
			InformationRequestResultCode = "a",
			InformationTypeCode = "zj",
			InformationStatusCode = "z",
			ActionCode = "V",
			FinancialInformationTypeCode = "V",
			ConsolidationCode = "t",
			ConditionIndicatorCode = "HV",
			FinancialStatementFormatCode = "T",
			FreeFormInformation = "d",
			UnitOfTimePeriodOrIntervalCode = "E3",
			Description = "A",
			SourceOfDisclosureCode = "l",
		};

		var actual = Map.MapObject<ITC_InformationTypeAndCommentResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredInformationRequestResultCode(string informationRequestResultCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		//Test Parameters
		subject.InformationRequestResultCode = informationRequestResultCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "zj", true)]
	[InlineData("z", "", false)]
	[InlineData("", "zj", true)]
	public void Validation_ARequiresBInformationStatusCode(string informationStatusCode, string informationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		subject.InformationTypeCode = informationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "zj", true)]
	[InlineData("V", "", false)]
	[InlineData("", "zj", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string informationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.ActionCode = actionCode;
		subject.InformationTypeCode = informationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "d", false)]
	[InlineData("V", "", true)]
	[InlineData("", "d", true)]
	public void Validation_OnlyOneOfFinancialInformationTypeCode(string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "V", true)]
	[InlineData("t", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBConsolidationCode(string consolidationCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HV", "V", true)]
	[InlineData("HV", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBConditionIndicatorCode(string conditionIndicatorCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "V", true)]
	[InlineData("T", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBFinancialStatementFormatCode(string financialStatementFormatCode, string financialInformationTypeCode, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.FinancialStatementFormatCode = financialStatementFormatCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
			subject.FreeFormInformation = "d";
		}
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.Description = "A";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E3", "A", false)]
	public void Validation_OnlyOneOfUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, string description, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		subject.Description = description;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.FinancialInformationTypeCode) || !string.IsNullOrEmpty(subject.FreeFormInformation))
		{
			subject.FinancialInformationTypeCode = "V";
			subject.FreeFormInformation = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("E3", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.Description = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("A", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description(string description, string financialInformationTypeCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new ITC_InformationTypeAndCommentResults();
		//Required fields
		subject.InformationRequestResultCode = "a";
		//Test Parameters
		subject.Description = description;
		subject.FinancialInformationTypeCode = financialInformationTypeCode;
		subject.FreeFormInformation = freeFormInformation;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.UnitOfTimePeriodOrIntervalCode = "E3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
