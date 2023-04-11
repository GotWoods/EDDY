using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*P*tp*3*Z9*0*K*5*W*e*x*U8B*6";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "P",
			AllowanceOrChargeMethodOfHandlingCode = "tp",
			AllowanceOrChargeRate = 3,
			UnitOrBasisForMeasurementCode = "Z9",
			Amount = "0",
			AllowanceChargePercentQualifier = "K",
			PercentDecimalFormat = 5,
			ExceptionNumber = "W",
			OptionNumber = "e",
			Description = "x",
			PriceIdentifierCode = "U8B",
			Number = 6,
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "tp";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tp", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "Z9", true)]
	[InlineData(0, "Z9", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = "tp";
		if (allowanceOrChargeRate > 0)
		subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("K", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("K", 0, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "P";
		subject.AllowanceOrChargeMethodOfHandlingCode = "tp";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0)
		subject.PercentDecimalFormat = percentDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
