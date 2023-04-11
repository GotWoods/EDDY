using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFS*Vq*5*37*6*HZWyzVEg*5*T4x07Ft8*3*Lp*j";

		var expected = new BFS_BorrowerFinancialSummary()
		{
			RateValueQualifier = "Vq",
			MonetaryAmount = 5,
			RateValueQualifier2 = "37",
			MonetaryAmount2 = 6,
			Date = "HZWyzVEg",
			MonetaryAmount3 = 5,
			Date2 = "T4x07Ft8",
			MonetaryAmount4 = 3,
			TypeOfIncomeCode = "Lp",
			YesNoConditionOrResponseCode = "j",
		};

		var actual = Map.MapObject<BFS_BorrowerFinancialSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("Vq", 0, false)]
	public void Validation_ARequiresBRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 6, true)]
	[InlineData("37", 0, false)]
	public void Validation_ARequiresBRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("HZWyzVEg", 0, false)]
	public void Validation_ARequiresBDate(string date, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		subject.Date = date;
		if (monetaryAmount3 > 0)
		subject.MonetaryAmount3 = monetaryAmount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("T4x07Ft8", 0, false)]
	public void Validation_ARequiresBDate2(string date2, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		subject.Date2 = date2;
		if (monetaryAmount4 > 0)
		subject.MonetaryAmount4 = monetaryAmount4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
