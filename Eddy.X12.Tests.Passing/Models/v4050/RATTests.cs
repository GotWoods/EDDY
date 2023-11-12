using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050.Composites;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT**4*pW*9*7*3**9**7*I*3*9*3*k*3*4";

		var expected = new RAT_AdjustableRateDescription()
		{
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			IndexIdentityCode = "pW",
			PercentageAsDecimal = 9,
			PercentageAsDecimal2 = 7,
			PercentageAsDecimal3 = 3,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 9,
			CompositeUnitOfMeasure3 = null,
			Quantity3 = 7,
			YesNoConditionOrResponseCode = "I",
			PercentageAsDecimal4 = 3,
			PercentageAsDecimal5 = 9,
			PercentageAsDecimal6 = 3,
			RoundingSystemCode = "k",
			RateLifeCapSourceCode = "3",
			PercentageAsDecimal7 = 4,
		};

		var actual = Map.MapObject<RAT_AdjustableRateDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pW", true)]
	public void Validation_RequiredIndexIdentityCode(string indexIdentityCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		subject.IndexIdentityCode = indexIdentityCode;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredPercentageAsDecimal(decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPercentageAsDecimal2(decimal percentageAsDecimal2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (percentageAsDecimal2 > 0) 
			subject.PercentageAsDecimal2 = percentageAsDecimal2;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPercentageAsDecimal3(decimal percentageAsDecimal3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (percentageAsDecimal3 > 0) 
			subject.PercentageAsDecimal3 = percentageAsDecimal3;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure2(string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.Quantity2 = 9;
		//Test Parameters
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "k", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "k", false)]
	public void Validation_AllAreRequiredPercentageAsDecimal6(decimal percentageAsDecimal6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		if (percentageAsDecimal6 > 0) 
			subject.PercentageAsDecimal6 = percentageAsDecimal6;
		subject.RoundingSystemCode = roundingSystemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("3", 3, true)]
	[InlineData("3", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percentageAsDecimal4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.IndexIdentityCode = "pW";
		subject.PercentageAsDecimal = 9;
		subject.PercentageAsDecimal2 = 7;
		subject.PercentageAsDecimal3 = 3;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 9;
		//Test Parameters
		subject.RateLifeCapSourceCode = rateLifeCapSourceCode;
		if (percentageAsDecimal4 > 0) 
			subject.PercentageAsDecimal4 = percentageAsDecimal4;
		//If one filled, all required
		if(subject.PercentageAsDecimal6 > 0 || subject.PercentageAsDecimal6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.PercentageAsDecimal6 = 3;
			subject.RoundingSystemCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
