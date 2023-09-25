using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*e*R*4*7*UE*8*5*7*p*7r*9*6";

		var expected = new USD_UsageSensitiveDetail()
		{
			RelationshipCode = "e",
			AssignedIdentification = "R",
			Rate = 4,
			Percent = 7,
			UnitOrBasisForMeasurementCode = "UE",
			Quantity = 8,
			Quantity2 = 5,
			MonetaryAmount = 7,
			Amount = "p",
			UnitOrBasisForMeasurementCode2 = "7r",
			RangeMinimum = 9,
			RangeMaximum = 6,
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.RelationshipCode = relationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 4;
			subject.Quantity = 8;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7r";
			subject.RangeMinimum = 9;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 7, false)]
	[InlineData(4, 0, true)]
	[InlineData(0, 7, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal rate, decimal percent, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 8;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
            subject.UnitOrBasisForMeasurementCode = "AB";
            subject.UnitOrBasisForMeasurementCode2 = "AB";
        }
		if(subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7r";
			subject.RangeMinimum = 9;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(4, 8, 5, 7, true)]
	[InlineData(4, 0, 0, 0, false)]
	[InlineData(0, 8, 5, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Rate(decimal rate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		if (rate > 0) 
			subject.Rate = rate;
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7r";
			subject.RangeMinimum = 9;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(7, 7, "p", true)]
	[InlineData(7, 0, "", false)]
	[InlineData(0, 7, "p", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Percent(decimal percent, decimal monetaryAmount, string amount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.Rate = 4;
			subject.Quantity = 8;
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7r";
			subject.RangeMinimum = 9;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("UE", 8, true)]
	[InlineData("UE", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 4;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "7r";
			subject.RangeMinimum = 9;
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("7r", 9, 6, true)]
	[InlineData("7r", 0, 0, false)]
	[InlineData("", 9, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (rangeMinimum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "7r";
		if (rangeMaximum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "7r";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 4;
			subject.Quantity = 8;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "7r", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "7r", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 4;
			subject.Quantity = 8;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0)
		{
			subject.RangeMaximum = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "7r", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "7r", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.RelationshipCode = "e";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 8;
		}
		//If one, at least one
		if(subject.Rate > 0 || subject.Rate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Rate = 4;
			subject.Quantity = 8;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Percent = 7;
			subject.MonetaryAmount = 7;
			subject.Amount = "p";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0)
		{
			subject.RangeMinimum = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
