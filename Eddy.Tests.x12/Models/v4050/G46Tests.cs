using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*9*G5*5*Ly*c*J*6*l*g*Q*9aS*8";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "9",
			AllowanceOrChargeMethodOfHandlingCode = "G5",
			AllowanceOrChargeRate = 5,
			UnitOrBasisForMeasurementCode = "Ly",
			Amount = "c",
			AllowanceChargePercentQualifier = "J",
			PercentDecimalFormat = 6,
			ExceptionNumber = "l",
			OptionNumber = "g",
			Description = "Q",
			PriceIdentifierCode = "9aS",
			Number = 8,
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "G5";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 5;
			subject.UnitOrBasisForMeasurementCode = "Ly";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "J";
			subject.PercentDecimalFormat = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G5", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 5;
			subject.UnitOrBasisForMeasurementCode = "Ly";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "J";
			subject.PercentDecimalFormat = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Ly", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Ly", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "G5";
		if (allowanceOrChargeRate > 0)
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.PercentDecimalFormat > 0)
		{
			subject.AllowanceChargePercentQualifier = "J";
			subject.PercentDecimalFormat = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("J", 6, true)]
	[InlineData("J", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "9";
		subject.AllowanceOrChargeMethodOfHandlingCode = "G5";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percentDecimalFormat > 0)
			subject.PercentDecimalFormat = percentDecimalFormat;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 5;
			subject.UnitOrBasisForMeasurementCode = "Ly";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
