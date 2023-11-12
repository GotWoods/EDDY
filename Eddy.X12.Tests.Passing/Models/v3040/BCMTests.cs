using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCM*1N*WTkS0Y*WP01L2*l*Q*du*uo*7*vV*7E*lk*Fsd";

		var expected = new BCM_BeginningSegmentForContractorCostDataReporting()
		{
			TransactionSetPurposeCode = "1N",
			Date = "WTkS0Y",
			Date2 = "WP01L2",
			ContractNumber = "l",
			FreeFormDescription = "Q",
			ContractActionCode = "du",
			ProgramTypeCode = "uo",
			FreeFormDescription2 = "7",
			ContractingFundingCode = "vV",
			ContractTypeCode = "7E",
			SecurityLevelCode = "lk",
			CurrencyCode = "Fsd",
		};

		var actual = Map.MapObject<BCM_BeginningSegmentForContractorCostDataReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1N", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.Date = "WTkS0Y";
		subject.Date2 = "WP01L2";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//At Least one
		subject.ContractNumber = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WTkS0Y", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "1N";
		subject.Date2 = "WP01L2";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.ContractNumber = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WP01L2", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "1N";
		subject.Date = "WTkS0Y";
		//Test Parameters
		subject.Date2 = date2;
		//At Least one
		subject.ContractNumber = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("l", "Q", true)]
	[InlineData("l", "", true)]
	[InlineData("", "Q", true)]
	public void Validation_AtLeastOneContractNumber(string contractNumber, string freeFormDescription, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "1N";
		subject.Date = "WTkS0Y";
		subject.Date2 = "WP01L2";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
