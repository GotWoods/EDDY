using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class SACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAC*3*M2rh*TI*i*L*K*8*3*rR*5*3*yf*c*k*L*o1";

		var expected = new SAC_ServicePromotionAllowanceOrChargeInformation()
		{
			AllowanceOrChargeIndicator = "3",
			ServicePromotionAllowanceOrChargeCode = "M2rh",
			AgencyQualifierCode = "TI",
			AgencyServicePromotionAllowanceOrChargeCode = "i",
			Amount = "L",
			AllowanceChargePercentQualifier = "K",
			PercentDecimalFormat = 8,
			Rate = 3,
			UnitOrBasisForMeasurementCode = "rR",
			Quantity = 5,
			Quantity2 = 3,
			AllowanceOrChargeMethodOfHandlingCode = "yf",
			ReferenceIdentification = "c",
			OptionNumber = "k",
			Description = "L",
			LanguageCode = "o1",
		};

		var actual = Map.MapObject<SAC_ServicePromotionAllowanceOrChargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		//Test Parameters
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("M2rh", "TI", true)]
	[InlineData("M2rh", "", true)]
	[InlineData("", "TI", true)]
	public void Validation_AtLeastOneServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TI", "i", true)]
	[InlineData("TI", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string agencyServicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.AgencyServicePromotionAllowanceOrChargeCode = agencyServicePromotionAllowanceOrChargeCode;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 8, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0) 
			subject.PercentDecimalFormat = percentDecimalFormat;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rR", 5, true)]
	[InlineData("rR", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(3, 5, true)]
	[InlineData(3, 0, false)]
	[InlineData(0, 5, true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "c", true)]
	[InlineData("k", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.OptionNumber = optionNumber;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o1", "L", true)]
	[InlineData("o1", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicator = "3";
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "M2rh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "TI";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "K";
			subject.PercentDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rR";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
