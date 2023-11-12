using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFS*pJ*5*c8*3*SvRUF3*6*TUs3YF*3*P*H";

		var expected = new BFS_BorrowerFinancialSummary()
		{
			RateValueQualifier = "pJ",
			MonetaryAmount = 5,
			RateValueQualifier2 = "c8",
			MonetaryAmount2 = 3,
			Date = "SvRUF3",
			MonetaryAmount3 = 6,
			Date2 = "TUs3YF",
			MonetaryAmount4 = 3,
			YesNoConditionOrResponseCode = "P",
			YesNoConditionOrResponseCode2 = "H",
		};

		var actual = Map.MapObject<BFS_BorrowerFinancialSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pJ", 5, true)]
	[InlineData("pJ", 0, false)]
	[InlineData("", 5, true)]
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
	[InlineData("c8", 3, true)]
	[InlineData("c8", 0, false)]
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
	[InlineData("SvRUF3", 6, true)]
	[InlineData("SvRUF3", 0, false)]
	[InlineData("", 6, true)]
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
	[InlineData("TUs3YF", 3, true)]
	[InlineData("TUs3YF", 0, false)]
	[InlineData("", 3, true)]
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
