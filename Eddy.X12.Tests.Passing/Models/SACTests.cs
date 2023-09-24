using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAC*R*c6UB*LG*D*9*e*6*5*dl*9*4*qg*X*k*g*zf";

		var expected = new SAC_ServicePromotionAllowanceOrChargeInformation()
		{
			AllowanceOrChargeIndicatorCode = "R",
			ServicePromotionAllowanceOrChargeCode = "c6UB",
			AgencyQualifierCode = "LG",
			AgencyServicePromotionAllowanceOrChargeCode = "D",
			Amount = "9",
			AllowanceChargePercentQualifier = "e",
			PercentDecimalFormat = 6,
			Rate = 5,
			UnitOrBasisForMeasurementCode = "dl",
			Quantity = 9,
			Quantity2 = 4,
			AllowanceOrChargeMethodOfHandlingCode = "qg",
			ReferenceIdentification = "X",
			OptionNumber = "k",
			Description = "g",
			LanguageCode = "zf",
		};

		var actual = Map.MapObject<SAC_ServicePromotionAllowanceOrChargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}
	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		subject.ServicePromotionAllowanceOrChargeCode = "abcd";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}
	[Theory]
	[InlineData("", "", false)]
	[InlineData("c6UB", "LG", true)]
	[InlineData("", "LG", true)]
	[InlineData("c6UB", "", true)]
	public void Validation_AtLeastOneServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
        if (agencyQualifierCode != "")
            subject.AgencyServicePromotionAllowanceOrChargeCode = "bc";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("LG", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("LG", "", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string agencyServicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.AgencyServicePromotionAllowanceOrChargeCode = agencyServicePromotionAllowanceOrChargeCode;
        subject.ServicePromotionAllowanceOrChargeCode = "abcd";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("e", 0, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0)
			subject.PercentDecimalFormat = percentDecimalFormat;
		subject.ServicePromotionAllowanceOrChargeCode = "abcd";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData("", 0, true)]
	[InlineData("dl", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("dl", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
        subject.ServicePromotionAllowanceOrChargeCode = "abcd";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 9, true)]
	[InlineData(4, 0, false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
		{
			subject.Quantity = quantity;
			subject.UnitOrBasisForMeasurementCode = "AB";
		}
        subject.ServicePromotionAllowanceOrChargeCode = "abcd";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "X", true)]
	[InlineData("k", "", false)]
	public void Validation_ARequiresBOptionNumber(string optionNumber, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.OptionNumber = optionNumber;
		subject.ReferenceIdentification = referenceIdentification;
        subject.ServicePromotionAllowanceOrChargeCode = "abcd";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("zf", "", false)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
		subject.AllowanceOrChargeIndicatorCode = "R";
		subject.LanguageCode = languageCode;
		subject.Description = description;
        subject.ServicePromotionAllowanceOrChargeCode = "abcd";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
}
