using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT**6*Mu*9*2*4**3**8*z*3*8*4*S*d*9";

		var expected = new RAT_AdjustableRateDescription()
		{
			CompositeUnitOfMeasure = null,
			Quantity = 6,
			IndexIdentityCode = "Mu",
			Percent = 9,
			Percent2 = 2,
			Percent3 = 4,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 3,
			CompositeUnitOfMeasure3 = null,
			Quantity3 = 8,
			YesNoConditionOrResponseCode = "z",
			Percent4 = 3,
			Percent5 = 8,
			Percent6 = 4,
			RoundingSystemCode = "S",
			RateLifeCapSourceCode = "d",
			Percent7 = 9,
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
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mu", true)]
	public void Validation_RequiredIndexIdentityCode(string indexIdentityCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		subject.IndexIdentityCode = indexIdentityCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredPercent2(decimal percent2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent2 > 0) 
			subject.Percent2 = percent2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredPercent3(decimal percent3, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent3 > 0) 
			subject.Percent3 = percent3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
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
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.Quantity2 = 3;
		//Test Parameters
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "S", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "S", false)]
	public void Validation_AllAreRequiredPercent6(decimal percent6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent6 > 0) 
			subject.Percent6 = percent6;
		subject.RoundingSystemCode = roundingSystemCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("d", 3, true)]
	[InlineData("d", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percent4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.IndexIdentityCode = "Mu";
		subject.Percent = 9;
		subject.Percent2 = 2;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		subject.RateLifeCapSourceCode = rateLifeCapSourceCode;
		if (percent4 > 0) 
			subject.Percent4 = percent4;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 4;
			subject.RoundingSystemCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
