using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*R*lXrqfV*p*1*s*9*1*1*W*4*U*8*R*5";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "R",
			Date = "lXrqfV",
			ReferenceIdentification2 = "p",
			MonetaryAmount = 1,
			ReferenceIdentification3 = "s",
			MonetaryAmount2 = 9,
			ReferenceIdentification4 = "1",
			MonetaryAmount3 = 1,
			ReferenceIdentification5 = "W",
			MonetaryAmount4 = 4,
			ReferenceIdentification6 = "U",
			MonetaryAmount5 = 8,
			ReferenceIdentification7 = "R",
			MonetaryAmount6 = 5,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lXrqfV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 9, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredReferenceIdentification3(string referenceIdentification3, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1", 1, true)]
	[InlineData("1", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredReferenceIdentification4(string referenceIdentification4, decimal monetaryAmount3, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification4 = referenceIdentification4;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("W", 4, true)]
	[InlineData("W", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredReferenceIdentification5(string referenceIdentification5, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification5 = referenceIdentification5;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U", 8, true)]
	[InlineData("U", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredReferenceIdentification6(string referenceIdentification6, decimal monetaryAmount5, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification6 = referenceIdentification6;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification7) || !string.IsNullOrEmpty(subject.ReferenceIdentification7) || subject.MonetaryAmount6 > 0)
		{
			subject.ReferenceIdentification7 = "R";
			subject.MonetaryAmount6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("R", 5, true)]
	[InlineData("R", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredReferenceIdentification7(string referenceIdentification7, decimal monetaryAmount6, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "R";
		subject.Date = "lXrqfV";
		subject.ReferenceIdentification2 = "p";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification7 = referenceIdentification7;
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3) || subject.MonetaryAmount2 > 0)
		{
			subject.ReferenceIdentification3 = "s";
			subject.MonetaryAmount2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification4) || !string.IsNullOrEmpty(subject.ReferenceIdentification4) || subject.MonetaryAmount3 > 0)
		{
			subject.ReferenceIdentification4 = "1";
			subject.MonetaryAmount3 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || subject.MonetaryAmount4 > 0)
		{
			subject.ReferenceIdentification5 = "W";
			subject.MonetaryAmount4 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification6) || !string.IsNullOrEmpty(subject.ReferenceIdentification6) || subject.MonetaryAmount5 > 0)
		{
			subject.ReferenceIdentification6 = "U";
			subject.MonetaryAmount5 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
