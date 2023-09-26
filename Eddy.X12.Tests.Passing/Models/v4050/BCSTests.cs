using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*oS*k9p1unHg*q*Jy7lL1wh*mM*i*2*nZ*2J*7*2*";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "oS",
			Date = "k9p1unHg",
			ContractNumber = "q",
			Date2 = "Jy7lL1wh",
			ContractTypeCode = "mM",
			Description = "i",
			ReferenceIdentification = "2",
			ProgramTypeCode = "nZ",
			SecurityLevelCode = "2J",
			PercentageAsDecimal = 7,
			PercentageAsDecimal2 = 2,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oS", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.Date = "k9p1unHg";
		subject.ContractNumber = "q";
		subject.Date2 = "Jy7lL1wh";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k9p1unHg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "oS";
		subject.ContractNumber = "q";
		subject.Date2 = "Jy7lL1wh";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "oS";
		subject.Date = "k9p1unHg";
		subject.Date2 = "Jy7lL1wh";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jy7lL1wh", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "oS";
		subject.Date = "k9p1unHg";
		subject.ContractNumber = "q";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
