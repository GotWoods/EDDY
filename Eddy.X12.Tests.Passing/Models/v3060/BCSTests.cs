using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*VM*LygTS9*J*99zQdz*KD*0*Y*Th*3c*5*4*";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "VM",
			Date = "LygTS9",
			ContractNumber = "J",
			Date2 = "99zQdz",
			ContractTypeCode = "KD",
			Description = "0",
			ReferenceIdentification = "Y",
			ProgramTypeCode = "Th",
			SecurityLevelCode = "3c",
			Percent = 5,
			Percent2 = 4,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VM", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.Date = "LygTS9";
		subject.ContractNumber = "J";
		subject.Date2 = "99zQdz";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LygTS9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "VM";
		subject.ContractNumber = "J";
		subject.Date2 = "99zQdz";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "VM";
		subject.Date = "LygTS9";
		subject.Date2 = "99zQdz";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("99zQdz", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "VM";
		subject.Date = "LygTS9";
		subject.ContractNumber = "J";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
