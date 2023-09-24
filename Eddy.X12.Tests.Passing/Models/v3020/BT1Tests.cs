using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT1*BZ6*7*5*iNjo*8*C*9pIv*6*p*fwIF*6";

		var expected = new BT1_BatchTotals()
		{
			TransactionSetIdentifierCode = "BZ6",
			NumberOfTransactionSetsTotalled = 7,
			TotalQualifier = "5",
			DataElementTotalled = "iNjo",
			Total = 8,
			TotalQualifier2 = "C",
			DataElementTotalled2 = "9pIv",
			Total2 = 6,
			TotalQualifier3 = "p",
			DataElementTotalled3 = "fwIF",
			Total3 = 6,
		};

		var actual = Map.MapObject<BT1_BatchTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BZ6", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.NumberOfTransactionSetsTotalled = 7;
		subject.TotalQualifier = "5";
		subject.Total = 8;
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "C";
			subject.Total2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "p";
			subject.Total3 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfTransactionSetsTotalled(int numberOfTransactionSetsTotalled, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "BZ6";
		subject.TotalQualifier = "5";
		subject.Total = 8;
		if (numberOfTransactionSetsTotalled > 0)
			subject.NumberOfTransactionSetsTotalled = numberOfTransactionSetsTotalled;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "C";
			subject.Total2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "p";
			subject.Total3 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTotalQualifier(string totalQualifier, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "BZ6";
		subject.NumberOfTransactionSetsTotalled = 7;
		subject.Total = 8;
		subject.TotalQualifier = totalQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "C";
			subject.Total2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "p";
			subject.Total3 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredTotal(decimal total, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "BZ6";
		subject.NumberOfTransactionSetsTotalled = 7;
		subject.TotalQualifier = "5";
		if (total > 0)
			subject.Total = total;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "C";
			subject.Total2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "p";
			subject.Total3 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 6, true)]
	[InlineData("C", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredTotalQualifier2(string totalQualifier2, decimal total2, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "BZ6";
		subject.NumberOfTransactionSetsTotalled = 7;
		subject.TotalQualifier = "5";
		subject.Total = 8;
		subject.TotalQualifier2 = totalQualifier2;
		if (total2 > 0)
			subject.Total2 = total2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier3) || !string.IsNullOrEmpty(subject.TotalQualifier3) || subject.Total3 > 0)
		{
			subject.TotalQualifier3 = "p";
			subject.Total3 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("p", 6, true)]
	[InlineData("p", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredTotalQualifier3(string totalQualifier3, decimal total3, bool isValidExpected)
	{
		var subject = new BT1_BatchTotals();
		subject.TransactionSetIdentifierCode = "BZ6";
		subject.NumberOfTransactionSetsTotalled = 7;
		subject.TotalQualifier = "5";
		subject.Total = 8;
		subject.TotalQualifier3 = totalQualifier3;
		if (total3 > 0)
			subject.Total3 = total3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TotalQualifier2) || !string.IsNullOrEmpty(subject.TotalQualifier2) || subject.Total2 > 0)
		{
			subject.TotalQualifier2 = "C";
			subject.Total2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
