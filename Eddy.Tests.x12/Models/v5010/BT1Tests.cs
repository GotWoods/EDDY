using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*Tgl*6*l*1pab*6*w*NYbM*9*A*9BpQ*2";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "Tgl",
			NumberOfTransactionSetsTotaled = 6,
			TotalQualifier = "l",
			DataElementTotaled = "1pab",
			Total = 6,
			TotalQualifier2 = "w",
			DataElementTotaled2 = "NYbM",
			Total2 = 9,
			TotalQualifier3 = "A",
			DataElementTotaled3 = "9BpQ",
			Total3 = 2,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tgl", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotaled = 6;
		subject.TotalQualifier = "l";
		subject.Total = 6;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "w";
			subject.Total2 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "A";
			subject.Total3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotaled(int numberOfTransactionSetsTotaled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "Tgl";
		subject.TotalQualifier = "l";
		subject.Total = 6;
		if (numberOfTransactionSetsTotaled > 0)
			subject.NumberOfTransactionSetsTotaled = numberOfTransactionSetsTotaled;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "w";
			subject.Total2 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "A";
			subject.Total3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "Tgl";
		subject.NumberOfTransactionSetsTotaled = 6;
		subject.Total = 6;
		subject.TotalQualifier = totalQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "w";
			subject.Total2 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "A";
			subject.Total3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredTotal(decimal total, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "Tgl";
		subject.NumberOfTransactionSetsTotaled = 6;
		subject.TotalQualifier = "l";
		if (total > 0)
			subject.Total = total;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "w";
			subject.Total2 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "A";
			subject.Total3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 9, true)]
	[InlineData("w", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredTotalQualifier2(string totalQualifier2, decimal total2, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "Tgl";
		subject.NumberOfTransactionSetsTotaled = 6;
		subject.TotalQualifier = "l";
		subject.Total = 6;
		subject.TotalQualifier2 = totalQualifier2;
		if (total2 > 0)
			subject.Total2 = total2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "A";
			subject.Total3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("A", 2, true)]
	[InlineData("A", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredTotalQualifier3(string totalQualifier3, decimal total3, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "Tgl";
		subject.NumberOfTransactionSetsTotaled = 6;
		subject.TotalQualifier = "l";
		subject.Total = 6;
		subject.TotalQualifier3 = totalQualifier3;
		if (total3 > 0)
			subject.Total3 = total3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "w";
			subject.Total2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
