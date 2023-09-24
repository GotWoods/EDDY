using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*JqQ*8*9*VfOu*1*S*qM9t*2*C*f1L4*7";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "JqQ",
			NumberOfTransactionSetsTotaled = 8,
			TotalQualifier = "9",
			DataElementTotaled = "VfOu",
			Total = 1,
			TotalQualifier2 = "S",
			DataElementTotaled2 = "qM9t",
			Total2 = 2,
			TotalQualifier3 = "C",
			DataElementTotaled3 = "f1L4",
			Total3 = 7,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JqQ", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotaled = 8;
		subject.TotalQualifier = "9";
		subject.Total = 1;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "S";
			subject.Total2 = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "C";
			subject.Total3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotaled(int numberOfTransactionSetsTotaled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "JqQ";
		subject.TotalQualifier = "9";
		subject.Total = 1;
		if (numberOfTransactionSetsTotaled > 0)
			subject.NumberOfTransactionSetsTotaled = numberOfTransactionSetsTotaled;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "S";
			subject.Total2 = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "C";
			subject.Total3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "JqQ";
		subject.NumberOfTransactionSetsTotaled = 8;
		subject.Total = 1;
		subject.TotalQualifier = totalQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "S";
			subject.Total2 = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "C";
			subject.Total3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredTotal(decimal total, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "JqQ";
		subject.NumberOfTransactionSetsTotaled = 8;
		subject.TotalQualifier = "9";
		if (total > 0)
			subject.Total = total;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "S";
			subject.Total2 = 2;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "C";
			subject.Total3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("S", 2, true)]
	[InlineData("S", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredTotalQualifier2(string totalQualifier2, decimal total2, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "JqQ";
		subject.NumberOfTransactionSetsTotaled = 8;
		subject.TotalQualifier = "9";
		subject.Total = 1;
		subject.TotalQualifier2 = totalQualifier2;
		if (total2 > 0)
			subject.Total2 = total2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "C";
			subject.Total3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 7, true)]
	[InlineData("C", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredTotalQualifier3(string totalQualifier3, decimal total3, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "JqQ";
		subject.NumberOfTransactionSetsTotaled = 8;
		subject.TotalQualifier = "9";
		subject.Total = 1;
		subject.TotalQualifier3 = totalQualifier3;
		if (total3 > 0)
			subject.Total3 = total3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "S";
			subject.Total2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
