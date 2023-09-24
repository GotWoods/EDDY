using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*9*sx*4T*T0*v*5*g*O*8*5*tb*2*R*BtD*s*G";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicator = "9",
			AgencyQualifierCode = "sx",
			SpecialServicesCode = "4T",
			AllowanceOrChargeMethodOfHandlingCode = "T0",
			AllowanceOrChargeNumber = "v",
			AllowanceOrChargeRate = 5,
			AllowanceOrChargeTotalAmount = "g",
			AllowanceChargePercentQualifier = "O",
			Percent = 8,
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "tb",
			Quantity2 = 2,
			Description = "R",
			SpecialChargeOrAllowanceCode = "BtD",
			SourceSubqualifier = "s",
			RelationshipCode = "G",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "T0";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode = "tb";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sx";
			subject.SpecialServicesCode = "4T";
			subject.Description = "R";
			subject.SpecialChargeOrAllowanceCode = "BtD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("sx", "4T", "R", "BtD", true)]
	[InlineData("sx", "", "", "", false)]
	[InlineData("", "4T", "R", "BtD", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "T0";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode = "tb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T0", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode = "tb";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sx";
			subject.SpecialServicesCode = "4T";
			subject.Description = "R";
			subject.SpecialChargeOrAllowanceCode = "BtD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 8, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "T0";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode = "tb";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sx";
			subject.SpecialServicesCode = "4T";
			subject.Description = "R";
			subject.SpecialChargeOrAllowanceCode = "BtD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "tb", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "tb", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "T0";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sx";
			subject.SpecialServicesCode = "4T";
			subject.Description = "R";
			subject.SpecialChargeOrAllowanceCode = "BtD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "sx", true)]
	[InlineData("s", "", false)]
	[InlineData("", "sx", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "T0";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 5;
			subject.UnitOrBasisForMeasurementCode = "tb";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "sx";
			subject.SpecialServicesCode = "4T";
			subject.Description = "R";
			subject.SpecialChargeOrAllowanceCode = "BtD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
