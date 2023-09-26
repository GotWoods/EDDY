using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAT**4*rJ*4*8*4**3**1*p*2*9*9*Y*G";

		var expected = new RAT_AdjustableRateDescription()
		{
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			SourceOfInterestRateChangeCode = "rJ",
			Percent = 4,
			Percent2 = 8,
			Percent3 = 4,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 3,
			CompositeUnitOfMeasure3 = null,
			Quantity3 = 1,
			YesNoConditionOrResponseCode = "p",
			Percent4 = 2,
			Percent5 = 9,
			Percent6 = 9,
			RoundingSystemCode = "Y",
			RateLifeCapSourceCode = "G",
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
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
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
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rJ", true)]
	public void Validation_RequiredSourceOfInterestRateChangeCode(string sourceOfInterestRateChangeCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		subject.SourceOfInterestRateChangeCode = sourceOfInterestRateChangeCode;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredPercent2(decimal percent2, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent2 > 0) 
			subject.Percent2 = percent2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
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
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 3;
		//Test Parameters
		if (percent3 > 0) 
			subject.Percent3 = percent3;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
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
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.Quantity2 = 3;
		//Test Parameters
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
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
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
		subject.Percent3 = 4;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.Percent6 > 0 || subject.Percent6 > 0 || !string.IsNullOrEmpty(subject.RoundingSystemCode))
		{
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Y", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Y", false)]
	public void Validation_AllAreRequiredPercent6(decimal percent6, string roundingSystemCode, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
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
	[InlineData("G", 2, true)]
	[InlineData("G", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBRateLifeCapSourceCode(string rateLifeCapSourceCode, decimal percent4, bool isValidExpected)
	{
		var subject = new RAT_AdjustableRateDescription();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.SourceOfInterestRateChangeCode = "rJ";
		subject.Percent = 4;
		subject.Percent2 = 8;
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
			subject.Percent6 = 9;
			subject.RoundingSystemCode = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
