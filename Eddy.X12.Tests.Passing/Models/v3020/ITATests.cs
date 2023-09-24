using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*V*SX*Wq*Ta*8*4*0*U*8*3*QK*9*M*Sek";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicator = "V",
			AgencyQualifierCode = "SX",
			SpecialServicesCode = "Wq",
			AllowanceOrChargeMethodOfHandlingCode = "Ta",
			AllowanceOrChargeNumber = "8",
			AllowanceOrChargeRate = 4,
			AllowanceOrChargeTotalAmount = "0",
			AllowanceChargePercentQualifier = "U",
			AllowanceOrChargePercent = 8,
			AllowanceOrChargeQuantity = 3,
			UnitOfMeasurementCode = "QK",
			Quantity = 9,
			Description = "M",
			SpecialChargeOrAllowanceCode = "Sek",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "Ta";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "SX";
			subject.SpecialServicesCode = "Wq";
			subject.Description = "M";
			subject.SpecialChargeOrAllowanceCode = "Sek";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", "", true)]
	[InlineData("SX", "Wq", "M", "Sek", true)]
	[InlineData("SX", "", "", "", false)]
	[InlineData("", "Wq", "M", "Sek", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = "Ta";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ta", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "SX";
			subject.SpecialServicesCode = "Wq";
			subject.Description = "M";
			subject.SpecialChargeOrAllowanceCode = "Sek";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U", 8, true)]
	[InlineData("U", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal allowanceOrChargePercent, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = "Ta";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "SX";
			subject.SpecialServicesCode = "Wq";
			subject.Description = "M";
			subject.SpecialChargeOrAllowanceCode = "Sek";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "QK", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "QK", true)]
	public void Validation_ARequiresBAllowanceOrChargeQuantity(decimal allowanceOrChargeQuantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicator = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = "Ta";
		if (allowanceOrChargeQuantity > 0)
			subject.AllowanceOrChargeQuantity = allowanceOrChargeQuantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode) || !string.IsNullOrEmpty(subject.Description) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AgencyQualifierCode = "SX";
			subject.SpecialServicesCode = "Wq";
			subject.Description = "M";
			subject.SpecialChargeOrAllowanceCode = "Sek";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
