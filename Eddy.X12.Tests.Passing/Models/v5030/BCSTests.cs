using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*mI*Bq92Tkgz*O*tvvTqP81*vp*g*A*qB*iJ*3*8*";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "mI",
			Date = "Bq92Tkgz",
			ContractNumber = "O",
			Date2 = "tvvTqP81",
			ContractTypeCode = "vp",
			Description = "g",
			ReferenceIdentification = "A",
			ProgramTypeCode = "qB",
			SecurityLevelCode = "iJ",
			PercentageAsDecimal = 3,
			PercentageAsDecimal2 = 8,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mI", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.Date = "Bq92Tkgz";
		subject.ContractNumber = "O";
		subject.Date2 = "tvvTqP81";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bq92Tkgz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "mI";
		subject.ContractNumber = "O";
		subject.Date2 = "tvvTqP81";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "mI";
		subject.Date = "Bq92Tkgz";
		subject.Date2 = "tvvTqP81";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tvvTqP81", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "mI";
		subject.Date = "Bq92Tkgz";
		subject.ContractNumber = "O";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
