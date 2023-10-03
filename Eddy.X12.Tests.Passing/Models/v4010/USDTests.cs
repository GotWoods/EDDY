using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010.Composites;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*4*S*8*6**9*7*4*B**7*5";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "4",
			AssignedIdentification = "S",
			Rate = 8,
			Percent = 6,
			CompositeUnitOfMeasure = null,
			Quantity = 9,
			Quantity2 = 7,
			MonetaryAmount = 4,
			Amount = "B",
			CompositeUnitOfMeasure2 = null,
			RangeMinimum = 7,
			RangeMaximum = 5,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
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
			subject.Quantity = 9;
			subject.Quantity2 = 7;
			subject.MonetaryAmount = 4;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 4;
			subject.Amount = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 6, false)]
	[InlineData(8, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal rate, decimal percent, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "4";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (percent > 0) 
			subject.Percent = percent;
		//If one, at least one
		if(subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 9;
			subject.Quantity2 = 7;
			subject.MonetaryAmount = 4;
		}
		if(subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.MonetaryAmount = 4;
			subject.Amount = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(8, 9, 7, 4, true)]
	[InlineData(8, 0, 0, 0, false)]
	[InlineData(0, 9, 7, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "4";
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
			subject.Percent = 6;
			subject.Amount = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(6, 4, "B", true)]
	[InlineData(6, 0, "", false)]
	[InlineData(0, 4, "B", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Percent(decimal percent, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "4";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 9;
			subject.Quantity2 = 7;
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
		subject.RelationshipCode = "4";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 9;
			subject.Quantity2 = 7;
			subject.MonetaryAmount = 4;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 4;
			subject.Amount = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "4";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 8;
			subject.Quantity = 9;
			subject.Quantity2 = 7;
			subject.MonetaryAmount = 4;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 4;
			subject.Amount = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
