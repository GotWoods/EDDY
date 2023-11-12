using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFS*7K*4*7k*3*loux1O20*1*pjnLTWfX*5*cW*k";

		var expected = new BFS_BorrowerFinancialSummary()
		{
			RateValueQualifier = "7K",
			MonetaryAmount = 4,
			RateValueQualifier2 = "7k",
			MonetaryAmount2 = 3,
			Date = "loux1O20",
			MonetaryAmount3 = 1,
			Date2 = "pjnLTWfX",
			MonetaryAmount4 = 5,
			TypeOfIncomeCode = "cW",
			YesNoConditionOrResponseCode = "k",
		};

		var actual = Map.MapObject<BFS_BorrowerFinancialSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7K", 4, true)]
	[InlineData("7K", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7k", 3, true)]
	[InlineData("7k", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBRateValueQualifier2(string rateValueQualifier2, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("loux1O20", 1, true)]
	[InlineData("loux1O20", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBDate(string date, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		//Required fields
		//Test Parameters
		subject.Date = date;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pjnLTWfX", 5, true)]
	[InlineData("pjnLTWfX", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBDate2(string date2, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new BFS_BorrowerFinancialSummary();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
