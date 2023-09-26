using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USD*5*g*6*6*4D*7*3*2*W*m5*4*5*nZ*MS*r*Ud*5";

		var expected = new USD_UsageSensitiveDetail()
		{
			PriceRelationshipCode = "5",
			AssignedIdentification = "g",
			AllowanceOrChargeRate = 6,
			Percent = 6,
			UnitOrBasisForMeasurementCode = "4D",
			Quantity = 7,
			Quantity2 = 3,
			MonetaryAmount = 2,
			TermsDiscountAmount = "W",
			UnitOrBasisForMeasurementCode2 = "m5",
			RangeMinimum = 4,
			RangeMaximum = 5,
			AgencyQualifierCode = "nZ",
			ServiceCharacteristicsQualifier = "MS",
			ProductServiceID = "r",
			ServiceCharacteristicsQualifier2 = "Ud",
			ProductServiceID2 = "5",
		};

		var actual = Map.MapObject<USD_UsageSensitiveDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredPriceRelationshipCode(string priceRelationshipCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		//Test Parameters
		subject.PriceRelationshipCode = priceRelationshipCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 6, false)]
	[InlineData(6, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfAssignedIdentification(decimal allowanceOrChargeRate, decimal percent, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
		//Test Parameters
		if (allowanceOrChargeRate > 0) 
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.Quantity = 7;
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
            subject.UnitOrBasisForMeasurementCode = "AB";
            subject.UnitOrBasisForMeasurementCode2 = "AB";
        }
		if(subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(6, 7, 3, 2, true)]
	[InlineData(6, 0, 0, 0, false)]
	[InlineData(0, 7, 3, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AllowanceOrChargeRate(decimal allowanceOrChargeRate, decimal quantity, decimal quantity2, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
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
			subject.UnitOrBasisForMeasurementCode = "4D";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, "", true)]
	[InlineData(6, 2, "W", true)]
	[InlineData(6, 0, "", false)]
	[InlineData(0, 2, "W", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Percent(decimal percent, decimal monetaryAmount, string termsDiscountAmount, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.TermsDiscountAmount = termsDiscountAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "4D", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "4D", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("m5", 4, 5, true)]
	[InlineData("m5", 0, 0, false)]
	[InlineData("", 4, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ServiceCharacteristicsQualifier = "MS";
			subject.ProductServiceID = "r";
		}
		//If one, at least one
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MS", "r", true)]
	[InlineData("MS", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		subject.ProductServiceID = productServiceID;
        //If one, at least one

        if (serviceCharacteristicsQualifier != "")
            subject.AgencyQualifierCode = "AB";

        if (subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || subject.Quantity > 0 || subject.Quantity2 > 0 || subject.MonetaryAmount > 0)
		{
			subject.AllowanceOrChargeRate = 6;
			subject.Quantity = 7;
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MS", "nZ", true)]
	[InlineData("MS", "", false)]
	[InlineData("", "nZ", true)]
	public void Validation_ARequiresBServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new USD_UsageSensitiveDetail();
		//Required fields
		subject.PriceRelationshipCode = "5";
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
			subject.Quantity2 = 3;
			subject.MonetaryAmount = 2;
		}
		if(subject.Percent > 0 || subject.Percent > 0 || subject.MonetaryAmount > 0 || !string.IsNullOrEmpty(subject.TermsDiscountAmount))
		{
			subject.Percent = 6;
			subject.MonetaryAmount = 2;
			subject.TermsDiscountAmount = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "m5";
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}



}
