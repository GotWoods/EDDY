using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCM*BA*7cPBeojz*j31wN35J*q*5*2A*ND*k*5N*As*tb*WXx";

		var expected = new BCM_BeginningSegmentForContractorCostDataReporting()
		{
			TransactionSetPurposeCode = "BA",
			Date = "7cPBeojz",
			Date2 = "j31wN35J",
			ContractNumber = "q",
			FreeFormDescription = "5",
			ContractActionCode = "2A",
			ProgramTypeCode = "ND",
			FreeFormDescription2 = "k",
			ContractingFundingCode = "5N",
			ContractTypeCode = "As",
			SecurityLevelCode = "tb",
			CurrencyCode = "WXx",
		};

		var actual = Map.MapObject<BCM_BeginningSegmentForContractorCostDataReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BA", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		subject.Date = "7cPBeojz";
		subject.Date2 = "j31wN35J";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
        subject.FreeFormDescription = "ABAD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7cPBeojz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		subject.TransactionSetPurposeCode = "BA";
		subject.Date2 = "j31wN35J";
		subject.Date = date;
		subject.FreeFormDescription = "ABAD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j31wN35J", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		subject.TransactionSetPurposeCode = "BA";
		subject.Date = "7cPBeojz";
		subject.Date2 = date2;
        subject.FreeFormDescription = "ABAD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("q","5", true)]
	[InlineData("", "5", true)]
	[InlineData("q", "", true)]
	public void Validation_AtLeastOneContractNumber(string contractNumber, string freeFormDescription, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		subject.TransactionSetPurposeCode = "BA";
		subject.Date = "7cPBeojz";
		subject.Date2 = "j31wN35J";
		subject.ContractNumber = contractNumber;
		subject.FreeFormDescription = freeFormDescription;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
