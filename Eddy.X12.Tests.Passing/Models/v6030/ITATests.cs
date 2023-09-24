using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*y*Mc*yD*uP*S*9*P*t*7*1*Dp*7*N*AVS*h*e*Hs";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicatorCode = "y",
			AgencyQualifierCode = "Mc",
			SpecialServicesCode = "yD",
			AllowanceOrChargeMethodOfHandlingCode = "uP",
			AllowanceOrChargeNumber = "S",
			AllowanceOrChargeRate = 9,
			AllowanceOrChargeTotalAmount = "P",
			AllowanceChargePercentQualifier = "t",
			PercentDecimalFormat = 7,
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "Dp",
			Quantity2 = 7,
			Description = "N",
			SpecialChargeOrAllowanceCode = "AVS",
			SourceSubqualifier = "h",
			RelationshipCode = "e",
			UnitOrBasisForMeasurementCode2 = "Hs",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("Mc", "yD", "N", "AVS", true)]
	[InlineData("Mc", "", "", "", false)]
	[InlineData("", "yD", "N", "AVS", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t", 7, true)]
	[InlineData("t", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0)
			subject.PercentDecimalFormat = percentDecimalFormat;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Dp", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Dp", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "Mc", true)]
	[InlineData("h", "", false)]
	[InlineData("", "Mc", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Hs", 7, true)]
	[InlineData("Hs", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "uP";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Dp";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "Mc";
			subject.SpecialServicesCode = "yD";
			subject.Description = "N";
			subject.SpecialChargeOrAllowanceCode = "AVS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
