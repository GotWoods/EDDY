using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*QpI*9*f*lvfS*9*C*wqPs*4*A*Gk8q*2";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "QpI",
			NumberOfTransactionSetsTotalled = 9,
			TotalQualifier = "f",
			DataElementTotalled = "lvfS",
			Total = 9,
			TotalQualifier2 = "C",
			DataElementTotalled2 = "wqPs",
			Total2 = 4,
			TotalQualifier3 = "A",
			DataElementTotalled3 = "Gk8q",
			Total3 = 2,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QpI", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotalled = 9;
		subject.TotalQualifier = "f";
		subject.Total = 9;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotalled(int numberOfTransactionSetsTotalled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "QpI";
		subject.TotalQualifier = "f";
		subject.Total = 9;
		if (numberOfTransactionSetsTotalled > 0)
		subject.NumberOfTransactionSetsTotalled = numberOfTransactionSetsTotalled;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "QpI";
		subject.NumberOfTransactionSetsTotalled = 9;
		subject.Total = 9;
		subject.TotalQualifier = totalQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredTotal(decimal total, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "QpI";
		subject.NumberOfTransactionSetsTotalled = 9;
		subject.TotalQualifier = "f";
		if (total > 0)
		subject.Total = total;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
