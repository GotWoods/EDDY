using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*8*2*8*6**4*6*9*x**6*7";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "8",
			AssignedIdentification = "2",
			Rate = 8,
			PercentageAsDecimal = 6,
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Quantity2 = 6,
			MonetaryAmount = 9,
			Amount = "x",
			CompositeUnitOfMeasure2 = null,
			RangeMinimum = 6,
			RangeMaximum = 7,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.RelationshipCode = relationshipCode;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 4;
			subject.Quantity2 = 6;
			subject.MonetaryAmount = 9;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 6;
			subject.MonetaryAmount = 9;
			subject.Amount = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 6, false)]
	[InlineData(8, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfRate(decimal rate, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "8";
		//Test Parameters
        if (rate > 0)
        {
            subject.Rate = rate;
            subject.MonetaryAmount = 1;
        }

        if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;

		

		//If one, at least one
		if(subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.MonetaryAmount = 9;
			subject.Amount = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(8, 4, 6, 9, true)]
	[InlineData(8, 0, 0, 0, false)]
	[InlineData(0, 4, 6, 9, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "8";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one, at least one
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 6;
			subject.Amount = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(6, 9, "x", true)]
	[InlineData(6, 0, "", false)]
	[InlineData(0, 9, "x", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_PercentageAsDecimal(decimal percentageAsDecimal, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "8";
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 4;
			subject.Quantity2 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "A", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "8";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 4;
			subject.Quantity2 = 6;
			subject.MonetaryAmount = 9;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 6;
			subject.MonetaryAmount = 9;
			subject.Amount = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "8";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 4;
			subject.Quantity2 = 6;
			subject.MonetaryAmount = 9;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 6;
			subject.MonetaryAmount = 9;
			subject.Amount = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
