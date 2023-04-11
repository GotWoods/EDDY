using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*y2F*3*Z*YfET*9*i*q6ae*3*b*9aAY*7";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "y2F",
			NumberOfTransactionSetsTotaled = 3,
			TotalQualifier = "Z",
			DataElementTotaled = "YfET",
			Total = 9,
			TotalQualifier2 = "i",
			DataElementTotaled2 = "q6ae",
			Total2 = 3,
			TotalQualifier3 = "b",
			DataElementTotaled3 = "9aAY",
			Total3 = 7,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y2F", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotaled = 3;
		subject.TotalQualifier = "Z";
		subject.Total = 9;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotaled(int numberOfTransactionSetsTotaled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "y2F";
		subject.TotalQualifier = "Z";
		subject.Total = 9;
		if (numberOfTransactionSetsTotaled > 0)
		subject.NumberOfTransactionSetsTotaled = numberOfTransactionSetsTotaled;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "y2F";
		subject.NumberOfTransactionSetsTotaled = 3;
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
		subject.TransactionSetIdentifierCode = "y2F";
		subject.NumberOfTransactionSetsTotaled = 3;
		subject.TotalQualifier = "Z";
		if (total > 0)
		subject.Total = total;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("i", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("i", 0, false)]
	public void Validation_AllAreRequiredTotalQualifier2(string totalQualifier2, decimal total2, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "y2F";
		subject.NumberOfTransactionSetsTotaled = 3;
		subject.TotalQualifier = "Z";
		subject.Total = 9;
		subject.TotalQualifier2 = totalQualifier2;
		if (total2 > 0)
		subject.Total2 = total2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("b", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("b", 0, false)]
	public void Validation_AllAreRequiredTotalQualifier3(string totalQualifier3, decimal total3, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "y2F";
		subject.NumberOfTransactionSetsTotaled = 3;
		subject.TotalQualifier = "Z";
		subject.Total = 9;
		subject.TotalQualifier3 = totalQualifier3;
		if (total3 > 0)
		subject.Total3 = total3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
