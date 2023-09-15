using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*SOU*3*X*B6KI*6*U*sW9U*4*T*9c8A*2";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "SOU",
			NumberOfTransactionSetsTotalled = 3,
			TotalQualifier = "X",
			DataElementTotalled = "B6KI",
			Total = 6,
			TotalQualifier2 = "U",
			DataElementTotalled2 = "sW9U",
			Total2 = 4,
			TotalQualifier3 = "T",
			DataElementTotalled3 = "9c8A",
			Total3 = 2,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SOU", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotalled = 3;
		subject.TotalQualifier = "X";
		subject.Total = 6;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotalled(int numberOfTransactionSetsTotalled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "SOU";
		subject.TotalQualifier = "X";
		subject.Total = 6;
		if (numberOfTransactionSetsTotalled > 0)
			subject.NumberOfTransactionSetsTotalled = numberOfTransactionSetsTotalled;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "SOU";
		subject.NumberOfTransactionSetsTotalled = 3;
		subject.Total = 6;
		subject.TotalQualifier = totalQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredTotal(decimal total, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "SOU";
		subject.NumberOfTransactionSetsTotalled = 3;
		subject.TotalQualifier = "X";
		if (total > 0)
			subject.Total = total;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
