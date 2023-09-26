using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*9*f*5*2**9*4*5*5**7*4";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "9",
			AssignedIdentification = "f",
			Rate = 5,
			PercentageAsDecimal = 2,
			CompositeUnitOfMeasure = null,
			Quantity = 9,
			Quantity2 = 4,
			MonetaryAmount = 5,
			Amount = "5",
			CompositeUnitOfMeasure2 = null,
			RangeMinimum = 7,
			RangeMaximum = 4,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.RelationshipCode = relationshipCode;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 5;
			subject.Quantity = 9;
			subject.Quantity2 = 4;
			subject.MonetaryAmount = 5;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 2;
			subject.MonetaryAmount = 5;
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 2, false)]
	[InlineData(5, 0, true)]
	[InlineData(0, 2, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal rate, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "9";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one, at least one
		if(subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 9;
			subject.Quantity2 = 4;
			subject.MonetaryAmount = 5;
		}
		if(subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.MonetaryAmount = 5;
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(5, 9, 4, 5, true)]
	[InlineData(5, 0, 0, 0, false)]
	[InlineData(0, 9, 4, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "9";
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
			subject.PercentageAsDecimal = 2;
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(2, 5, "5", true)]
	[InlineData(2, 0, "", false)]
	[InlineData(0, 5, "5", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_PercentageAsDecimal(decimal percentageAsDecimal, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "9";
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.Rate = 5;
			subject.Quantity = 9;
			subject.Quantity2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "9";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 5;
			subject.Quantity = 9;
			subject.Quantity2 = 4;
			subject.MonetaryAmount = 5;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 2;
			subject.MonetaryAmount = 5;
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "9";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 5;
			subject.Quantity = 9;
			subject.Quantity2 = 4;
			subject.MonetaryAmount = 5;
		}
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.PercentageAsDecimal = 2;
			subject.MonetaryAmount = 5;
			subject.Amount = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
