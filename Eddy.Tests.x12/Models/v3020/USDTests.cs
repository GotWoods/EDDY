using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*8*b*6*4*eZ*7*5*7*m*jx*8*8*JT*Jw*p*mv*s";

		var expected = new USD_UsageSensitiveDetail()
		{
			SublinePriceChangeCodeID = "8",
			AssignedIdentification = "b",
			AllowanceOrChargeRate = 6,
			Percent = 4,
			UnitOfMeasurementCode = "eZ",
			Quantity = 7,
			Quantity2 = 5,
			MonetaryAmount = 7,
			TermsDiscountAmount = "m",
			UnitOfMeasurementCode2 = "jx",
			RangeMinimum = 8,
			RangeMaximum = 8,
			AgencyQualifierCode = "JT",
			ServiceCharacteristicsQualifier = "Jw",
			ProductServiceID = "p",
			ServiceCharacteristicsQualifier2 = "mv",
			ProductServiceID2 = "s",
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredSublinePriceChangeCodeID(string sublinePriceChangeCodeID, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.SublinePriceChangeCodeID = sublinePriceChangeCodeID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 4, false)]
	[InlineData(6, 0, true)]
	[InlineData(0, 4, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal allowanceOrChargeRate, decimal percent, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		if (allowanceOrChargeRate > 0) 
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 7;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
            subject.UnitOfMeasurementCode = "AB";
            subject.UnitOfMeasurementCode2 = "AB";
        }
		if(subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(6, 7, 5, 7, true)]
	[InlineData(6, 0, 0, 0, false)]
	[InlineData(0, 7, 5, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AllowanceOrChargeRate(decimal allowanceOrChargeRate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		if (allowanceOrChargeRate > 0) 
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//A Requires B
		if (quantity > 0)
			subject.UnitOfMeasurementCode = "eZ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(4, 7, "m", true)]
	[InlineData(4, 0, "", false)]
	[InlineData(0, 7, "m", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Percent(decimal percent, decimal monetaryAmount, string termsDiscountAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.TermsDiscountAmount = termsDiscountAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "eZ", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "eZ", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("jx", 8, 8, true)]
	[InlineData("jx", 0, 0, false)]
	[InlineData("", 8, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfMeasurementCode2(string unitOfMeasurementCode2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "Jw";
			subject.ProductServiceID = "p";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jw", "p", true)]
	[InlineData("Jw", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		subject.ProductServiceID = productServiceID;
		//If one, at least one

        if (serviceCharacteristicsQualifier != "")
            subject.AgencyQualifierCode = "AB";

		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jw", "JT", true)]
	[InlineData("Jw", "", false)]
	[InlineData("", "JT", true)]
	public void Validation_ARequiresBServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.SublinePriceChangeCodeID = "8";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
        //If one, at least one

        if (serviceCharacteristicsQualifier != "")
            subject.ProductServiceID = "AB";

        if (subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 5;
			subject.MonetaryAmount = 7;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 4;
			subject.MonetaryAmount = 7;
			subject.TermsDiscountAmount = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOfMeasurementCode2 = "jx";
			subject.RangeMinimum = 8;
			subject.RangeMaximum = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	

}
