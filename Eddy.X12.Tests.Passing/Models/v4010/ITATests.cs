using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*Y*H5*rO*MQ*R*1*c*4*3*2*0L*6*W*q8b*l*C*lP";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicator = "Y",
			AgencyQualifierCode = "H5",
			SpecialServicesCode = "rO",
			AllowanceOrChargeMethodOfHandlingCode = "MQ",
			AllowanceOrChargeNumber = "R",
			AllowanceOrChargeRate = 1,
			AllowanceOrChargeTotalAmount = "c",
			AllowanceChargePercentQualifier = "4",
			Percent = 3,
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "0L",
			Quantity2 = 6,
			Description = "W",
			SpecialChargeOrAllowanceCode = "q8b",
			SourceSubqualifier = "l",
			RelationshipCode = "C",
			UnitOrBasisForMeasurementCode2 = "lP",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("H5", "rO", "W", "q8b", true)]
	[InlineData("H5", "", "", "", false)]
	[InlineData("", "rO", "W", "q8b", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MQ", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4", 3, true)]
	[InlineData("4", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "0L", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "0L", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "H5", true)]
	[InlineData("l", "", false)]
	[InlineData("", "H5", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lP", 6, true)]
	[InlineData("lP", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "Y";
		subject.AllowanceOrChargeMethodOfHandlingCode = "MQ";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "0L";
		}
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "H5";
			subject.SpecialServicesCode = "rO";
			subject.Description = "W";
			subject.SpecialChargeOrAllowanceCode = "q8b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
