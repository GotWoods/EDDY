using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*v*x*7*5**4*2*5*q**6*7";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "v",
			AssignedIdentification = "x",
			Rate = 7,
			Percent = 5,
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Quantity2 = 2,
			MonetaryAmount = 5,
			Amount = "q",
			CompositeUnitOfMeasure2 = null,
			RangeMinimum = 6,
			RangeMaximum = 7,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.RelationshipCode = relationshipCode;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 7;
			subject.Quantity = 4;
			subject.Quantity2 = 2;
			subject.MonetaryAmount = 5;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 5;
			subject.MonetaryAmount = 5;
			subject.Amount = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 5, false)]
	[InlineData(7, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal rate, decimal percent, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "v";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (percent > 0) 
			subject.Percent = percent;
		//If one, at least one
		if(subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 4;
			subject.Quantity2 = 2;
			subject.MonetaryAmount = 5;
		}
		if(subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.MonetaryAmount = 5;
			subject.Amount = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(7, 4, 2, 5, true)]
	[InlineData(7, 0, 0, 0, false)]
	[InlineData(0, 4, 2, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "v";
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
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 5;
			subject.Amount = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(5, 5, "q", true)]
	[InlineData(5, 0, "", false)]
	[InlineData(0, 5, "q", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Percent(decimal percent, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "v";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.Rate = 7;
			subject.Quantity = 4;
			subject.Quantity2 = 2;
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
		subject.RelationshipCode = "v";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 7;
			subject.Quantity = 4;
			subject.Quantity2 = 2;
			subject.MonetaryAmount = 5;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 5;
			subject.MonetaryAmount = 5;
			subject.Amount = "q";
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
		subject.RelationshipCode = "v";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 7;
			subject.Quantity = 4;
			subject.Quantity2 = 2;
			subject.MonetaryAmount = 5;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 5;
			subject.MonetaryAmount = 5;
			subject.Amount = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
