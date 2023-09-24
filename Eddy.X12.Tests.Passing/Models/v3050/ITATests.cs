using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*d*tz*Gj*78*7*4*i*N*2*1*Nd*2*f*C5i*G*s";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicator = "d",
			AgencyQualifierCode = "tz",
			SpecialServicesCode = "Gj",
			AllowanceOrChargeMethodOfHandlingCode = "78",
			AllowanceOrChargeNumber = "7",
			AllowanceOrChargeRate = 4,
			AllowanceOrChargeTotalAmount = "i",
			AllowanceChargePercentQualifier = "N",
			Percent = 2,
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "Nd",
			Quantity2 = 2,
			Description = "f",
			SpecialChargeOrAllowanceCode = "C5i",
			SourceSubqualifier = "G",
			RelationshipCode = "s",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "78";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Nd";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "tz";
			subject.SpecialServicesCode = "Gj";
			subject.Description = "f";
			subject.SpecialChargeOrAllowanceCode = "C5i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("tz", "Gj", "f", "C5i", true)]
	[InlineData("tz", "", "", "", false)]
	[InlineData("", "Gj", "f", "C5i", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "d";
		subject.AllowanceOrChargeMethodOfHandlingCode = "78";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Nd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("78", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "d";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Nd";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "tz";
			subject.SpecialServicesCode = "Gj";
			subject.Description = "f";
			subject.SpecialChargeOrAllowanceCode = "C5i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 2, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "d";
		subject.AllowanceOrChargeMethodOfHandlingCode = "78";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Nd";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "tz";
			subject.SpecialServicesCode = "Gj";
			subject.Description = "f";
			subject.SpecialChargeOrAllowanceCode = "C5i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Nd", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Nd", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "d";
		subject.AllowanceOrChargeMethodOfHandlingCode = "78";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "tz";
			subject.SpecialServicesCode = "Gj";
			subject.Description = "f";
			subject.SpecialChargeOrAllowanceCode = "C5i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "tz", true)]
	[InlineData("G", "", false)]
	[InlineData("", "tz", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "d";
		subject.AllowanceOrChargeMethodOfHandlingCode = "78";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 1;
			subject.UnitOrBasisForMeasurementCode = "Nd";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "tz";
			subject.SpecialServicesCode = "Gj";
			subject.Description = "f";
			subject.SpecialChargeOrAllowanceCode = "C5i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
