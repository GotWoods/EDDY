using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAC*p*Z5AQ*Ut*W*m*e*2*4*TD*2*6*Er*Y*7*f*G3";

		var expected = new SAC_ServicePromotionAllowanceOrChargeInformation()
		{
			AllowanceOrChargeIndicator = "p",
			ServicePromotionAllowanceOrChargeCode = "Z5AQ",
			AgencyQualifierCode = "Ut",
			AgencyServicePromotionAllowanceOrChargeCode = "W",
			Amount = "m",
			AllowanceChargePercentQualifier = "e",
			PercentDecimalFormat = 2,
			Rate = 4,
			UnitOrBasisForMeasurementCode = "TD",
			Quantity = 2,
			Quantity2 = 6,
			AllowanceOrChargeMethodOfHandlingCode = "Er",
			ReferenceIdentification = "Y",
			OptionNumber = "7",
			Description = "f",
			LanguageCode = "G3",
		};

		var actual = Map.MapObject<SAC_ServicePromotionAllowanceOrChargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		//Test Parameters
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z5AQ", "Ut", true)]
	[InlineData("Z5AQ", "", true)]
	[InlineData("", "Ut", true)]
	public void Validation_AtLeastOneServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ut", "W", true)]
	[InlineData("Ut", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string agencyServicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.AgencyServicePromotionAllowanceOrChargeCode = agencyServicePromotionAllowanceOrChargeCode;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 2, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0) 
			subject.PercentDecimalFormat = percentDecimalFormat;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TD", 2, true)]
	[InlineData("TD", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 2, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 2, true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "Y", true)]
	[InlineData("7", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.OptionNumber = optionNumber;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G3", "f", true)]
	[InlineData("G3", "", false)]
	[InlineData("", "f", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "p";
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "Z5AQ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "Ut";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "e";
			subject.PercentDecimalFormat = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "TD";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
