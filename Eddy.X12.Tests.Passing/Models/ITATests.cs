using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ITATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITA*x*4D*CQ*8U*Y*6*O*v*1*9*lK*6*A*ezx*A*I*5h";

		var expected = new ITA_AllowanceChargeOrService()
		{
			AllowanceOrChargeIndicatorCode = "x",
			AgencyQualifierCode = "4D",
			SpecialServicesCode = "CQ",
			AllowanceOrChargeMethodOfHandlingCode = "8U",
			AllowanceOrChargeNumber = "Y",
			AllowanceOrChargeRate = 6,
			AllowanceOrChargeTotalAmount = "O",
			AllowanceChargePercentQualifier = "v",
			PercentDecimalFormat = 1,
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "lK",
			Quantity2 = 6,
			Description = "A",
			SpecialChargeOrAllowanceCode = "ezx",
			SourceSubqualifier = "A",
			RelationshipCode = "I",
			UnitOrBasisForMeasurementCode2 = "5h",
		};

		var actual = Map.MapObject<ITA_AllowanceChargeOrService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", "", "",true)]
	[InlineData("", "CQ", "", "", true)]
	[InlineData("4D", "", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, string description, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		subject.Description = description;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;

        if (agencyQualifierCode != "")
            subject.Description = "AAA";


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8U", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 1, true)]
	[InlineData("v", 0, false)]
	public void Validation_ARequiresBAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0)
		subject.PercentDecimalFormat = percentDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "lK", true)]
	[InlineData(0, "lK", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4D", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		if (agencyQualifierCode != "")
			subject.Description = "AAA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 6, true)]
	[InlineData("5h", 0, false)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new ITA_AllowanceChargeOrService();
		subject.AllowanceOrChargeIndicatorCode = "x";
		subject.AllowanceOrChargeMethodOfHandlingCode = "8U";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
