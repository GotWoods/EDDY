using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCM*lS*8712NyzE*rhYilWWu*B*d*tD*jS*E*3C*tX*lJ*XzF";

		var expected = new BCM_BeginningSegmentForContractorCostDataReporting()
		{
			TransactionSetPurposeCode = "lS",
			Date = "8712NyzE",
			Date2 = "rhYilWWu",
			ContractNumber = "B",
			FreeFormDescription = "d",
			ContractActionCode = "tD",
			ProgramTypeCode = "jS",
			FreeFormDescription2 = "E",
			ContractingFundingCode = "3C",
			ContractTypeCode = "tX",
			SecurityLevelCode = "lJ",
			CurrencyCode = "XzF",
		};

		var actual = Map.MapObject<BCM_BeginningSegmentForContractorCostDataReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lS", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.Date = "8712NyzE";
		subject.Date2 = "rhYilWWu";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//At Least one
		subject.ContractNumber = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8712NyzE", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "lS";
		subject.Date2 = "rhYilWWu";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.ContractNumber = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rhYilWWu", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "lS";
		subject.Date = "8712NyzE";
		//Test Parameters
		subject.Date2 = date2;
		//At Least one
		subject.ContractNumber = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("B", "d", true)]
	[InlineData("B", "", true)]
	[InlineData("", "d", true)]
	public void Validation_AtLeastOneContractNumber(string contractNumber, string freeFormDescription, bool isValidExpected)
	{
		var subject = new BCM_BeginningSegmentForContractorCostDataReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "lS";
		subject.Date = "8712NyzE";
		subject.Date2 = "rhYilWWu";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
