using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAC*X*wqj5*1M*U*0*D*7*4*MD*6*4*ot*u*B*R*Xp";

		var expected = new SAC_ServicePromotionAllowanceOrChargeInformation()
		{
			AllowanceOrChargeIndicatorCode = "X",
			ServicePromotionAllowanceOrChargeCode = "wqj5",
			AgencyQualifierCode = "1M",
			AgencyServicePromotionAllowanceOrChargeCode = "U",
			Amount = "0",
			AllowanceChargePercentQualifier = "D",
			PercentDecimalFormat = 7,
			Rate = 4,
			UnitOrBasisForMeasurementCode = "MD",
			Quantity = 6,
			Quantity2 = 4,
			AllowanceOrChargeMethodOfHandlingCode = "ot",
			ReferenceIdentification = "u",
			OptionNumber = "B",
			Description = "R",
			LanguageCode = "Xp",
		};

		var actual = Map.MapObject<SAC_ServicePromotionAllowanceOrChargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		//Test Parameters
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("wqj5", "1M", true)]
	[InlineData("wqj5", "", true)]
	[InlineData("", "1M", true)]
	public void Validation_AtLeastOneServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1M", "U", true)]
	[InlineData("1M", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string agencyServicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.AgencyServicePromotionAllowanceOrChargeCode = agencyServicePromotionAllowanceOrChargeCode;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 7, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0) 
			subject.PercentDecimalFormat = percentDecimalFormat;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MD", 6, true)]
	[InlineData("MD", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 6, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 6, true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "u", true)]
	[InlineData("B", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.OptionNumber = optionNumber;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xp", "R", true)]
	[InlineData("Xp", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		//Required fields
		subject.AllowanceOrChargeIndicatorCode = "X";
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//At Least one
		subject.ServicePromotionAllowanceOrChargeCode = "wqj5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyServicePromotionAllowanceOrChargeCode))
		{
			subject.AgencyQualifierCode = "1M";
			subject.AgencyServicePromotionAllowanceOrChargeCode = "U";
		}
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "D";
			subject.PercentDecimalFormat = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MD";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
