using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFS*du*8*xo*6*IlcIV6*1*TRMtK4*2*Qn*0";

		var expected = new BFS_BorrowerFinancialSummary()
		{
			RateValueQualifier = "du",
			MonetaryAmount = 8,
			RateValueQualifier2 = "xo",
			MonetaryAmount2 = 6,
			Date = "IlcIV6",
			MonetaryAmount3 = 1,
			Date2 = "TRMtK4",
			MonetaryAmount4 = 2,
			TypeOfIncomeCode = "Qn",
			YesNoConditionOrResponseCode = "0",
		};

		var actual = Map.MapObject<BFS_BorrowerFinancialSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("du", 8, true)]
	[InlineData("du", 0, false)]
	[InlineData("", 8, true)]
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
	[InlineData("xo", 6, true)]
	[InlineData("xo", 0, false)]
	[InlineData("", 6, true)]
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
	[InlineData("IlcIV6", 1, true)]
	[InlineData("IlcIV6", 0, false)]
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
	[InlineData("TRMtK4", 2, true)]
	[InlineData("TRMtK4", 0, false)]
	[InlineData("", 2, true)]
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
