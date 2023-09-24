using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*a*W*1*2**6*5*9*f**3*8";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "a",
			AssignedIdentification = "W",
			Rate = 1,
			PercentageAsDecimal = 2,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
			Quantity = 6,
			Quantity2 = 5,
			MonetaryAmount = 9,
			Amount = "f",
			CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure(),
			RangeMinimum = 3,
			RangeMaximum = 8,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = relationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 2, false)]
	[InlineData(0, 2, true)]
	[InlineData(1, 0, true)]
	public void Validation_OnlyOneOfRate(decimal rate, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = "a";
		if (rate > 0)
		subject.Rate = rate;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0,0, 0, 0, true)]
	[InlineData(1, 6,0,0, true)]
	[InlineData(0,6,0,0, true)]
	[InlineData(1, 0, 0,0,true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = "a";
		if (rate > 0)
		subject.Rate = rate;
		if (quantity > 0)
		subject.Quantity = quantity;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0,0, "",true)]
	[InlineData(2, 9, "",true)]
	[InlineData(0, 9, "", true)]
	[InlineData(2, 0, "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_PercentageAsDecimal(decimal percentageAsDecimal, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = "a";
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = "a";
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;

        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };

        

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(8, "AA", false)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		subject.RelationshipCode = "a";
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };
        

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
