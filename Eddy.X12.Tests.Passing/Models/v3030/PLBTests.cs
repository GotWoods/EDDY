using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*a*n3h60X*h*5*w*2*9*1*X*5*m*4*P*2";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceNumber = "a",
			Date = "n3h60X",
			ReferenceNumber2 = "h",
			MonetaryAmount = 5,
			ReferenceNumber3 = "w",
			MonetaryAmount2 = 2,
			ReferenceNumber4 = "9",
			MonetaryAmount3 = 1,
			ReferenceNumber5 = "X",
			MonetaryAmount4 = 5,
			ReferenceNumber6 = "m",
			MonetaryAmount5 = 4,
			ReferenceNumber7 = "P",
			MonetaryAmount6 = 2,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n3h60X", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 2, true)]
	[InlineData("w", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredReferenceNumber3(string referenceNumber3, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber3 = referenceNumber3;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9", 1, true)]
	[InlineData("9", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredReferenceNumber4(string referenceNumber4, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber4 = referenceNumber4;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 5, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredReferenceNumber5(string referenceNumber5, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber5 = referenceNumber5;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("m", 4, true)]
	[InlineData("m", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredReferenceNumber6(string referenceNumber6, decimal monetaryAmount5, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber6 = referenceNumber6;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber7) || !string.IsNullOrEmpty(subject.ReferenceNumber7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceNumber7 = "P";
			subject.MonetaryAmount6 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P", 2, true)]
	[InlineData("P", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredReferenceNumber7(string referenceNumber7, decimal monetaryAmount6, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Date = "n3h60X";
		subject.ReferenceNumber2 = "h";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ReferenceNumber7 = referenceNumber7;
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumber3) || !string.IsNullOrEmpty(subject.ReferenceNumber3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceNumber3 = "w";
			subject.MonetaryAmount2 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber4) || !string.IsNullOrEmpty(subject.ReferenceNumber4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceNumber4 = "9";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber5) || !string.IsNullOrEmpty(subject.ReferenceNumber5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceNumber5 = "X";
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumber6) || !string.IsNullOrEmpty(subject.ReferenceNumber6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceNumber6 = "m";
			subject.MonetaryAmount5 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
