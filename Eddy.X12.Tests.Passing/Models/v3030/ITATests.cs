using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*j*sZ*d4*dB*k*7*y*9*6*2*ss*3*r*KiN*f*m";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicator = "j",
			AgencyQualifierCode = "sZ",
			SpecialServicesCode = "d4",
			AllowanceOrChargeMethodOfHandlingCode = "dB",
			AllowanceOrChargeNumber = "k",
			AllowanceOrChargeRate = 7,
			AllowanceOrChargeTotalAmount = "y",
			AllowanceChargePercentQualifier = "9",
			AllowanceOrChargePercent = 6,
			AllowanceOrChargeQuantity = 2,
			UnitOrBasisForMeasurementCode = "ss",
			Quantity = 3,
			Description = "r",
			SpecialChargeOrAllowanceCode = "KiN",
			SourceSubqualifier = "f",
			PriceRelationshipCode = "m",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "dB";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sZ";
			subject.SpecialServicesCode = "d4";
			subject.Description = "r";
			subject.SpecialChargeOrAllowanceCode = "KiN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("sZ", "d4", "r", "KiN", true)]
	[InlineData("sZ", "", "", "", false)]
	[InlineData("", "d4", "r", "KiN", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "j";
		subject.AllowanceOrChargeMethodOfHandlingCode = "dB";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dB", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "j";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sZ";
			subject.SpecialServicesCode = "d4";
			subject.Description = "r";
			subject.SpecialChargeOrAllowanceCode = "KiN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9", 6, true)]
	[InlineData("9", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal allowanceOrChargePercent, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "j";
		subject.AllowanceOrChargeMethodOfHandlingCode = "dB";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sZ";
			subject.SpecialServicesCode = "d4";
			subject.Description = "r";
			subject.SpecialChargeOrAllowanceCode = "KiN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "ss", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "ss", true)]
	public void Validation_ARequiresBAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "j";
		subject.AllowanceOrChargeMethodOfHandlingCode = "dB";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sZ";
			subject.SpecialServicesCode = "d4";
			subject.Description = "r";
			subject.SpecialChargeOrAllowanceCode = "KiN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "sZ", true)]
	[InlineData("f", "", false)]
	[InlineData("", "sZ", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "j";
		subject.AllowanceOrChargeMethodOfHandlingCode = "dB";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sZ";
			subject.SpecialServicesCode = "d4";
			subject.Description = "r";
			subject.SpecialChargeOrAllowanceCode = "KiN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
